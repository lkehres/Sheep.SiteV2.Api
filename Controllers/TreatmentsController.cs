using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sheep.SiteV2.Api.Models;
using Sheep.SiteV2.Api.Data;

namespace Sheep.SiteV2.Api.Controllers
{

    public class TreatmentsController : Controller
    {
    
      private readonly SheepSiteV2Context db;
      public TreatmentsController(SheepSiteV2Context db)
        {
            this.db = db;

        }
        [Route("api/[controller]/[action]")]
       [HttpGet]
       public IActionResult GetTreatments()
       {
            return Ok(db.Treatments);
       }
       [HttpGet]
       public IActionResult TreatmentRecords()
       {
         return View(db.Treatments);
       }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpGet("{id}", Name="GetTreatment")]
        public IActionResult Get(int id)
        {
            var treatment = db.Treatments.Find(id);
            
            if(treatment == null)
            {
                return NotFound();
            }
            return Ok(treatment);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody]Treatment treatment)
        {
            if(treatment == null)
            {
                return BadRequest();
            }

            this.db.Treatments.Add(treatment);
            this.db.SaveChanges();

            return CreatedAtRoute("GetTreatment", new { id = treatment.treatmentID}, treatment);
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Treatment newTreatment)
        {
            if (newTreatment == null || newTreatment.treatmentID !=id)
            {
                return BadRequest();
            }
            var currentTreatment = this.db.Treatments.FirstOrDefault(x => x.treatmentID == id);

            if (currentTreatment == null)
            {
                return NotFound();
            }

            currentTreatment.tAnimalId = newTreatment.tAnimalId;
            currentTreatment.treatmentName = newTreatment.treatmentName;
            currentTreatment.treatmentDosage = newTreatment.treatmentDosage;
            currentTreatment.treatmentDate = newTreatment.treatmentDate;
            currentTreatment.treatmentComment = newTreatment.treatmentComment;

            this.db.Treatments.Update(currentTreatment);
            this.db.SaveChanges();

            return NoContent();
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var treatment = this.db.Treatments.FirstOrDefault(x => x.treatmentID == id);

            if (treatment == null)
            {
                return NotFound();
            }
            
            this.db.Treatments.Remove(treatment);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
