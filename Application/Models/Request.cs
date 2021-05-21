using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Application.Models
{
    public class Request
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime Date { get; set; }
    }
}