using System;
using System.Collections.Generic;

namespace VugleBE.ViewModels
{
    public class PollResponseViewModel
    {
        public int PollId { get; set; }
        public Guid? UserId { get; set; }
        public string Response {get;set;}
    }
}