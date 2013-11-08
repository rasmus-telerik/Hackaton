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
            // ------------------------------------ INIT ----------------------------------
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);


            // ------------------------------------ ROLES ----------------------------------
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


            // ------------------------------------ DISPATCHERS ----------------------------------
            if (!WebSecurity.UserExists("Dispatcher_1"))
                WebSecurity.CreateUserAndAccount(
                    "Dispatcher_1",
                    "manages",
                    new { EverliveGuid = new Guid("7e5d6920-4863-11e3-b9be-c76c12ebd876") });

            if (!WebSecurity.UserExists("Dispatcher_2"))
                WebSecurity.CreateUserAndAccount(
                    "Dispatcher_2",
                    "manages",
                    new { EverliveGuid = new Guid("7ec070b0-4863-11e3-b9be-c76c12ebd876") });

            if (!WebSecurity.UserExists("Dispatcher_3"))
                WebSecurity.CreateUserAndAccount(
                    "Dispatcher_3",
                    "manages",
                    new { EverliveGuid = new Guid("7eee8590-4863-11e3-b9be-c76c12ebd876") });


            // ------------------------------------ WORKERS ----------------------------------
            if (!WebSecurity.UserExists("DeliveryGuy"))
                WebSecurity.CreateUserAndAccount(
                    "DeliveryGuy",
                    "delivers",
                    new { EverliveGuid = new Guid() });


            // ------------------------------------ CUSTOMERS ----------------------------------
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


            // ------------------------------------ ROLES DISPATCHERS ----------------------------------
            if (!Roles.GetRolesForUser("Dispatcher_1").Contains("Dispatcher"))
            {
                Roles.AddUsersToRoles(new[] { "Dispatcher_1" }, new[] { "Dispatcher" });
            }

            if (!Roles.GetRolesForUser("Dispatcher_2").Contains("Dispatcher"))
            {
                Roles.AddUsersToRoles(new[] { "Dispatcher_2" }, new[] { "Dispatcher" });
            }

            if (!Roles.GetRolesForUser("Dispatcher_3").Contains("Dispatcher"))
            {
                Roles.AddUsersToRoles(new[] { "Dispatcher_3" }, new[] { "Dispatcher" });
            }


            // ------------------------------------ ROLES OTHERS ----------------------------------
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
