using BL;
using DL;
using DTO;
using Entities_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : Controller
    {
        private IEmployeeBL _BL;
        public EmployeeController(IEmployeeBL BL)
        {
            _BL = BL;
        }
        [HttpGet("GetEmployeeList")]
        public async Task<ActionResult<IEnumerable<List<EmployeeData>>>> GetEmployeeList()
        {
            var result = await _BL.GetEmployeeList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployeeById(int id)
        {
            var result = await _BL.GetEmployeeById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<IEnumerable<bool>>> UpdateEmployee(EmployeeData employee)
        {
            var result = await _BL.UpdateEmployee(employee);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("InsertDataToDB")]
        public async Task<ActionResult<IEnumerable<bool>>> InsertDataToDB()
        {
            var result = await _BL.InsertDataToDB();
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
