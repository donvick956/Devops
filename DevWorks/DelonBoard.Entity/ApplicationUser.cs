using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Entity
{
   public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }

       // public string Password { get; set; }

    //   public DelonRoles Roles { get; set; }
    }
}
