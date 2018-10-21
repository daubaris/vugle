using System;

namespace VugleBE.ViewModels
{
    public class NotificationViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
    }
}
