using System;

namespace Sheep.SiteV2.Api.Models
{
    public class Pregnancy
    {
        public int pregnancyID { get; set; }
        public string conceptionDate { get; set; }
        public string estBirth { get; set; }
        public string actBirth { get; set; }
        public int numberOfBabies { get; set; }
        public string pregnancyComment { get; set; }
    }
}
