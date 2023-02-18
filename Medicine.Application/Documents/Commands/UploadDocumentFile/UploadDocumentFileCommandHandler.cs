using System.Security.Cryptography;
using AutoMapper;
using MediatR;
using Medicine.DataAccess.Interfaces;
using Medicine.Domain;
using Medicine.Shared;

namespace Medicine.Application.Documents.Commands.UploadDocumentFile
{
    public class UploadDocumentFileCommandHandler : AsyncRequestHandler<UploadDocumentFileCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private const int PointDevision = 100;

        public UploadDocumentFileCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UploadDocumentFileCommand request, CancellationToken cancellationToken)
        {
            using var file = request.Files.OpenReadStream();
            using MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            var fileOnByte = ms.ToArray();
            var checksum = GetMD5Checksum(fileOnByte);
            if (FileExists(request.DocumentId, checksum)) throw new FileExistException(request.Files.FileName, checksum);
            var firstPartBytes = fileOnByte.Take(PointDevision);
            var cheksumFirst = GetMD5Checksum(firstPartBytes.ToArray());
            var secondPartsBytes = fileOnByte.Skip(PointDevision).Take(fileOnByte.Length);
            var cheksumSecond = GetMD5Checksum(secondPartsBytes.ToArray());
            var version = 1;
            var parentId = 0;
            var fileName = $"{Path.GetFileNameWithoutExtension(request.Files.FileName)}_{version}{Path.GetExtension(request.Files.FileName)}";



            DocumentFile parentDocumentFile;
            if (TryGetParentDocumentFile(request.DocumentId, cheksumFirst, cheksumSecond, out parentDocumentFile))
            {
                version = ++parentDocumentFile.Version;
                parentId = parentDocumentFile.Id;
                fileName = $"{Path.GetFileNameWithoutExtension(parentDocumentFile.Name)}_{version}{Path.GetExtension(parentDocumentFile.Name)}";
            }


            await dbContext.InvokeTransactionAsync(async () =>
            {
                var savedPath = await SaveFile(fileName, ms.ToArray());
                var documentFile = new DocumentFile
                {
                    Checksum = checksum,
                    DocumentId = request.DocumentId,
                    Name = fileName,
                    Path = savedPath,
                    UploadedDate = DateTime.UtcNow,
                    CheksumFirstPart = cheksumFirst,
                    CheksumSecondPart = cheksumSecond,
                    Version = version,
                    ParentId = parentId

                };
                await dbContext.AddAsync(documentFile);
                await dbContext.SaveChangesAsync(cancellationToken);
            });


            file.Close();
        }
        private bool FileExists(int? documentId, string cheksum)
        {
            var documentFiles = dbContext.Set<DocumentFile>().Where(p => p.DocumentId == documentId).ToList();
            return documentFiles.Any(p => p.Checksum.Equals(cheksum));
        }
        private bool TryGetParentDocumentFile(int? documentId, string cheksumFirst, string cheksumSecond, out DocumentFile dfile)
        {
            var documentFiles = dbContext.Set<DocumentFile>().Where(p => p.DocumentId == documentId).ToList();
            var parentFile = documentFiles.Where(p => p.CheksumFirstPart.Equals(cheksumFirst)
                                                   || p.CheksumFirstPart.Equals(cheksumSecond)).ToList().MaxBy(p => p.Version);
            if (parentFile != null)
            {
                dfile = parentFile;
                return true;
            }
            else
            {
                dfile = null;
                return false;
            }

        }

        private async Task<string> SaveFile(string fileNime, byte[] file)
        {
            string path = string.Empty;
            try
            {
                var curentDirectory = Directory.GetCurrentDirectory();
                var documentFilesDirectory = Path.Combine(curentDirectory, "DocumentFiles");
                Directory.CreateDirectory(documentFilesDirectory);
                path = Path.Combine(documentFilesDirectory, fileNime);
                if (Directory.Exists(documentFilesDirectory))
                {
                    await File.WriteAllBytesAsync(path, file);
                }
                return path;
            }
            catch (Exception)
            {

                throw new DontSaveFileException(fileNime, path);
            }

        }
        public string GetMD5Checksum(byte[] file)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(file);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
