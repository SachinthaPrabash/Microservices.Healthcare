using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLIIT.MTIT.HospitalService.Billing.Database;
using SLIIT.MTIT.HospitalService.Billing.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLIIT.MTIT.HospitalService.HospitalAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInfoController : ControllerBase
    {
        private readonly IBilling ibiliing;

        public BillingInfoController(IBilling ibiliing)
        {
            this.ibiliing = ibiliing;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetBillings()
        {
            try
            {
                return Ok(await ibiliing.GetBillings());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating Billing!!");
            }
        }


        // GET api/<ValuesController>/5
        [HttpGet("{BillingId:int}")]
        public async Task<ActionResult<BillingInfo>> GetBilling(int BillingId)
        {
            try
            {
                var result = await ibiliing.GetBilling(BillingId);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating billing !!");
            }

        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<BillingInfo>> AddBilling([FromBody] BillingInfo model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var createBilling = await ibiliing.AddBilling(model);

                return CreatedAtAction(nameof(GetBilling),
                    new { BillingId = createBilling.BillingId }, createBilling);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Billing!!");
            }
        }



        // PUT api/<ValuesController>/5
        [HttpPut("{BillingId:int}")]
        public async Task<ActionResult<BillingInfo>> UpdateBilling(int BillingId, [FromBody] BillingInfo model)
        {
            try
            {
                if (BillingId != model.BillingId)
                    return BadRequest("Employee Billing mismatch");

                var updateBillin = await ibiliing.GetBilling(BillingId);

                if (updateBillin == null)
                {
                    return NotFound($"Billing with ID = {BillingId} not found");
                }

                return await ibiliing.UpdateBilling(model);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new Billing!!");
            }
        }




        // DELETE api/<ValuesController>/5
        [HttpDelete("{BillingId:int}")]
        public async Task<ActionResult> DeleteBilling(int BillingId)
        {
            try
            {
                var BillingDelete = await ibiliing.GetBilling(BillingId);

                if (BillingDelete == null)
                {
                    return NotFound($"Billing with id = {BillingId} not found");
                }

                await ibiliing.DeleteBilling(BillingId);

                return Ok($"Billing with id = {BillingId} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting new billing!!");
            }
        }


    }
}
