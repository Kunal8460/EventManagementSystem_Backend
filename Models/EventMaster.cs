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
        public int CategoryId { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public TimeSpan EventStartTime { get; set; }
        public TimeSpan EventEndTime { get; set; }
        public string EventVenue { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ThumbnailImage { get; set; }
        public string GalleryImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CustomerEmail { get; set; }

        public virtual ICollection<BookingMaster> BookingMaster { get; set; }
    }
}
