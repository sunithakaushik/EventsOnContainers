﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Domain
{
    public class EventName
    {
        public int Id { get; set; }
        public string Title { get; set; }
      //  public int Ticket { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
     //   public string OrganizerName { get; set; }
     //   public string OrganizerDesc { get; set; }
        public string Listing { get; set; }
        public int EventTopicId { get; set; }
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventTopic EventTopic { get; set; }
    }
}
