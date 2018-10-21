using System;

namespace VugleBE.Context.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
    }
}