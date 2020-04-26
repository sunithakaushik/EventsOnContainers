using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// http link from postman would be //localhost:6700/api/event/events/?pageIndex=0&pageSize=7
namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public EventController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events([FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 6)
        {
            var eventsCount = await _context.EventNames.LongCountAsync();

            var events = await _context.EventNames
                                            .OrderBy(c => c.Title)
                                            .Skip(pageIndex * pageSize) 
                                            .Take(pageSize).ToListAsync();

            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModel<EventName>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = eventsCount,
                Data = events
            };
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/type/{eventTypeId}/topic/{eventTopicId}")]
        public async Task<IActionResult> Events (int? eventTypeId, int? eventTopicId, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 6)
        {
            var root = (IQueryable<EventName>)_context.EventNames;
            if(eventTypeId.HasValue)
            {
                root = root.Where(c => c.EventTypeId == eventTypeId);
            }
            if (eventTopicId.HasValue)
            {
                root = root.Where(c => c.EventTopicId == eventTopicId);
            }

            var eventsCount = await root.LongCountAsync();

            var events = await root
                                    .OrderBy(c => c.Title)
                                    .Skip(pageIndex * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModel<EventName>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = eventsCount,
                Data = events
            };
            return Ok(model);
        }

        private List<EventName> ChangePictureUrl(List<EventName> events)
        {
            events.ForEach(
                            c => c.ImageUrl =
                            c.ImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"])
                          );
            return events;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTopics()
        {
            var items = await _context.EventTopics.ToListAsync();
            return Ok(items);
        }
    }

}