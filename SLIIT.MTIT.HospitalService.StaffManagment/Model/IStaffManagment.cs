using SLIIT.MTIT.HospitalService.StaffManagment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.StaffManagment.Model
{
    public interface IStaffManagment
    {
        Task<IEnumerable<staffMnagmentInfo>> GetStaffDetails();
        Task<staffMnagmentInfo> GetStaffEmployeeDetail(int id);
        Task<staffMnagmentInfo> AddStaffMember(staffMnagmentInfo staff);
        Task<staffMnagmentInfo> UpdateStaffMember(staffMnagmentInfo staff);
        Task DeleteStafMember(int id);
       
    }
}
