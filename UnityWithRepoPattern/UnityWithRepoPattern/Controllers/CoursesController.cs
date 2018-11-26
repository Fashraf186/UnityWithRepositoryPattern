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
    public class CoursesController : Controller
    {

        private _IGenericRepo<Course> _Courseobj;

        
        public CoursesController(_IGenericRepo<Course> Courseobj)
        {
            _Courseobj = Courseobj;
        }

        // GET: Courses
        public ActionResult Index()
        {
            return View(from c in _Courseobj.GetAll() select c);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            Course c = _Courseobj.FindbyID(id);

            return View(c);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(Course collection)
        {
            try
            {
                _Courseobj.Insert(collection);
                _Courseobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            Course c = _Courseobj.FindbyID(id);
            return View(c);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course collection)
        {
            try
            {
                _Courseobj.Update(collection);
                _Courseobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            Course c = _Courseobj.FindbyID(id);
            return View(c);
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course collection)
        {
            try
            {
                _Courseobj.Remove(id);
                _Courseobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
