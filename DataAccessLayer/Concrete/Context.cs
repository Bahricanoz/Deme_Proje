using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MONSTER\\SQLEXPRESS; database=Deme_Project;  integrated security = true");
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories {get; set;}
        public DbSet<Customer> customers { get; set; }
        public DbSet<Job> jobs { get; set; }
    }
}
