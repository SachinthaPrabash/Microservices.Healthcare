using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SLIIT.MTIT.Hospital.Client.ServiceInvoker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.Hospital.Client.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            List<string> patientList = new List<string>();
            var result = await  patientInfoServiceInvoker.GetPatientDatails();

            
            foreach (var item in result)
            {
                patientList.Add(item.id.ToString());
                patientList.Add(item.name);
                patientList.Add(item.sex);
                patientList.Add(item.bloudtype);
            }

            ViewData["PatientInfoList"] = patientList;

        }
    }
}
