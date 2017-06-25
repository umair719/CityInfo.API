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
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new {id = 1, Name="New York City"},
                new {id = 2, Name="Antwerp"}
            });
        }
    }
}
