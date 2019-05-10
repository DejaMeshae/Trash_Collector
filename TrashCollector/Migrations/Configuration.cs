namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //context.customers.AddOrUpdate(
            //    new Models.Customers { FirstName = "Liam", LastName = "Smith", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Sunday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Larry", LastName = "Gold", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Monday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Billy", LastName = "Nee", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Tuesday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Riley", LastName = "Duncan", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Wednesday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Gina", LastName = "Hugh", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Thursday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Eli", LastName = "Williams", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Friday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false },
            //    new Models.Customers { FirstName = "Nia", LastName = "Sam", City = "Waukesha", State = "WI", ZipCode = 53188, PickUpdate = "Saturday", StopPickUp = new DateTime(2019, 5, 31), TempSuspendStart = new DateTime(2019, 5, 11), StartPickUp = new DateTime(2019, 5, 1), OneTimePickUpDate = new DateTime(2019, 5, 15), PickedUp = false }
                
            //    );

        }
    }
}
