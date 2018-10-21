using System;
using System.Collections.Generic;

namespace VugleBE.Context.Models
{
    public class KeywordSuggestions
    {
        public int Id { get; set; }
        public virtual SuggestionKeyword Keyword { get; set; }
        public virtual Suggestion Suggestion { get; set; }
        public int KeywordId { get; set; }
        public int SuggestionId { get; set; }
    }
}