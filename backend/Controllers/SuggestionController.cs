using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VugleBE.Context;
using VugleBE.Context.Models;
using VugleBE.Helpers;
using VugleBE.ViewModels;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : Controller
    {
        private readonly VugleContext _context;
        public SuggestionController(VugleContext context) => _context = context;

        /// <summary>
        /// Get Suggestions children by id 
        /// </summary>
        /// <param name="id">Suggestion id(if null returns the default suggestions)</param>
        /// <returns>Two layer deep suggestions children</returns>
        /// <response code="200">Suggestions children with provided id is returned</response>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<SuggestionViewModel>> Get(int? id = 0)
        {
            IQueryable<Suggestion> suggestions;
            if (id != 0)
            {
                suggestions = _context.Suggestions.Include(x => x.Children).ThenInclude(x => x.Children).Where(x => x.ParentId == id);
            }
            else
            {
                suggestions = _context.Suggestions.Include(x => x.Children).ThenInclude(x => x.Children).Where(x => x.ParentId == null);
            }
            var result = suggestions.Select(x => x.ToViewModel());
            foreach (var child in result)
            {
                child.Children = suggestions.FirstOrDefault(x => x.Id == child.Id).Children.Select(x => x.ToViewModel()).ToList();
            }
            return Ok(result);
        }
        /// <summary>
        /// Get Suggestions by keyword
        /// </summary>
        /// <param name="search">Suggestion keyword</param>
        /// <returns>First two layers of suggestions</returns>
        /// <response code="200">Suggestions with provided keywords are returned</response>
        [HttpGet("search/{search}")]
        public ActionResult<IEnumerable<SuggestionViewModel>> Get(string search)
        {
            var keywords = search.Split(" ").Reverse();
            var distance = int.MaxValue;
            SuggestionKeyword keywordDb = null;
            foreach(var keyword in keywords)
            {
                var tempKeyword = _context.SuggestionKeywords.Include(x=>x.KeywordSuggestions).OrderBy(x => LevenshteinDistance.Compute(x.Keyword,keyword)).FirstOrDefault();
                var tempDistance = LevenshteinDistance.Compute(tempKeyword.Keyword, keyword); 
                if(tempDistance < distance)
                {
                    distance = tempDistance;
                    keywordDb = tempKeyword;
                }
            }
            if(keywordDb == null)
            {
                return null;
            }
            var suggestions = _context.Suggestions.Include(x=>x.KeywordSuggestions).Where(x=>keywordDb.KeywordSuggestions.Any(y => x.Id == y.SuggestionId));
            var result = suggestions.Select(x => new SuggestionViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                Responses = x.Responses != null ? JsonConvert.DeserializeObject<ICollection<object>>(x.Responses) : null,
                Children = x.Children == null ? null : x.Children.Select(child => child.ToViewModel()).ToList(),
                ChildrenCount = x.Children == null ? null : (int?)x.Children.Count
            });
            return Ok(result);
        }
        /// <summary>
        /// Create a suggestion
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Suggestion
        ///     {
        ///         "title": "Skundas",
        ///         "url" : "http://skundas.list",
        ///         "parentId" : 1, 
        ///         "responses" : [ {"text" : "text", "randomInt" : 0.5}],
        ///         "keywords" : ["skundas", "nusikundimas", "skundelis"],
        ///     }
        ///
        /// </remarks>
        /// <param name="input">Suggestion</param>
        /// <returns>Creates a suggestion</returns>
        /// <response code="200">Suggestion id is returned</response>
        [HttpPut]
        public ActionResult<int> Add([FromBody] SuggestionViewModel input)
        {
            var suggestion = new Suggestion
            {
                Title = input.Title,
                Url = input.Url,
                ParentId = input.ParentId
            };
            _context.Add(suggestion);
            _context.SaveChanges();
            foreach(var keyword in input.Keywords)
            {
                var keywordDb = _context.SuggestionKeywords.Include(x=>x.KeywordSuggestions).FirstOrDefault(x => x.Keyword == keyword.ToLower());
                if(keywordDb != null)
                {
                    _context.Add(new KeywordSuggestions{
                        SuggestionId = suggestion.Id,
                        KeywordId = keywordDb.Id
                    });
                }
                else
                {
                    _context.Add(new SuggestionKeyword{
                        Keyword = keyword.ToLower(),
                        KeywordSuggestions = new List<KeywordSuggestions>{new KeywordSuggestions{
                            SuggestionId = suggestion.Id
                        }}
                    });
                }
                _context.SaveChanges();
            }
            return Ok(suggestion.Id);
        }
    }
}