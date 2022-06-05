using Microsoft.AspNetCore.Mvc;
using SLIIT.MTIT.HospitalService.Patient.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLIIT.MTIT.HospitalService.Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class patientInfoController : ControllerBase
    {
        DatabaseContext db;
        public patientInfoController()
        {
            db = new DatabaseContext();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<patientInfo> Get()
        {
            return db.patients.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public patientInfo Get(int id)
        {
            return db.patients.Find(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] patientInfo model)
        {
            try
            {
                db.patients.Add(model);
                db.SaveChanges();

                return StatusCode(201,model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] patientInfo model)
        {
            try
            {
                if (id != model.id)
                    return BadRequest("Employee ID mismatch");

                db.Update(model);
                db.SaveChanges();

                return StatusCode(201, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            patientInfo prodItem = db.patients.Where(p => p.id == id).FirstOrDefault();
            //var findpatientDetails = db.patients.Find(id);
            db.Remove(prodItem);
            db.SaveChanges();

            return StatusCode(201);
        }
    }
}
