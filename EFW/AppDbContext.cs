using EFW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW
{
    class AppDbContext :DbContext
    {
        public AppDbContext() : base("sqlConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
