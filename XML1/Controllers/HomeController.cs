using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XML1.Models;
using System.Data;

namespace XML1.Controllers
{
    public class HomeController : Controller
    {
        static DataSet ds;
        static DataTable dt;
        // GET: Home
        public ActionResult Index()
        {
            if(System.IO.File.Exists(Server.MapPath("~/App_Data/review.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/review.xml"));
                dt = ds.Tables["Course"];
                Response.Write(dt.Rows.Count);
            }
            else
            {
                ds = new DataSet("Courses");
                dt = new DataTable("Course");
                dt.Columns.Add("Code");
                dt.Columns.Add("Title");
                dt.Columns.Add("Type");
                dt.Columns.Add("Credits");
                dt.Columns.Add("ValidationDate");
                ds.Tables.Add(dt);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Course course)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                row["Code"] = course.CourseCode;
                row["Title"] = course.CourseTitle;
                row["Type"] = course.CourseType;
                row["Credits"] = course.CourseCredits;
                row["ValidationDate"] = course.CourseValidationDate;
                dt.Rows.Add(row);
                ds.AcceptChanges();
                ds.WriteXml(Server.MapPath("~/App_Data/review.xml"));
                return View();
            }
            else
            {
                return View(course);
            }
            
            
        }
    }
}