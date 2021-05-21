using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject {get; set;}
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}