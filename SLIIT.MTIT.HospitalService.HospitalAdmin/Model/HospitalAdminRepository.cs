using Microsoft.EntityFrameworkCore;
using SLIIT.MTIT.HospitalService.HospitalAdmin.Database;
using SLIIT.MTIT.HospitalService.HospitalAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Models
{
    public class HospitalAdminRepository : IAdmin
    {
        private readonly DatabaseContext databaseContext;

        public HospitalAdminRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<AdminInfo> AddAdmin(AdminInfo admins)
        {
            var result = await databaseContext.admins.AddAsync(admins);
            await databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAdmin(int AdminId)
        {
            var result = await databaseContext.admins
                .FirstOrDefaultAsync(e => e.AdminId == AdminId);

            if (result != null)
            {
                databaseContext.admins.Remove(result);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<AdminInfo> GetAdmin(int AdminId)
        {
            return await databaseContext.admins
                .FirstOrDefaultAsync(e => e.AdminId == AdminId);
        }

        public async Task<IEnumerable<AdminInfo>> GetAdmins()
        {
            return await databaseContext.admins.ToListAsync();
        }

        public async Task<AdminInfo> UpdateAdmin(AdminInfo admin)
        {
            var result = await databaseContext.admins
                .FirstOrDefaultAsync(e => e.AdminId == admin.AdminId);

            if (result != null)
            {
                result.CheckupName = admin.CheckupName;
                result.CheckupPrice = admin.CheckupPrice;
                result.Discription = admin.Discription;
                


                await databaseContext.SaveChangesAsync();

                return result;

            }

            return null;
        }
    }
}
