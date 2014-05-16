using Briet3.Models;
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
                 //Constructor for unit testingr/mock repository
                 m_repository = rep;
            }
        */
        public ActionResult Index()
        {
            // Getting a list of titles from the database
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
            //Creating a new instance of the class Title
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
            // Get title by id to enable editing
            if (id.HasValue)
            {
                int nid = Convert.ToInt32(id);

                FileSRT model = (from Files in m_repository.GetFiles
                                 where Files.TitleID == nid
                                 select Files).FirstOrDefault();

                return View(model);     
            }

            return View("Error");
           
        }

        [HttpPost]
        public ActionResult EditTitle(FileSRT model)
        {
            // Enable user to edit a file 
            // by calling the Savefile function
            if(ModelState.IsValid)
            {
                m_repository.SaveFile(model);
            }

            return View("Success");
        }

        [HttpGet]
        public FileContentResult GetFile(int id)
        {
            // Enable user to download file from database
            FileSRT file = m_repository.GetFile(id);
            byte[] data = System.Text.Encoding.Default.GetBytes(file.Data);
            return File(data, "text/plain", file.FileSRTName);
        }

    }
}