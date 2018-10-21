using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VugleBE.Context.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
