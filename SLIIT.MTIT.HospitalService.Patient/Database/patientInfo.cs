using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Patient
{
    public class patientInfo
    {
        public int id { get; set; }
       
        [Required]
        public string name { get; set; }

        public string address { get; set; }

        [Required]
        public string nationid { get; set; }

        public string sex { get; set; }

        public int phNum { get; set; }

        public string bloudtype { get; set; }
    }
}
