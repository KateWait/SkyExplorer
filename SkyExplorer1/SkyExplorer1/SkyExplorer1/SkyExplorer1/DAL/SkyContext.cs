using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SkyExplorer1.Models;

namespace SkyExplorer1.DAL
{
    public class SkyContext : DbContext
    {
        public SkyContext() : base("SkyContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employees> Employeeses { get; set; }
        public DbSet<DatabaseType> DatabaseTypes { get; set; }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}