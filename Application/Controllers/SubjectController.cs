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
        SubjectController()
        {
            repositorySubj = new SubjectRepository();
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(repositorySubj.GetSubjectsRepository().FirstOrDefault());
        }
    }
}