using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEFDFCrudWebsiteDemo.Models;

namespace MVCEFDFCrudWebsiteDemo.Controllers
{
    public class tblEmployeesController : Controller
    {
        private GN22ADMDNF001Entities db = new GN22ADMDNF001Entities();

        // GET: tblEmployees
        public ActionResult Index()
        {
            var tblEmployees = db.tblEmployees.Include(t => t.tblDepartment).Include(t => t.tblDepartment1);
            return View(tblEmployees.ToList());
        }

        // GET: tblEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: tblEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName");
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName");
            return View();
        }

        // POST: tblEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,DeptID")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployees.Add(tblEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            return View(tblEmployee);
        }

        // GET: tblEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            return View(tblEmployee);
        }

        // POST: tblEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,DeptID")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            ViewBag.DeptID = new SelectList(db.tblDepartments, "DeptId", "DeptName", tblEmployee.DeptID);
            return View(tblEmployee);
        }

        // GET: tblEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: tblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
