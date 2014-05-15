using Briet3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Briet3.Controllers
{
    public class TitleController : Controller
    {
        [HttpPost]
        public ActionResult SetTitle(FormCollection TitleForm)
        {
            Title t = new Title();
            return (null);

        }
        //
        // GET: /Title/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Title/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Title/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Title/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Title/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Title/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Title/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Title/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
