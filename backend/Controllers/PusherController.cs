using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VugleBE.ViewModels;
using PusherServer;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PusherController : Controller
    {
        /// <summary>
        /// Pushes Notification based on input
        /// </summary>
        /// <param name="input">Notification data to be pushed</param>
        /// <returns></returns>
        /// <response code="200">Notification succesfully sent</response>
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

            return Ok();
        }
    }
}