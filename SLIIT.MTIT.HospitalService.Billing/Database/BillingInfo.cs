using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Billing.Database
{
    public class BillingInfo
    {
        [Key]
        public int BillingId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Total { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Discount { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Discription { get; set; }

    }
}
