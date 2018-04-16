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
       [HttpGet]
       public IActionResult PregnancyRecords()
       {
           return View(db.Pregnancies);
       }
      // private IEnumerable<Pregnancy> GetPregnancies()
        //{
          //  var pregnancy = new List<Pregnancy>();

            //pregnancy.Add(new Pregnancy(){
              //  pregnancyID = 1,
                //conceptionDate = "N/A",
                //estBirth = "N/A",
                //actBirth = "N/A",
                //numberOfBabies = 6,
                //pregnancyComment = "babies all came out healthy"
            //});

            //pregnancy.Add(new Pregnancy(){
              //  pregnancyID = 2,
                //conceptionDate = "N/A",
                //estBirth = "N/A",
                //actBirth = "N/A",
                //numberOfBabies = 3,
                //pregnancyComment = "babies all came out healthy"
            //});

            //return pregnancy;
        //}
        //public IActionResult PregnancyRecords()
        //{
          //  var pregnancy = GetPregnancies();
            //return View(pregnancy);
        //}
    }
}
