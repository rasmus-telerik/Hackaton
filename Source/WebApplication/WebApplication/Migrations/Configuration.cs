namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication.Models.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!Roles.RoleExists("Dispatcher"))
            {
                Roles.CreateRole("Dispatcher");
            }

            if (!Roles.RoleExists("Worker"))
            {
                Roles.CreateRole("Worker");
            }

            if (!Roles.RoleExists("Customer"))
            {
                Roles.CreateRole("Customer");
            }

            if (!WebSecurity.UserExists("DispatcherGuy"))
                WebSecurity.CreateUserAndAccount(
                    "DispatcherGuy",
                    "manages",
                    new { EverliveGuid = new Guid() });

            if (!WebSecurity.UserExists("DeliveryGuy"))
                WebSecurity.CreateUserAndAccount(
                    "DeliveryGuy",
                    "delivers",
                    new { EverliveGuid = new Guid() });

            if (!WebSecurity.UserExists("JohnSmith"))
                WebSecurity.CreateUserAndAccount(
                    "JohnSmith",
                    "receives",
                    new { EverliveGuid = new Guid() });

            if (!WebSecurity.UserExists("Dragan"))
                WebSecurity.CreateUserAndAccount(
                    "Dragan",
                    "receives",
                    new { EverliveGuid = new Guid() });

            if (!Roles.GetRolesForUser("DispatcherGuy").Contains("Dispatcher"))
            {
                Roles.AddUsersToRoles(new[] { "DispatcherGuy" }, new[] { "Dispatcher" });
            }

            if (!Roles.GetRolesForUser("DeliveryGuy").Contains("Worker"))
            {
                Roles.AddUsersToRoles(new[] { "DeliveryGuy" }, new[] { "Worker" });
            }

            if (!Roles.GetRolesForUser("JohnSmith").Contains("Customer"))
            {
                Roles.AddUsersToRoles(new[] { "JohnSmith" }, new[] { "Customer" });
            }

            if (!Roles.GetRolesForUser("Dragan").Contains("Customer"))
            {
                Roles.AddUsersToRoles(new[] { "Dragan" }, new[] { "Customer" });
            }
        }
    }
}
