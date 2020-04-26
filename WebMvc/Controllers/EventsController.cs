using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventsController : Controller
    {

        private readonly ICatalogService _service;
        public EventsController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? topicsFilterApplied, int? typesFilterApplied)
        {
            var itemsOnPage = 10;

            var catalog = await _service.GetCatalogEventAsync(page ?? 0, itemsOnPage, typesFilterApplied, topicsFilterApplied);
            var vm = new CatalogIndexViewModel
            {
                Events = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                Topics = await _service.GetTopicsAsync(),
                Types = await _service.GetTypesAsync(),
                TopicsFilterApplied = topicsFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
    }
}