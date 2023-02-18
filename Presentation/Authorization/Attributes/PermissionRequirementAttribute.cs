using Medicine.Authorization.Filters;
using Medicine.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.Authorization.Attributes
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(ClaimType claim, ClaimValue permission)
            : base(typeof(PermissionRequirementFilter))
        {
            Arguments = new object[] { claim, permission };
        }
    }
}
