using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class RequestSubject
    {
        public int Id { get; set; }
        public Request Request { get; set; }
        public Subject Subject { get; set; }
    }
}