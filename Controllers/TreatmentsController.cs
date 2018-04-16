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
    public class TreatmentsController : Controller
    {
    private readonly SheepSiteV2Context db;

       public TreatmentsController(SheepSiteV2Context db)
       {
           this.db = db;
       }
       [HttpGet]
       public IActionResult TreatmentRecords()
       {
           return View(db.Treatments);
       }
        //[Route("api/Treatments")]
        //[Route("api/Treatments/Index")]
        //private IEnumerable<Treatment> GetTreatments()
        //{
          //  var treatment = new List<Treatment>();

            //treatment.Add(new Treatment(){
              //  treatmentID = 1,
                //treatmentName = "Sheep Flu",
                //treatmentDosage = "30 ml",
                //treatmentDate = default(DateTime),
                //treatmentComment = "for the strain of 2018"
            //});

            //treatment.Add(new Treatment(){
              //  treatmentID = 2,
               // treatmentName = "Sheep Cold",
                //treatmentDosage = "30 ml",
                //treatmentDate = default(DateTime),
                //treatmentComment = "for the strain of 2018"
            //});

            //return treatment;
        //}
        //public IActionResult TreatmentRecords()
        //{
          //  var treatment = GetTreatments();
            //return View(treatment);
        //}
    }
}
