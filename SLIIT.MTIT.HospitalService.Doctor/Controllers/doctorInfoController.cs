using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLIIT.MTIT.HospitalService.Doctor.Database;
using SLIIT.MTIT.HospitalService.Doctor.Model;
using SLIIT.MTIT.HospitalService.Doctor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLIIT.MTIT.HospitalService.Doctor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class doctorInfoController : ControllerBase
    {
        private readonly IDoctor idoctor;

        public doctorInfoController(IDoctor idoctor)
        {
            this.idoctor = idoctor;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetDoctors()
        {
            try
            {
                return Ok(await idoctor.GetDoctors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating doctor!!");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{DoctorId:int}")]
        public async Task<ActionResult<doctorInfo>> GetDoctor(int DoctorId)
        {
            try
            {
                var result = await idoctor.GetDoctor(DoctorId);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating doctor !!");
            }

        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<doctorInfo>> AddDoctor([FromBody] doctorInfo model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var createDoctor = await idoctor.AddDoctor(model);

                return CreatedAtAction(nameof(GetDoctor),
                    new { DoctorId = createDoctor.DoctorId }, createDoctor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new doctor!!");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{DoctorId:int}")]
        public async Task<ActionResult<doctorInfo>> UpdateDoctor(int DoctorId, [FromBody] doctorInfo model)
        {
            try
            {
                if (DoctorId != model.DoctorId)
                    return BadRequest("Employee ID mismatch");

                var updateDocto = await idoctor.GetDoctor(DoctorId);

                if (updateDocto == null)
                {
                    return NotFound($"Doctor with ID = {DoctorId} not found");
                }

                return await idoctor.UpdateDoctor(model);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new Doctor!!");
            }
        }


        


        // DELETE api/<ValuesController>/5
        [HttpDelete("{DoctorId:int}")]
        public async Task<ActionResult> DeleteDoctor(int DoctorId)
        {
            try
            {
                var doctorDelete = await idoctor.GetDoctor(DoctorId);

                if (doctorDelete == null)
                {
                    return NotFound($"Doctor with id = {DoctorId} not found");
                }

                await idoctor.DeleteDoctor(DoctorId);

                return Ok($"Doctor with id = {DoctorId} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting new doctor!!");
            }
        }


       
    }
}
