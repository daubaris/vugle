using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VugleBE.ViewModels
{
    public class NotificationViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
