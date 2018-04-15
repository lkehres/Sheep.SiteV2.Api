using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheep.SiteV2.Api.Models;

namespace Sheep.SiteV2.Api.Controllers
{
    public class AnimalsController : Controller
    {

        private IEnumerable<Animal> GetAnimals()
        {
            var animal = new List<Animal>();

            animal.Add(new Animal(){
                Id = 1,
                sheepDOB = default(DateTime),
                sheepGender = "F"
            });

            animal.Add(new Animal(){
                Id = 2,
                sheepDOB = default(DateTime),
                sheepGender = "M"
            });

            return animal;
        }
        public IActionResult Index()
        {
            var animal = GetAnimals();
            return View(animal);
        }
    }
}
