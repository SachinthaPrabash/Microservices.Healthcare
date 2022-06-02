using Newtonsoft.Json;
using SLIIT.MTIT.Hospital.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SLIIT.MTIT.Hospital.Client.ServiceInvoker
{
    public class patientInfoServiceInvoker
    {

        private static readonly HttpClient client = new HttpClient();


        protected patientInfoServiceInvoker()
        {

        }


        public async static Task<List<patientInfoModel>> GetPatientDatails()
        {
            List<patientInfoModel> patientInfoList = new();
            Uri uri = new Uri("http://localhost:2267/patientInfo");

            var res = await client.GetAsync(uri);
            var rowres = res.Content.ReadAsStringAsync();
            patientInfoList = JsonConvert.DeserializeObject<List<patientInfoModel>>(rowres.Result.ToString());

            return patientInfoList;
        }
    }
}
