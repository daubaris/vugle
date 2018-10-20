using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VugleBE.ViewModels;
using PusherServer;
using Microsoft.AspNetCore.Cors;
using VugleBE.Context;
using VugleBE.Context.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class PusherController : Controller
    {
        private readonly VugleContext _context;

        public PusherController(VugleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pushes Notification based on input
        /// </summary>
        /// <param name="input">Notification data to be pushed</param>
        /// <returns></returns>
        /// <response code="200">Notification succesfully sent</response>
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<ActionResult> PushNotification([FromBody] NotificationViewModel input)
        {
            var notification = new Notification { Description = input.description,
                                                  Title = input.title,
                                                  Type = input.type,
                                                  Url = input.url,
                                                  Date = DateTime.Now
                                                 };
            _context.Add(notification);
            _context.SaveChanges();

            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
              "626201",
              "9336e0704072cd38e1db",
              "8d7468d1ea158dc400b1",
              options);

            var result = await pusher.TriggerAsync(
              "vugle-notifications",
              "new-notification",
              input);

            return Ok();
        }

        // Get api/Pusher/All
        /// <summary>
        /// Returns all notifications
        /// </summary>
        /// <returns code="200">Notifications are returned</returns>
        [HttpGet("All")]
        [ProducesResponseType(200)]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<IEnumerable<NotificationViewModel>> GetAllNotifications()
        {
            var notification = _context.Notifications;

            var result = notification.Select(x => new NotificationViewModel
            {
                id = x.Id,
                title = x.Title,
                description = x.Description,
                type = x.Type,
                url = x.Url,
                date = x.Date
            });

            return Ok(result);
        }
    }
}