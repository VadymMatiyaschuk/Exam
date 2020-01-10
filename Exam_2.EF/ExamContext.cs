using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Exam_2.EF
{
    class ExamContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(p => p.Street).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(128);
            modelBuilder.Entity<Address>().HasKey(p => p.CityId);
        }
    }
}
