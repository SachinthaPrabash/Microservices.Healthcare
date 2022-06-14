using Microsoft.EntityFrameworkCore;
using SLIIT.MTIT.HospitalService.Billing.Database;
using SLIIT.MTIT.HospitalService.Billing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Billing.Models
{
    public class HospitalBillingRepository : IBilling
    {
        private readonly DatabaseContext databaseContext;

        public HospitalBillingRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<BillingInfo> AddBilling(BillingInfo billings)
        {
            var result = await databaseContext.billings.AddAsync(billings);
            await databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteBilling(int BillingId)
        {
            var result = await databaseContext.billings
                .FirstOrDefaultAsync(e => e.BillingId == BillingId);

            if (result != null)
            {
                databaseContext.billings.Remove(result);
                await databaseContext.SaveChangesAsync();
            }
        }

        public async Task<BillingInfo> GetBilling(int BillingId)
        {
            return await databaseContext.billings
                .FirstOrDefaultAsync(e => e.BillingId == BillingId);
        }

        public async Task<IEnumerable<BillingInfo>> GetBillings()
        {
            return await databaseContext.billings.ToListAsync();
        }

        public async Task<BillingInfo> UpdateBilling(BillingInfo billing)
        {
            var result = await databaseContext.billings
                .FirstOrDefaultAsync(e => e.BillingId == billing.BillingId);

            if (result != null)
            {
                result.Total = billing.Total;
                result.Discount = billing.Discount;
                result.Discription = billing.Discription;
                


                await databaseContext.SaveChangesAsync();

                return result;

            }

            return null;
        }
    }
}
