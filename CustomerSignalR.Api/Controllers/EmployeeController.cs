using CustomerSignalR.Api.Data.Entities;
using CustomerSignalR.Api.Service.CommonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/Employees  
        [HttpGet]
        [Route("GetEmployeeList")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeList()
        {
            try
            {
                var res = await _service.GetEmployeeList();
                if (res != null) {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var res = await _service.GetEmployeeById(id);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT: api/Employees/5  
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754 
        [HttpPut]
        [Route("PutEmployee/{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            try
            {
                var res = await _service.UpdateEmployee(id,employee);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: api/Employees  
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostEmployeeDetails")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                var res = await _service.InsertEmployee(employee);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var res = await _service.DeleteEmployee(id);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
