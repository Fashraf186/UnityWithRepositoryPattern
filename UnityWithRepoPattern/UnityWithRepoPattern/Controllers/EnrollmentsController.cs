using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityWithRepoPattern.Interface;
using UnityWithRepoPattern.Models;
using UnityWithRepoPattern.Repository;

namespace UnityWithRepoPattern.Controllers
{
    public class EnrollmentsController : Controller
    {
        private _IGenericRepo<Enrollment> _Eobj;
        private ProjectDataEntities dbentity;

        //public EnrollmentsController() : this (new GenericRepo<Enrollment>())
        //{

        //}

        public EnrollmentsController(_IGenericRepo<Enrollment> Eobj)
        {
            dbentity = new ProjectDataEntities();
            _Eobj = Eobj;
        }


        // GET: Enrollments
        public ActionResult Index()
        {
            return View(from e in _Eobj.GetAll() select e);
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int id)
        {
            Enrollment e = _Eobj.FindbyID(id);
            return View(e);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            
            ViewBag.CourseID = new SelectList(dbentity.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(dbentity.Students, "StudentID", "LastName");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        public ActionResult Create(Enrollment collection)
        {
            try
            {
                _Eobj.Insert(collection);
                _Eobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int id)
        {

            Enrollment e = _Eobj.FindbyID(id);

            ViewBag.CourseID = new SelectList(dbentity.Courses, "CourseID", "Title", e.CourseID);
            ViewBag.StudentID = new SelectList(dbentity.Students, "StudentID", "LastName", e.StudentID);
            return View(e);


        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Enrollment collection)
        {
            try
            {
                _Eobj.Update(collection);
                _Eobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int id)
        {
            Enrollment e = _Eobj.FindbyID(id);
            return View(e);
        }

        // POST: Enrollments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _Eobj.Remove(id);
                _Eobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
