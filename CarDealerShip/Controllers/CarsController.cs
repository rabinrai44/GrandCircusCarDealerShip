using CarDealerShip.Domain.Data.Abstract;
using CarDealerShip.Domain.DomainModels;
using CarDealerShip.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealerShip.Controllers
{
    //RoutePrefix("api")]
    public class CarsController : ApiController
    {
        static readonly ICarService service = new CarService();

        [Route("api/cars")]
        public IEnumerable<Car> GetAllCars()
        {
            return service.GetAll();
        }

        //[Route("cars/{Id:guid}", Name = "CarById")]
        public Car GetCar(Guid id)
        {
            Car item = service.Get(id);

            if (item == null)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"No Car with ID = {id} exists")),
                    ReasonPhrase = "The given car ID was not found."
                };
                throw new HttpResponseException(response);
            }

            return item;
        }

        //[Route("cars/{make:alpha}")]
        public IEnumerable<Car> GetVehiclesByMake(string make)
        {
            return service.GetAll().Where(
                p => string.Equals(p.Make, make, StringComparison.OrdinalIgnoreCase));
        }

        //[Route("cars")]
        [HttpPost]
        public HttpResponseMessage PostVehicle(Car item)
        {
            item = service.Add(item);
            var response = Request.CreateResponse<Car>(HttpStatusCode.Created, item);

            string uri = Url.Link("VehicleInfoById", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //[Route("cars")]
        [HttpPut]
        public void PutVehicle(Guid Id, Car item)
        {
            item.Id = Id;
            if (!service.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //[Route("cars")]
        [HttpDelete]
        public void DeleteVehicle(Guid Id)
        {
            Car item = service.Get(Id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            service.Remove(Id);
        }
    }
}
