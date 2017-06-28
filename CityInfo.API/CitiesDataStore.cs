﻿using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        // Static object which instantiates the class and return List<CityDto> object
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            // init dummy data - creates a data strucuture 
            Cities = new List<CityDto>()
            {
                new CityDto() {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with the big park.",
                    PointsOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visted urban part in the United States"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan"
                        }
                    }
                },
                new CityDto() {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A Gothic sytle catherdral, concived by archtitects Jan and Pieter Appelmans"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 4,
                            Name = "Antwerp Central Station",
                            Description = "The finest example fo railway architecture in Belgium"
                        }
                    }
                },
                new CityDto() {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with the big tower.",
                    PointsOfIntrest = new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Ei"
                        },
                        new PointOfIntrestDto()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "the world's largest museam."
                        }
                    }
                }
            };
        }
    }
}
