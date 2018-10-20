using System.Collections.Generic;

namespace VugleBE.ViewModels
{
    public class SuggestionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<object> Responses { get; set; }
        public string Url { get; set; }
        public ICollection<SuggestionViewModel> Children { get; set; }
        public int? ChildrenCount { get; set; }
        public ICollection<string> Keywords { get; set; }
        public int? ParentId { get; set; }
    }
}