using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GallaryManager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //public int MyProperty { get; private set; }
        private string fname;

        public string Firstname
        {
            get { return fname; }
            set { fname = value; }
        }
        private string lname;

        public string LastName
        {
            get { return lname; }
            set { lname = value; }
        }
        public double Marks { get; set; }

    }
}