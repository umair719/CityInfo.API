using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            //init seed data
            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Descriptoin = "The most vistied urban park in the United States."
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Descriptoin = "A 102-story skyscrapter located in Midtown Manhattan."
                        }
                    }
                },
                new City() {

                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {

                            Name = "Cathedral of Our Lady",
                            Descriptoin = "A Gothic sytle catherdral, concived by archtitects Jan and Pieter Appelmans"
                        },
                        new PointOfInterest()
                        {

                            Name = "Antwerp Central Station",
                            Descriptoin = "The finest example fo railway architecture in Belgium"
                        }
                    }
                },
                new City() {

                    Name = "Paris",
                    Description = "The one with the big tower.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Eiffel Tower",
                            Descriptoin = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Ei"
                        },
                        new PointOfInterest()
                        {
                            Name = "The Louvre",
                            Descriptoin = "the world's largest museam."
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
