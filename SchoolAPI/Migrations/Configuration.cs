namespace SchoolAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolAPI.Models.ApplicationDbContext context)
        {
            context.Schools.Add(
                new Core.Domain.School
                {
                    SchoolName = "Default School",
                    Address = "Bangalore"
                });

            context.Students.Add(
                new Core.Domain.Student
                {
                    FirstName = "Chandra",
                    LastName = "Sekhhar",
                    SurName = "Satrasala",
                    DateOfBirth = new DateTime(1982, 2, 10),
                    School = context.Schools.FirstOrDefault()
                }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
