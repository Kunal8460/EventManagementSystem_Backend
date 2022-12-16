using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ems.Models
{
    public partial class EventMaster
    {
        public int event_id { get; set; }
        public string event_title { get; set; }
        public int? category_id { get; set; }
        public string event_description { get; set; }
        public string event_start_date { get; set; }
        public string event_end_date { get; set; }
        public string event_start_time { get; set; }
        public string event_end_time { get; set; }
        public string event_venue { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string ThumbnailImage { get; set; }
        public string GalleryImage { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CustomerEmail { get; set; }

        public virtual EventCategory Category { get; set; }
    }
}
