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

        private List<EventName> ChangePictureUrl(List<EventName> events)
        {
            events.ForEach(
                            c => c.ImageUrl =
                            c.ImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"])
                          );
            return events;
        }
    }

}