using GallaryManager.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GallaryManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            string path = @"D:/POC/GallaryManager/GallaryManager/Images/ketan";
            ViewBag.Images = GetAllImages(path);
             
            return View();
        }

        private string[] GetAllImages(string path)
        {
            var obj = Directory.GetFiles(path);
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i] = obj[i].ToLower().Replace(path.ToLower(), "").Replace("\\", "");
            }
            //var obj = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath(path));
            return obj;
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            //foreach (string item in Request.Files)
            //{
            //    HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
            //    if (file.ContentLength == 0)
            //        continue;
            //    if (file.ContentLength > 0)
            //    {
            //        ImageUpload imageUpload = new ImageUpload { Width = 600 };
            //        ImageResult imageResult = imageUpload.RenameUploadFile(file);
            //        if (imageResult.Success)
            //        {
            //            Console.WriteLine(imageResult.ImageName);
            //        }
            //        else
            //        {
            //            ViewBag.Error = imageResult.ErrorMessage;
            //        }
            //    }
            //}
            string UploadPath = "~/Images/ketan";
             
            if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(UploadPath)))
                System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(UploadPath));
             
            /*for (int i = 0; i < Request.Files.Count; i++)
            {
                var x = Request.Files[i];
                x.SaveAs(Server.MapPath("~/Images/ketan/" + x.FileName));
            } */
            
            System.Threading.Tasks.Parallel.For(0, Request.Files.Count, i =>
            {
                var x = Request.Files[i];
                x.SaveAs(Server.MapPath("~/Images/ketan/" + x.FileName));
            }); 
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public void deleteImage(string fileName)
        {
            try
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/Images/ketan/" + fileName));
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
