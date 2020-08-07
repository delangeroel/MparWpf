using Microsoft.EntityFrameworkCore;
using MparWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWpf.Controllers.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Demo> Demo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=MparWpf;trusted_connection=true;Integrated Security=True;");
            //optionsBuilder.UseSqlite("DataSource=D:\\Temp\\MparWpf.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .Property(b => b.CreateDate)
                .HasDefaultValueSql("getutcdate()")  
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Loan>()
                .Property(b => b.ChangeDate)
                .HasDefaultValueSql("getutcdate()")
                .ValueGeneratedOnUpdate();
        }

        public override int SaveChanges()
        {
            // get entries that are being Added or Updated
            var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            var identityName = "";
            var now = DateTime.UtcNow;

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditableEntity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName ?? "unknown";
                    entity.CreatedDate = now;
                }

                entity.UpdatedBy = identityName ?? "unknown";
                entity.UpdatedDate = now;
            }

            return base.SaveChanges();
        }
    }

}

