using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Report
    {
        public List<Item> Subjects { get; set; }
        public DateTime Date { get; set; }
    }
}