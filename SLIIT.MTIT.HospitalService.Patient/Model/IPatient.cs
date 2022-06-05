using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Patient.Model
{
    public interface IPatient
    {
        Task<IEnumerable<patientInfo>> GetPatients();
        Task<patientInfo> GetPatient(int id);
        Task<patientInfo> AddPatient(patientInfo patients);
        Task<patientInfo> UpdatePatient(patientInfo patients);
        Task DeletePatient(int id);


    }
}
