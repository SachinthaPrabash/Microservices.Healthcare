using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Doctor.Database
{
    public class doctorInfo
    {
        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DoctorfirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DoctorLastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string specialization { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string registercode { get; set; }

       
    }
}

