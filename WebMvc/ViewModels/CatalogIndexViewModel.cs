using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Topics { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<Events> Events { get; set; }

        public int? TopicsFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }

    }
}
