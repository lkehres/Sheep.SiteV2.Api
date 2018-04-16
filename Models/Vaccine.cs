using System;

namespace Sheep.SiteV2.Api.Models
{
    public class Vaccine
    {
        public int vaccineID { get; set; }
        public int vAnimalId { get; set;}
        public string vaccineName { get; set; }
        public string vaccineDosage { get; set; }
        public DateTime vaccineDate { get; set; }
        public string vaccineComment { get; set; }
    }
}
