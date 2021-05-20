﻿using System;
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
        public RequestController()
        {
            repo = new RequestRepository();
        }
        //
        // GET: /Request/
        public ActionResult Index()
        {
            return View(repo.GetRequests());
        }
	}
}