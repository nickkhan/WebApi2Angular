namespace WebAppDevQuiz.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppDevQuiz.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<WebAppDevQuiz.Models.CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarContext context)
        {
            List<Car> cars = new List<Car>();

            cars.Add(
             new Car()
             {
                 Manufacturer = "Mazda",
                 Model = "Mazda 6",
                 Year = 2016,
                 Color="Black",
                 PassengerSeatingCount = 4
             });

            cars.Add(
             new Car()
             {
                 Manufacturer = "Mazda",
                 Model = "Mazda 6",
                 Year = 2015,
                 Color = "Black",
                 PassengerSeatingCount = 4
             });

            cars.Add(
             new Car()
             {

                 Manufacturer = "Mazda",
                 Model = "Mazda 3",
                 Year = 2013,
                 Color = "White",
                 PassengerSeatingCount = 4
             });

            cars.Add(
             new Car()
             {

                 Manufacturer = "Honda",
                 Model = "Civic",
                 Year = 2015,
                 Color = "Red",
                 PassengerSeatingCount = 4
             });


            cars.Add(
             new Car()
             {

                 Manufacturer = "Honda",
                 Model = "Accord",
                 Year = 2016,
                 Color = "Gray",
                 PassengerSeatingCount = 4
             });

            context.Cars.AddRange(cars);

            base.Seed(context);
        }
    }
}
