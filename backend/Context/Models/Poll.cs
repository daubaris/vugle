using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<Option> Options { get; set; }
        public virtual ICollection<PollResponse> PollResponses { get; set; }
    }
}