using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLIIT.MTIT.HospitalService.StaffManagment.Model;
using SLIIT.MTIT.HospitalService.StaffManagment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLIIT.MTIT.HospitalService.StaffManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class staffManagmentController : ControllerBase
    {
        private readonly IStaffManagment iStaffManagment;

        public staffManagmentController(IStaffManagment iStaffManagment)
        {
            this.iStaffManagment = iStaffManagment;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetStaffDetails()
        {
            try
            {
                return Ok(await iStaffManagment.GetStaffDetails());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retriving staff!!");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<staffMnagmentInfo>> GetStaffEmployeeDetail(int id)
        {
            try
            {
                var result = await iStaffManagment.GetStaffEmployeeDetail(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrivig staff member !!");
            }

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<staffMnagmentInfo>> AddStaffMember([FromBody] staffMnagmentInfo model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var createPatient = await iStaffManagment.AddStaffMember(model);

                return CreatedAtAction(nameof(GetStaffEmployeeDetail),
                    new { id = createPatient.id }, createPatient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new staff member!!");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<staffMnagmentInfo>> UpdateStaffMember(int id, staffMnagmentInfo model)
        {
            try
            {
                if (id != model.id)
                    return BadRequest("Employee ID mismatch");

                var updateStaff = await iStaffManagment.GetStaffEmployeeDetail(id); 

                if (updateStaff == null)
                {
                    return NotFound($"staff with ID = {id} not found");
                }

                return await iStaffManagment.UpdateStaffMember(model);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new staff member!!");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStafMember(int id)
        {
            try
            {
                var pationDelete = await iStaffManagment.GetStaffEmployeeDetail(id);

                if (pationDelete == null)
                {
                    return NotFound($"Pation with id = {id} not found");
                }

                await iStaffManagment.DeleteStafMember(id);

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
