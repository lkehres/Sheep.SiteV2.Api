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
    public class VaccinesController : Controller
    {
    private readonly SheepSiteV2Context db;

       public VaccinesController(SheepSiteV2Context db)
       {
           this.db = db;
       }
       [HttpGet]
       public IActionResult VaccineRecords()
       {
           return View(db.Vaccines);
       }
        //[Route("api/Vaccines")]
        //[Route("api/Vaccines/Index")]
        //private IEnumerable<Vaccine> GetVaccines()
        //{
          //  var vaccine = new List<Vaccine>();

            //vaccine.Add(new Vaccine(){
              //  vaccineID = 1,
                //vaccineName = "Sheep Flu",
                //vaccineDosage = "30 ml",
                //vaccineDate = default(DateTime),
                //vaccineComment = "for the strain of 2018"
           // });

            //vaccine.Add(new Vaccine(){
              //  vaccineID = 2,
                //vaccineName = "Sheep Cold",
                //vaccineDosage = "30 ml",
                //vaccineDate = default(DateTime),
                //vaccineComment = "for the strain of 2018"
           // });

            //return vaccine;
        //}
        //public IActionResult VaccineRecords()
        //{
          //  var vaccine = GetVaccines();
            //return View(vaccine);
        //}
    }
}
