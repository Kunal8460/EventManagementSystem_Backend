using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ems.Models
{
    public partial class BookingMaster
    {
        public int BookingId { get; set; }
        public int? EventId { get; set; }
        public int? Quantity { get; set; }
        public int? NetPrice { get; set; }
        public string CustomerEmail { get; set; }
        public string BookedOn { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual EventMaster Event { get; set; }
    }
}
