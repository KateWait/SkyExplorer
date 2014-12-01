using System.Collections.Generic;
using SkyExplorer1.Models;

namespace SkyExplorer1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SkyExplorer1.DAL.SkyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkyExplorer1.DAL.SkyContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Name = "Kate",
                    Surname = "Wait",
                    Email = "lama@op.pl",
                    Login = "KateWait",
                    Password = "abc",
                    Attachment = null,
                    BirthdayDate = DateTime.Parse("1993-09-01"),
                    CityName = "Kraków",
                    CreatedAccount = DateTime.Now,
                    Street = "Walska",
                    HomeNumber = 12,
                    TelephoneNumber = "23456789",
                    ConnectionString = null,
                    AccountType = null
                }
            };

            context.SaveChanges();
        }
    }
}
