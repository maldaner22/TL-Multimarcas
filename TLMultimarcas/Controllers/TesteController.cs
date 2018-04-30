﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLMultimarcas.Models;

namespace TLMultimarcas.Controllers
{
    public class TesteController : Controller
    {
        private TLMultimarcasEntities3 db = new TLMultimarcasEntities3();

        public ActionResult Index()
        {
            var cars = db.Veiculo;
            return View(cars);
        }

    }
}