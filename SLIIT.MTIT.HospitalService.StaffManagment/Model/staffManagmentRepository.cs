using Microsoft.EntityFrameworkCore;
using SLIIT.MTIT.HospitalService.StaffManagment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.StaffManagment.Model
{
    public class staffManagmentRepository : IStaffManagment
    {
        private readonly DatabaseContext databaseContext;

        public staffManagmentRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<staffMnagmentInfo> AddStaffMember(staffMnagmentInfo staff)
        {
            var result = await databaseContext.staff.AddAsync(staff);
            await databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStafMember(int id)
        {
            var result = await databaseContext.staff
                .FirstOrDefaultAsync(e => e.id == id);

            if (result != null)
            {
                databaseContext.staff.Remove(result);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<staffMnagmentInfo> GetStaffEmployeeDetail(int id)
        {
            return await databaseContext.staff
                .FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task<IEnumerable<staffMnagmentInfo>> GetStaffDetails()
        {
            return await databaseContext.staff.ToListAsync();
        }

        public async Task<staffMnagmentInfo> UpdateStaffMember(staffMnagmentInfo staff)
        {
            var result = await databaseContext.staff
                .FirstOrDefaultAsync(e => e.id == staff.id);

            if (result != null)
            {
                result.FirstName = staff.FirstName;
                result.LastName = staff.LastName;
                result.address = staff.address;
                result.nationid = staff.nationid;
                result.sex = staff.sex;
                result.phNum = staff.phNum;
                result.Designation = staff.Designation;

                await databaseContext.SaveChangesAsync();

                return result;

            }

            return null;
        }

      
    }
}

