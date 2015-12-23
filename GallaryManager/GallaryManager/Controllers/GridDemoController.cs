using GallaryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GallaryManager.Controllers
{
    public class GridDemoController : Controller
    {
        //
        // GET: /GridDemo/

        public ActionResult Index()
        {

            var empList = new List<Employee>() { 
            new Employee(){
                Firstname="Ketan",
                LastName="Agnigotri",
                Id=1,
                Marks=70
            },new Employee(){
                Firstname="Rashmi",
                LastName="Agnigotri",
                Id=2,
                Marks=88
            },new Employee(){
                Firstname="Milind",
                LastName="Agnigotri",
                Id=3,
                Marks=75
            },new Employee(){
                Firstname="Tavisca",
                LastName="Pune",
                Id=4,
                Marks=72
            },new Employee(){
                Firstname="Kishor",
                LastName="Nashik",
                Id=5,
                Marks=71
            },new Employee(){
                Firstname="Ms",
                LastName="GD",
                Id=6,
                Marks=99
            }
            };
            return View(empList);
        }

    }
}
