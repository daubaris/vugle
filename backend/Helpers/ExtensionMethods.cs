using System.Collections.Generic;
using Newtonsoft.Json;
using VugleBE.Context.Models;
using VugleBE.ViewModels;

namespace VugleBE.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Transforms Suggestion into SuggestionViewModel
        /// </summary>
        public static SuggestionViewModel ToViewModel(this Suggestion input)
        {
            var result = new SuggestionViewModel
            {
                Id = input.Id,
                Title = input.Title,
                Url = input.Url,
                Responses = input.Responses != null ? JsonConvert.DeserializeObject<ICollection<object>>(input.Responses) : null,
                ChildrenCount = input.Children?.Count
            };
            return result;
        }
    }
}