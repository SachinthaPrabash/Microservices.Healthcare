using SLIIT.MTIT.HospitalService.Doctor.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Doctor.Model
{
    public interface IDoctor
    {
        Task<IEnumerable<doctorInfo>> GetDoctors();
        Task<doctorInfo> GetDoctor(int DoctorId);
        Task<doctorInfo> AddDoctor(doctorInfo doctors);
        Task<doctorInfo> UpdateDoctor(doctorInfo doctors);
        Task DeleteDoctor(int DoctorId);
        
    }
}
