using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Patient.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }


        public DbSet<patientInfo> patients { get; set; }



      //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //  {
      //      optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-UCQ3NA3T\SQLEXPRESS;Initial Catalog=MTIT_HealthCare;Integrated Security=True");
      //  }
    }
}
