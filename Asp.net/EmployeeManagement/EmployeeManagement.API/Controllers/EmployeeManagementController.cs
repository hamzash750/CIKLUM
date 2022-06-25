
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly ILogger<EmployeeManagementController> _logger;
        private readonly IEmployeeManagement _userManagementService;
        public EmployeeManagementController(
            ILogger<EmployeeManagementController> logger, IEmployeeManagement userManagementService)
        {
            _logger = logger;
            _userManagementService = userManagementService;
        }
        [HttpPost, Route("InsertNewEmployee")]
        public  IActionResult InsertNewEmployee(EmployeeVM Ua)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._logger.LogDebug("In EmployeeManagementController.InsertNewEmployee");
                    var user = _userManagementService.InsertEmployee(Ua);
                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest(Ua);
                }
                
            }
            catch (Exception e)
            {
                this._logger.LogDebug("In EmployeeManagementController.InsertNewEmployee Exception Message= " + e.Message);
                return NotFound("Exception Occured"+e.Message);
            }
            finally
            {
                this._logger.LogDebug("Out EmployeeManagementController.InsertNewEmployee");
            }

        }
        [HttpPut, Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeVM Ua)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._logger.LogDebug("In EmployeeManagementController.UpdateEmployee: Id {0}");
                    var user = _userManagementService.UpdateEmployee(Ua);
                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest("Employee Not Found");
                    }
                    
                }
                else
                {
                    return BadRequest(Ua);
                }
                
            }
            catch (Exception e)
            {
                this._logger.LogDebug("In EmployeeManagementController.UpdateEmployee Exception Message= " + e.Message);
                return NotFound("Exception Occured" + e.Message);
            }
            finally
            {
                this._logger.LogDebug("Out EmployeeManagementController.UpdateEmployee");
            }

        }

        [HttpDelete, Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            try
            {
                    this._logger.LogDebug("In EmployeeManagementController.DeleteEmployee: Id {0}", Id);
                    var user = _userManagementService.DeleteEmployee(Id);
                    if (!string.IsNullOrEmpty(user.Name))
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest("Employee Not Found");
                    }
                
                
            }
            catch (Exception e)
            {
                this._logger.LogDebug("In EmployeeManagementController.DeleteEmployee Exception Message= " + e.Message);
                return NotFound("Exception Occured" + e.Message);
            }
            finally
            {
                this._logger.LogDebug("Out EmployeeManagementController.DeleteEmployee");
            }

        }


    }
}
