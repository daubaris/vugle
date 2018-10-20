using PusherServer;
using System.Threading.Tasks;

namespace VugleBE.Services
{
    public static class PusherService
    {
        public static async Task SendNotification(object notification, string notificationType)
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

            await pusher.TriggerAsync(
              "vugle-notifications",
              notificationType,
              notification);
        }
    }
}
