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
        SubjectRepository subjectsRepo;
        public RequestController()
        {
            repo = new RequestRepository();
            subjectsRepo = new SubjectRepository();
        }
        //
        // GET: /Request/
        public ActionResult Index()
        {
            return View(repo.GetRequests());
        }
        [HttpPost]
        public ActionResult ViewRequest(int requestId)
        {
            Request request = repo.GetRequests().FirstOrDefault(x => x.Id == requestId);
            return View(request);
        }

        [HttpPost]
        public ActionResult CreateReport(int month)
        {
            ViewBag.SelItemsMon = GetSelectItems();

            int year = DateTime.Now.Year;
            List<Item> repItem = new List<Item>();//объединяем из всех нужных отчетов
            
            List<Request> sought = new List<Request>(); //искомые отчеты
            sought.AddRange(repo.GetRequests().Where(x => x.Date.Month == month).Where(x => x.Date.Year == year));
            foreach(var i in sought) 
            {
                repItem.AddRange(i.Items);
            }
            List<Item> items = new List<Item>();
            List<Subject> subjects = subjectsRepo.GetSubjectsRepository();
            for (int i = 0; i < subjectsRepo.GetSubjectsRepository().Count; i++)
            {
                items.Add(new Item() { Subject = subjects[i] , Quantity = 0});
            }
            for (int k = 0; k < items.Count; k++)
            {
                for (int c = 0; c < repItem.Count; c++)
                {
                    if (items[k].Subject.Name == repItem[c].Subject.Name)
                    {
                        items[k].Quantity = items[k].Quantity + repItem[c].Quantity;
                    }
                }
            }
            Report report = new Report() { Subjects = items, Date = new DateTime(year, month, DateTime.Now.Day)};
            //report.Date = new DateTime(year, month, DateTime.Now.Day);
          
            return View("Report", report);
        }
        public ActionResult Report()
        {
            ViewBag.SelItemsMon = GetSelectItems();
            return View();
        }
        public SelectList GetSelectItems()
        {
            List<SelectListItem> SelectItems = new List<SelectListItem>();
            for (int i = 1; i < 12;i++ )
            {
                var item = new SelectListItem() { Selected = true, Text = Convert.ToString(i), Value = Convert.ToString(i) };
                SelectItems.Add(item);
            }
            return new SelectList(SelectItems, "Value", "Text");
        }
	}
}