﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppDevQuiz.Models;

namespace WebAppDevQuiz.Controllers
{
    [RoutePrefix("api")]
    public class CarsController : ApiController
    {
        private CarContext context = new CarContext();

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this.context.Dispose();
            }

            base.Dispose(disposing);
        }

        
        // Get /api/Cars/carid
        [HttpGet]
        [Route("cars/{carId:int}")]
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCars(int carId)
        {
            var car = context.Cars.Where(x => x.CarId == carId).FirstOrDefault<Car>();

            if (car == null)
                return this.NotFound();

            return this.Ok<Car>(car);
        }


        // Get /api/Cars
        [HttpGet]
        [Route("cars/")]
        [ResponseType(typeof(List<Car>))]
        public IHttpActionResult GetCars()
        {
            var car = context.Cars.ToList<Car>();

            if (car == null)
                return this.NotFound();

            return this.Ok<List<Car>>(car);
        }

        [HttpDelete]
        [Route("car/delete/{carId:int}")]
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int carId)
        {
            var car = context.Cars.Where(x => x.CarId == carId).FirstOrDefault<Car>();
            
            if (car == null)
                return this.NotFound();
            else
            {
                context.Cars.Remove(car);
                context.SaveChanges();
                return this.Ok();
            }
        }


        [HttpPost]
        [Route("car/{carId:int}")]
        [ResponseType(typeof(Car))]
        public IHttpActionResult PutCar(int carId, Car car)
        {
            if (context.Cars.Find(carId) == null)
                return this.NotFound();
            else
            {
                context.Cars.Remove(car);
                context.Cars.Add(car);
                context.SaveChanges();

                return this.Ok<Car>(car);
            }
        }

        [HttpPost]
        [Route("car/{carId:int}")]
        [ResponseType(typeof(Car))]
        public IHttpActionResult CreateCar(Car car)
        {
            context.Cars.Add(car);
            try {
                context.SaveChanges();
                return this.Ok<Car>(car);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return this.InternalServerError(ex);
            }
        }

    }
}
