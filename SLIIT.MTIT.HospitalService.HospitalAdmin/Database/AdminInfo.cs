using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Database
{
    public class AdminInfo
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CheckupName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CheckupPrice { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Discription { get; set; }

       

       
    }
}
