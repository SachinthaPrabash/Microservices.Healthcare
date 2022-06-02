using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLIIT.MTIT.HospitalService.Patient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class patientInfoController : ControllerBase
    {
        private static readonly string[] names = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] gender = new[]
        {
            "Male", "Female"
        };

        private static readonly string[] blouds = new[]
        {
            "A+", "B", "O", "AB"
        };

        private readonly ILogger<patientInfoController> _logger;

        public patientInfoController(ILogger<patientInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<patientInfo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new patientInfo
            {
             
                id= rng.Next(1, 100),
                name = names[rng.Next(names.Length)],
                sex = gender[rng.Next(gender.Length)],
                bloudtype = blouds[rng.Next(blouds.Length)]
            })
            .ToArray();
        }
    }
}
