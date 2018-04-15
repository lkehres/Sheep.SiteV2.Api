using System;
using System.Collections.Generic;
using Sheep.SiteV2.Api.Controllers;
using Sheep.SiteV2.Api.Models;

namespace Sheep.SiteV2.Api.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public DateTime sheepDOB { get; set; }
        public string sheepGender { get; set; }
    }
}
