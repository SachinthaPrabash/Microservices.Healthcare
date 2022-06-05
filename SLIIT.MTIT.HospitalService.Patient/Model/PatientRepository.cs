
using Microsoft.EntityFrameworkCore;
using SLIIT.MTIT.HospitalService.Patient.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Patient.Model
{
    public class PatientRepository : IPatient
    {
        private readonly DatabaseContext databaseContext;

        public PatientRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<patientInfo> AddPatient(patientInfo patients)
        {
            var result = await databaseContext.patients.AddAsync(patients);
            await databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePatient(int id)
        {
            var result = await databaseContext.patients
                .FirstOrDefaultAsync(e => e.id == id);

            if(result != null)
            {
                databaseContext.patients.Remove(result);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<patientInfo> GetPatient(int id)
        {
            return await databaseContext.patients
                .FirstOrDefaultAsync(e => e.id == id); 
        }

        public async Task<IEnumerable<patientInfo>> GetPatients()
        {
            return await databaseContext.patients.ToListAsync();
        }

        public async Task<patientInfo> UpdatePatient(patientInfo patient)
        {
            var result = await databaseContext.patients
                .FirstOrDefaultAsync(e => e.id == patient.id);

            if(result != null)
            {
                result.name = patient.name;
                result.address = patient.address;
                result.nationid = patient.nationid;
                result.sex = patient.sex;
                result.phNum = patient.phNum;
                result.bloudtype = patient.bloudtype;

                await databaseContext.SaveChangesAsync();

                return result;

            }

            return null;
        }
    }
}
