using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    // UK - add the route attribute at the controller level so we dont have to define this on all the actions
    [Route("api/cities")]
    //[Route("api/[controller]")] <- this can also be used, but it can be problematic if you rename the cotroller.
    public class CitiesController : Controller
    {
        // UK - We want this method to be invoked when calling /api/cities
        // UK - this is redundant when Route attribute is defined at the Controller level
        // [HttpGet("api/cities")]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
            // UK - Removed the JSON hard text and updated to utilize an static property in the Cities object
            // var temp = new JsonResult(CitiesDataStore.Current.Cities);
            // temp.StatusCode = 200;
            // return temp;
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }
}
