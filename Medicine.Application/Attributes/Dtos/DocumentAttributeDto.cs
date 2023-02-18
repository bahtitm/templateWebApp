namespace Medicine.Application.Attributes.Dtos
{
    public class DocumentAttributeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DocumentCartTypeId { get; set; }
        public bool IsRequired { get; set; }
    }
}
