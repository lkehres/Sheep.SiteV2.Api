using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheep.SiteV2.Api.Models;
using Sheep.SiteV2.Api.Data;

namespace Sheep.SiteV2.Api.Controllers
{
    
    public class PregnanciesController : Controller
    {
    
      private readonly SheepSiteV2Context db;
      public PregnanciesController(SheepSiteV2Context db)
        {
            this.db = db;

        }
        [Route("api/[controller]/[action]")]
       [HttpGet]
       public IActionResult Get()
       {
            return Ok(db.Pregnancies);
       }
       [HttpGet]
       public IActionResult PregnancyRecords()
       {
         return View(db.Pregnancies);
       }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpGet("{id}", Name="GetPregnancy")]
        public IActionResult Get(int id)
        {
            var pregnancy = db.Pregnancies.Find(id);
            
            if(pregnancy == null)
            {
                return NotFound();
            }
            return Ok(pregnancy);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody]Pregnancy pregnancy)
        {
            if(pregnancy == null)
            {
                return BadRequest();
            }

            this.db.Pregnancies.Add(pregnancy);
            this.db.SaveChanges();

            return CreatedAtRoute("GetPregnancy", new { id = pregnancy.pregnancyID}, pregnancy);
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Pregnancy newPregnancy)
        {
            if (newPregnancy == null || newPregnancy.pregnancyID !=id)
            {
                return BadRequest();
            }
            var currentPregnancy = this.db.Pregnancies.FirstOrDefault(x => x.pregnancyID == id);

            if (currentPregnancy == null)
            {
                return NotFound();
            }

            currentPregnancy.pregnancyID = newPregnancy.pregnancyID;
            currentPregnancy.conceptionDate = newPregnancy.conceptionDate;
            currentPregnancy.estBirth = newPregnancy.estBirth;
            currentPregnancy.actBirth = newPregnancy.actBirth;
            currentPregnancy.numberOfBabies = newPregnancy.numberOfBabies;
            currentPregnancy.pregnancyComment = newPregnancy.pregnancyComment;

            this.db.Pregnancies.Update(currentPregnancy);
            this.db.SaveChanges();

            return NoContent();
        }

        [Route("api/[controller]/[action]/{id?}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pregnancy = this.db.Pregnancies.FirstOrDefault(x => x.pregnancyID == id);

            if (pregnancy == null)
            {
                return NotFound();
            }
            
            this.db.Pregnancies.Remove(pregnancy);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}
