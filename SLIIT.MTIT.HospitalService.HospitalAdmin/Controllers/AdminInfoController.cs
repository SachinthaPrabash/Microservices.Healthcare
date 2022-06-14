using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLIIT.MTIT.HospitalService.HospitalAdmin.Model;
using SLIIT.MTIT.HospitalService.HospitalAdmin.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInfoController : ControllerBase
    {
        private readonly IAdmin iadmin;

        public AdminInfoController(IAdmin iadmin)
        {
            this.iadmin = iadmin;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetAdmins()
        {
            try
            {
                return Ok(await iadmin.GetAdmins());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating admin!!");
            }
        }


        // GET api/<ValuesController>/5
        [HttpGet("{AdminId:int}")]
        public async Task<ActionResult<AdminInfo>> GetAdmin(int AdminId)
        {
            try
            {
                var result = await iadmin.GetAdmin(AdminId);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating admin !!");
            }

        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<AdminInfo>> AddAdmin([FromBody] AdminInfo model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var createAdmin = await iadmin.AddAdmin(model);

                return CreatedAtAction(nameof(GetAdmin),
                    new { AdminId = createAdmin.AdminId }, createAdmin);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new admin!!");
            }
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{AdminId:int}")]
        public async Task<ActionResult<AdminInfo>> UpdateAdmin(int AdminId, [FromBody] AdminInfo model)
        {
            try
            {
                if (AdminId != model.AdminId)
                    return BadRequest("Employee ID mismatch");

                var updateAdmin = await iadmin.GetAdmin(AdminId);

                if (updateAdmin == null)
                {
                    return NotFound($"Admin with ID = {AdminId} not found");
                }

                return await iadmin.UpdateAdmin(model);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new Doctor!!");
            }
        }




        // DELETE api/<ValuesController>/5
        [HttpDelete("{AdminId:int}")]
        public async Task<ActionResult> DeleteAdmin(int AdminId)
        {
            try
            {
                var doctorDelete = await iadmin.GetAdmin(AdminId);

                if (doctorDelete == null)
                {
                    return NotFound($"Admin with id = {AdminId} not found");
                }

                await iadmin.DeleteAdmin(AdminId);

                return Ok($"Admin with id = {AdminId} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting new admin!!");
            }
        }


    }
}
