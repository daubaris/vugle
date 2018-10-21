using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class SuggestionKeyword
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public virtual ICollection<KeywordSuggestions> KeywordSuggestions { get; set; }
    }
}