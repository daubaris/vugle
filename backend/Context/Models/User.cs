using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<PollResponse> PollResponses {get;set;}
    }
}