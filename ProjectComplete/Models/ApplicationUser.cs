using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectComplete.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Adding new custom property
        [Display(Name ="Fulll Name")]
        public string FullName { get; set; }

        List<Collection> Collections { get; set; }
    }
}
