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
            List<SelectListItem> SelectItems = new List<SelectListItem>();
            foreach(var subj in repositorySubj.GetSubjectsRepository())
            {
                var item = new SelectListItem(){Selected = true, Text = subj.Name, Value = Convert.ToString(subj.Id)};
                SelectItems.Add(item);
            }
            var SelList = new SelectList(SelectItems, "Value", "Text");
            ViewBag.SelItems = SelList;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Request request)
        {

            return View();
        }
    }
}