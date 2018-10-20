using System;
using System.Collections.Generic;

namespace VugleBE.ViewModels
{
    public class PollViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<OptionViewModel> Options { get; set; }
    }
}