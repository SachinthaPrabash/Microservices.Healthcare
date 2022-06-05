using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLIIT.MTIT.HospitalService.Patient.Database;
using SLIIT.MTIT.HospitalService.Patient.Model;
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
        private readonly IPatient ipatient;
        
        public patientInfoController(IPatient ipatient)
        {
            this.ipatient = ipatient;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetPatients()
        {
            try
            {
                return Ok(await ipatient.GetPatients());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating patient!!");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<patientInfo>> GetPatient(int id)
        {
            try
            {
                var result = await ipatient.GetPatient(id);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating patient !!");
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<patientInfo>> AddPatient([FromBody] patientInfo model)
        {
            try
            { 
                if(model == null)
                {
                    return BadRequest();
                }

                var createPatient = await ipatient.AddPatient(model);

                return CreatedAtAction(nameof(GetPatient),
                    new { id = createPatient.id }, createPatient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new patient!!");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<patientInfo>> UpdatePatient(int id, [FromBody] patientInfo model)
        {
            try
            {
                if (id != model.id)
                    return BadRequest("Employee ID mismatch");

                var updatePation = await ipatient.GetPatient(id);

                if(updatePation == null)
                {
                    return NotFound($"Patient with ID = {id} not found");
                }

                return await ipatient.UpdatePatient(model);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new patient!!");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                var pationDelete = await ipatient.GetPatient(id);

                if(pationDelete == null)
                {
                    return NotFound($"Pation with id = {id} not found");
                }

                await ipatient.DeletePatient(id);

                return Ok($"Pation with id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting new patient!!");
            }
        }
    }
}
