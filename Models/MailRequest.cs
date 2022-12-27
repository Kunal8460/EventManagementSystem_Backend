using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ems.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string? EventName { get; set; }
        //public List<IFormFile> Attachments { get; set; }
    }
}
