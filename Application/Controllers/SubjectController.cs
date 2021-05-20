using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
namespace Application.Controllers
{
    public class SubjectController : Controller
    {
        SubjectRepository repositorySubj;
        public SubjectController()
        {
            repositorySubj = new SubjectRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.SelItems = GetSelectItems();
            return View(new Request());
        }
        [HttpPost]
        public ActionResult Index(Request request)
        {
            if(ModelState.IsValid)
            {
                ViewBag.SelItems = GetSelectItems();
                using(MyContext db = new MyContext())
                {
                    request.Date = DateTime.Now;
                    RequestSubject req = new RequestSubject() { Request = request, Subject = repositorySubj.GetSubjectsRepository().FirstOrDefault(p => p.Id == request.SubjId)};
                    db.Requests.Add(request);
                    db.RequestSubjects.Add(req);
                    db.SaveChanges();
                }
            }
            return View(request);
        }
        public ActionResult AddPosition(Request request)
        {

            ViewBag.SelItems = GetSelectItems();
            return View("Index", new Request() { Count = request.Count+1});
        }
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