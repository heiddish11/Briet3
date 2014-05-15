﻿using Briet3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Briet3.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepository m_repository = null;
        public HomeController()
        {
            m_repository = new AppRepository();
        }
        /*   public HomeController(IAppRepository rep)
            {
                 //Smidur fyrir einingaprofanir/mock repository
                 m_repository = rep;
            }
        */
        public ActionResult Index()
        {
            IEnumerable<Title> titles = m_repository.GetTitles;
            return View(titles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult CreateTitle()
        {
            Title a = new Title();
            
            return View(a);
        }

        [HttpPost]
        public ActionResult CreateTitle(Title title, HttpPostedFileBase file)
        {
            // Make sure that the user has selected a file to upload
            if (file != null && file.ContentLength > 0)
            {
                // Get the info on the file
                var fileName = Path.GetFileName(file.FileName);
                var contentLength = file.ContentLength;
                var contentType = file.ContentType;

                // Check in Output window to see if the file was uploaded
                System.Diagnostics.Debug.Write(file);

                //Read the content of the file
                string data = new StreamReader(file.InputStream).ReadToEnd();

                // Check in output window to see if the content of the file appears
                System.Diagnostics.Debug.WriteLine(data);

                // Create a new instance of Apprepository called repo to add and save title variable
                AppRepository repo = new AppRepository();
                repo.AddTitle(title);

                 //Save to database
                 FileSRT srt = new FileSRT()
                 {
                     FileSRTName = fileName,
                     Data = data,
                     ContentType = contentType,
                     ContentLength = contentLength,
                     TitleID = title.ID,
                 };

                 repo.AddfileSRT(srt);

                //Show if success
                 return RedirectToAction("Index");
             }
             else
             {
                 return View("Error");
             }
        }

        [HttpGet]
        public ActionResult EditTitle(int? id)
        {

            if (id.HasValue)
            {
                int nid = Convert.ToInt32(id);

                var model = (from Files in m_repository.GetFiles
                            where Files.FileSRTID == nid
                            select Files).SingleOrDefault();
                return View(model);     
            }

            return View("Not found");
           
        }

        [HttpPost]
        public ActionResult EditTitle(int id, FormCollection collection)
        {
            return View();
        }

       /* public ActionResult Translate()
        {

            var ActiveTitles = from titles in m_repository.GetTitles()
                               where titles.Active == true
                               select titles;
            return View(ActiveTitles);
        }
        */ 

    }
}