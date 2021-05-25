using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
namespace Application.Controllers
{
    public class HomeController : Controller
    {

        SubjectRepository repositorySubj;
        public HomeController()
        {
            repositorySubj = new SubjectRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.SelItems = GetSelectItems();
            return View();
        }
        [HttpPost]
        public ActionResult Index(List<Item> items)
        {
            if(ModelState.IsValid)
            {
                ViewBag.SelItems = GetSelectItems();
                using(MyContext db = new MyContext())
                {
                    Request request = new Request() {Items = items, Date = DateTime.Now };
                    db.Requests.Add(request);
                    db.SaveChanges();
                }
                return View("Created");
            }
            return View();
        }
        // метод возвращает список предметов из бд
        public SelectList GetSelectItems()
        {
            List<SelectListItem> SelectItems = new List<SelectListItem>();
            foreach (var subj in repositorySubj.GetSubjectsRepository())
            {
                var item = new SelectListItem() { Selected = true, Text = subj.Name, Value = Convert.ToString(subj.Id) };
                SelectItems.Add(item);
            }
            return new SelectList(SelectItems, "Value", "Text");
        }
	}
}