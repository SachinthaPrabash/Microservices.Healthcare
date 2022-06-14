using SLIIT.MTIT.HospitalService.HospitalAdmin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Model
{
    public interface IAdmin
    {
        Task<IEnumerable<AdminInfo>> GetAdmins();
        Task<AdminInfo> GetAdmin(int AdminId);
        Task<AdminInfo> AddAdmin(AdminInfo admins);
        Task<AdminInfo> UpdateAdmin(AdminInfo admins);
        Task DeleteAdmin(int AdminId);
        
    }
}
