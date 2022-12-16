using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ems.Models
{
    public partial class EventCategory
    {
        public EventCategory()
        {
            EventMaster = new HashSet<EventMaster>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<EventMaster> EventMaster { get; set; }
    }
}
