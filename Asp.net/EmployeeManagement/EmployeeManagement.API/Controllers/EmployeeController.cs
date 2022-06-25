using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
 
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _userService;

        public EmployeeController(
            ILogger<EmployeeController> logger, IEmployeeService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet, Route("GetEmployeeList")]
        public IEnumerable<EmployeeVM> GetEmployeeList()
        {
            try
            {
                this._logger.LogDebug("In EmployeeController.GetEmployeeList");
                return _userService.GetAllEmployee();
            }
            catch (Exception e)
            {
                this._logger.LogDebug("In EmployeeController.GetEmployeeList Exception Message= " + e.Message);
                return new List<EmployeeVM>();
            }
            finally
            {
                this._logger.LogDebug("Out EmployeeController.GetEmployeeList");
            }

        }
        
        [HttpGet, Route("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails(Guid Id)
        {
            try
            {
                this._logger.LogDebug("In EmployeeController.GetEmployeeDetails: Id {0}", Id);

                    var User = _userService.GetEmployeeDetails(Id);
                    if (!string.IsNullOrEmpty(User.Name))
                    {
                        return Ok(User);
                    }
                    else
                    {
                        return NotFound("Employee Not Exist");
                    }
               
                
            }
            catch (Exception e)
            {
                this._logger.LogDebug("In EmployeeController.GetEmployeeDetails Exception Message= " + e.Message);
                return NotFound("Exception Occured" + e.Message);
            }
            finally
            {
                this._logger.LogDebug("Out EmployeeController.GetEmployeeDetails");
            }

        }

    }
}
