using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ems.Models
{
    public partial class EventMaster
    {
        public EventMaster()
        {
            BookingMaster = new HashSet<BookingMaster>();
        }

        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int? CategoryId { get; set; }
        public string EventDescription { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public string EventVenue { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ThumbnailImage { get; set; }
        public string GalleryImage { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CustomerEmail { get; set; }

        public virtual EventCategory Category { get; set; }
        public virtual ICollection<BookingMaster> BookingMaster { get; set; }
    }
}
