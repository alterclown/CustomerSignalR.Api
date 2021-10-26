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
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        // GET: api/Notifications/notificationcount
        [HttpGet]
        [Route("NotificationCount")]        
        public async Task<ActionResult<NotificationCountResult>> GetNotificationCount()
        {
            try
            {
                var res = await _service.GetNotificationCount();
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

        // GET: api/Notifications/notificationresult  
        [HttpGet]
        [Route("NotificationResult")]
        public async Task<ActionResult<List<NotificationResult>>> GetNotificationMessage()
        {
            try
            {
                var res = await _service.GetNotificationMessageList();
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

        // DELETE: api/Notifications/deletenotifications  
        [HttpDelete]
        [Route("DeleteNotification")]
        public async Task<IActionResult> DeleteNotifications()
        {
            try
            {
                var res = await _service.DeleteNotifications();
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
