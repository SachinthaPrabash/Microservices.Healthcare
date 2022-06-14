using Microsoft.EntityFrameworkCore;
using SLIIT.MTIT.HospitalService.Doctor.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Doctor.Model
{
    public class DoctorRepository : IDoctor
    {
        private readonly DatabaseContext databaseContext;

        public DoctorRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<doctorInfo> AddDoctor(doctorInfo doctors)
        {
            var result = await databaseContext.doctors.AddAsync(doctors);
            await databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteDoctor(int DoctorId)
        {
            var result = await databaseContext.doctors
                .FirstOrDefaultAsync(e => e.DoctorId == DoctorId);

            if (result != null)
            {
                databaseContext.doctors.Remove(result);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<doctorInfo> GetDoctor(int DoctorId)
        {
            return await databaseContext.doctors
                .FirstOrDefaultAsync(e => e.DoctorId == DoctorId);
        }

        public async Task<IEnumerable<doctorInfo>> GetDoctors()
        {
            return await databaseContext.doctors.ToListAsync();
        }

        public async Task<doctorInfo> UpdateDoctor(doctorInfo doctor)
        {
            var result = await databaseContext.doctors
                .FirstOrDefaultAsync(e => e.DoctorId == doctor.DoctorId);

            if (result != null)
            {
                result.DoctorfirstName = doctor.DoctorfirstName;
                result.DoctorLastName = doctor.DoctorLastName;
                result.Address = doctor.Address;
                result.phone = doctor.phone;
                result.specialization = doctor.specialization;
                result.registercode = doctor.registercode;
              

                await databaseContext.SaveChangesAsync();

                return result;

            }

            return null;
        }

    }
}
