using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<KeywordSuggestions> KeywordSuggestions { get; set; }
        public virtual ICollection<Suggestion> Children { get; set; }
        public int? ParentId { get; set; }
        public Suggestion Parent { get; set; }
        public string Responses { get; set; }
        public string Url { get; set; }
    }
}