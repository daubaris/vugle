using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VugleBE.Context;
using VugleBE.Context.Models;
using VugleBE.Services;
using VugleBE.ViewModels;

namespace VugleBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class PollController : ControllerBase
    {
        private readonly VugleContext _context;
        public PollController(VugleContext context)
        {
            _context = context;
        }
        // Get api/Poll/All
        /// <summary>
        /// Returns all polls
        /// </summary>
        /// <response code="200">Polls are returned</response>
        [HttpGet("All")]
        [ProducesResponseType(200)]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<IEnumerable<PollViewModel>> GetAllPolls()
        {
            var polls = _context.Polls.Include(x => x.Options);
            var pollResponses = _context.PollResponses;
            var result = polls.Select(x => new PollViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Date = x.Date,
                Options = x.Options.Select(op => new OptionViewModel
                {
                    Title = op.Title,
                    Value = pollResponses.Count(pr => pr.PollId == x.Id && pr.Response == op.Title).ToString()
                }).ToList(),
                Title = x.Title
            });
            return Ok(result);
        }
        // Get api/Poll/{id}
        /// <summary>
        /// Returns one poll
        /// </summary>
        /// <param name="id">Id of a poll</param>
        /// <response code="200">Polls are returned</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<PollViewModel> GetPoll(int id)
        {
            var poll = _context.Polls.Include(x => x.Options).FirstOrDefault(x => x.Id == id);
            var pollResponses = _context.PollResponses;
            var result = new PollViewModel
            {
                Id = poll.Id,
                Description = poll.Description,
                Date = poll.Date,
                Options = poll.Options.Select(op => new OptionViewModel
                {
                    Title = op.Title,
                    Value = pollResponses.Count(pr => pr.PollId == poll.Id && pr.Response == op.Title).ToString()
                }).ToList(),
                Title = poll.Title
            };
            return Ok(result);
        }
        // Get api/Poll/All
        /// <summary>
        /// Creates a poll
        /// </summary>
        /// <response code="200">Poll has been created</response>
        [ProducesResponseType(200)]
        [HttpPut]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> AddNewPoll([FromBody]PollViewModel request)
        {
            var poll = new Poll
            {
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                Options = request.Options.Select(x => new Option
                {
                    Title = x.Title
                }).ToList()
            };
            _context.Add(poll);
            _context.SaveChanges();

            await PusherService.SendNotification(poll.Id, "new-poll");

            return Ok(poll.Id);
        }
        // Get api/Poll/All
        /// <summary>
        /// Responds to poll
        /// </summary>
        /// <response code="204">Poll response has been created</response>
        [ProducesResponseType(204)]
        [HttpPost("Response")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult SendResponse([FromBody]PollResponseViewModel request)
        {
            var pollResponse = new PollResponse
            {
                UserId = request.UserId,
                PollId = request.PollId,
                Response = request.Response
            };
            _context.Add(pollResponse);
            _context.SaveChanges();
            return NoContent();
        }
    }
}