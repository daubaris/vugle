using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VugleBE.Context;
using VugleBE.Context.Models;
using VugleBE.ViewModels;
using PusherServer;
using System.Net;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PusherController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> PushNotification([FromBody] NotificationViewModel input)
        {
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

            return BadRequest();
        }
    }
}