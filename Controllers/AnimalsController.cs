using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sheep.SiteV2.Api.Models;
using Sheep.SiteV2.Api.Data;

namespace Sheep.SiteV2.Api.Controllers
{

    public class AnimalsController : Controller
    {
    
      private readonly SheepSiteV2Context db;
      public AnimalsController(SheepSiteV2Context db)
        {
            this.db = db;

            if(this.db.Animals.Count() == 0)
            {
                this.db.Animals.Add(new Animal {
                    Id = 1,
                    sheepDOB = default(DateTime),
                    sheepGender = "F"
                });
                
                this.db.Animals.Add(new Animal
                {
                    Id = 2,
                    sheepDOB = default(DateTime),
                    sheepGender = "M"
                });

                this.db.SaveChanges();
            }
        }
        [Route("api/[controller]/[action]")]
       [HttpGet]
       public IActionResult GetAnimals()
       {
            return Ok(db.Animals);
       }
       [HttpGet]
       public IActionResult Index()
       {
         return View(db.Animals);
       }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpGet("{id}", Name="GetAnimal")]
        public IActionResult Get(int id)
        {
            var animal = db.Animals.Find(id);
            
            if(animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody]Animal animal)
        {
            if(animal == null)
            {
                return BadRequest();
            }

            this.db.Animals.Add(animal);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAnimal", new { id = animal.Id}, animal);
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Animal newAnimal)
        {
            if (newAnimal == null || newAnimal.Id !=id)
            {
                return BadRequest();
            }
            var currentAnimal = this.db.Animals.FirstOrDefault(x => x.Id == id);

            if (currentAnimal == null)
            {
                return NotFound();
            }

            currentAnimal.sheepDOB = newAnimal.sheepDOB;
            currentAnimal.sheepGender = newAnimal.sheepGender;

            this.db.Animals.Update(currentAnimal);
            this.db.SaveChanges();

            return NoContent();
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = this.db.Animals.FirstOrDefault(x => x.Id == id);

            if (animal == null)
            {
                return NotFound();
            }
            
            this.db.Animals.Remove(animal);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
