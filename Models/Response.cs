using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ems.Models
{
    public class Response<T>
    {
            public bool Status { get; set; }
            public string Message { get; set; } = string.Empty;
            public T Data { get; set; }       
    }
}
