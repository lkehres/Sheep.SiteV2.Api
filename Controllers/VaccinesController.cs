using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sheep.SiteV2.Api.Models;
using Sheep.SiteV2.Api.Data;

namespace Sheep.SiteV2.Api.Controllers
{

    public class VaccinesController : Controller
    {
    
      private readonly SheepSiteV2Context db;
      public VaccinesController(SheepSiteV2Context db)
        {
            this.db = db;

        }
        [Route("api/[controller]/[action]")]
       [HttpGet]
       public IActionResult GetVaccines()
       {
            return Ok(db.Vaccines);
       }
       [HttpGet]
       public IActionResult VaccineRecords()
       {
         return View(db.Vaccines);
       }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpGet("{id}", Name="GetVaccine")]
        public IActionResult Get(int id)
        {
            var vaccine = db.Vaccines.Find(id);
            
            if(vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody]Vaccine vaccine)
        {
            if(vaccine == null)
            {
                return BadRequest();
            }

            this.db.Vaccines.Add(vaccine);
            this.db.SaveChanges();

            return CreatedAtRoute("GetVaccine", new { id = vaccine.vaccineID}, vaccine);
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Vaccine newVaccine)
        {
            if (newVaccine == null || newVaccine.vaccineID !=id)
            {
                return BadRequest();
            }
            var currentVaccine = this.db.Vaccines.FirstOrDefault(x => x.vaccineID == id);

            if (currentVaccine == null)
            {
                return NotFound();
            }

            currentVaccine.vAnimalId = newVaccine.vAnimalId;
            currentVaccine.vaccineName = newVaccine.vaccineName;
            currentVaccine.vaccineDosage = newVaccine.vaccineDosage;
            currentVaccine.vaccineDate = newVaccine.vaccineDate;
            currentVaccine.vaccineComment = newVaccine.vaccineComment;

            this.db.Vaccines.Update(currentVaccine);
            this.db.SaveChanges();

            return NoContent();
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vaccine = this.db.Vaccines.FirstOrDefault(x => x.vaccineID == id);

            if (vaccine == null)
            {
                return NotFound();
            }
            
            this.db.Vaccines.Remove(vaccine);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
