using SLIIT.MTIT.HospitalService.Billing.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Billing.Model
{
    public interface IBilling
    {
        Task<IEnumerable<BillingInfo>> GetBillings();
        Task<BillingInfo> GetBilling(int BillingId);
        Task<BillingInfo> AddBilling(BillingInfo billings);
        Task<BillingInfo> UpdateBilling(BillingInfo billings);
        Task DeleteBilling(int BillingId);
        
    }
}
