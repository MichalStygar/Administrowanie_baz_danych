namespace NowaAplikacja.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NowaAplikacja.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NowaAplikacja.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NowaAplikacja.Models.ApplicationDbContext";
        }

        protected override void Seed(NowaAplikacja.Models.ApplicationDbContext context)
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "Teacher", "Student" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            var UserManager = new UserManager<ApplicationUser>(new
            UserStore<ApplicationUser>(context));
            UserManager.AddToRole("2a7a51b8-8f00-4f2b-80c0-764b540e5927", "Admin");
        }
    }
}
