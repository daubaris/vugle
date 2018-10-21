using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class PollResponse
    {
        public int Id { get; set; }
        public Poll Poll { get; set; }
        public int PollId { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }
        public string Response { get; set; }
    }
}