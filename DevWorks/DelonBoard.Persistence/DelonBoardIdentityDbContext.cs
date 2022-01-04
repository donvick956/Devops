using DelonBoard.Entity;
using DelonBoard.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelonBoard.Persistence
{
    public class DelonBoardIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DelonBoardIdentityDbContext(DbContextOptions<DelonBoardIdentityDbContext> options) : base(options)
        {

        }

    }
}
