using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCompanyDataAccess.Model
{
    public  class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; } 
    }
}
