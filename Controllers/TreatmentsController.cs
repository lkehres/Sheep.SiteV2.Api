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
        
    }
}
