using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
namespace Application.Controllers
{
    public class RequestController : Controller
    {
        RequestRepository repo;
        ItemsRepository ItemRepo;
        public RequestController()
        {
            repo = new RequestRepository();
            ItemRepo = new ItemsRepository();
        }
        //
        // GET: /Request/
        public ActionResult Index()
        {
            //List<Request> req = new List<Request>();
            //req = repo.GetRequests(); //получили все заявки
            //foreach(var r in req)// заявка с id 9
            //{
            //    r.Items.Add()
            //}
            return View(repo.GetRequests());
        }
	}
}