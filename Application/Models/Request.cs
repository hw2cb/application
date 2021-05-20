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
        public List<RequestSubject> RequestSubjects { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int SubjId { get; set; }
        public int Count { get; set; }
        public Request()
        {
            Count = 1;
        }


    }
}