﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
       }
       [HttpGet]
       public IActionResult Index()
       {
           return View(db.Animals);
       }
       // private IEnumerable<Animal> GetAnimals()
        //{
          //  var animal = new List<Animal>();

            //animal.Add(new Animal(){
              //  Id = 1,
                //sheepDOB = default(DateTime),
              //  sheepGender = "F"
            //});

            //animal.Add(new Animal(){
              //  Id = 2,
                //sheepDOB = default(DateTime),
                //sheepGender = "M"
            //});

            //return animal;
        //}
        //public IActionResult Index()
        //{
            //var animal = GetAll();
          //  return View(animal);
        //}
    }
}
