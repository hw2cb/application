using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Models
{
    public class Request
    {
        public int Id { get; set; }
        public List<Subject> Subjects { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public SelectList DropDownList { get; set; }

    }
}