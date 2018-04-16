using System;

namespace Sheep.SiteV2.Api.Models
{
    public class Treatment
    {
        public int treatmentID { get; set; }
        public int tAnimalId { get; set; }
        public string treatmentName { get; set; }
        public string treatmentDosage { get; set; }
        public DateTime treatmentDate { get; set; }
        public string treatmentComment { get; set; }
    }
}
