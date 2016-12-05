using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnicalProgrammingProject.Models;

namespace TechnicalProgrammingProject.Controllers
{
    [Authorize]
    public class CookbooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Views the logged in users cookbook or another users cookbook.
        /// </summary>
        /// <returns></returns>
        // GET: Cookbooks
        public ActionResult Index(string id)
        {
            //id is not present in url
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }

            var user = db.Users.Find(id);
            //id is not found
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.ReturnUrl = Request.Url;

            // find recipes
            var recipes = db.Recipes.Where(r => r.Cookbooks.Any(c => c.ApplicationUserID == user.Id));

            //build model
            CookbookViewModel model = new CookbookViewModel()
            {
                ID = user.Id,
                DisplayName = user.DisplayName,
                Recipes = recipes.ToList()
            };

            // no recipes found
            if (recipes.ToList().Count == 0)
            {
                // not current user
                if (user.Id != User.Identity.GetUserId())
                {
                    return View("Empty", model);
                }
                //current user
                return View("~/Views/Cookbooks/Current/Empty.cshtml", model);
            }
            // not current user
            if (user.Id != User.Identity.GetUserId())
            {
                return View(model);
            }
            // current user
            return View("~/Views/Cookbooks/Current/Index.cshtml", model);
        }

        // GET: Cookbooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookbook cookbook = db.Cookbooks.Find(id);
            if (cookbook == null)
            {
                return HttpNotFound();
            }
            return View(cookbook);
        }

        // GET: Cookbooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cookbooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CookbookID,UserID")] Cookbook cookbook)
        {
            if (ModelState.IsValid)
            {
                db.Cookbooks.Add(cookbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cookbook);
        }

        // GET: Cookbooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookbook cookbook = db.Cookbooks.Find(id);
            if (cookbook == null)
            {
                return HttpNotFound();
            }
            return View(cookbook);
        }

        // POST: Cookbooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CookbookID,UserID")] Cookbook cookbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cookbook);
        }

        // GET: Cookbooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookbook cookbook = db.Cookbooks.Find(id);
            if (cookbook == null)
            {
                return HttpNotFound();
            }
            return View(cookbook);
        }

        // POST: Cookbooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cookbook cookbook = db.Cookbooks.Find(id);
            db.Cookbooks.Remove(cookbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search(string searchTerm = "")
        {
            var userID = User.Identity.GetUserId();

            var searchResult = db.Cookbooks.Where(c => c.ApplicationUser.Id == userID)
                                                        .Where(c => c.Recipes.Any(r => searchTerm == ""
                                                        || r.Name.Contains(searchTerm)
                                                        || r.Tags.Any(t => t.Name == searchTerm)
                                                        || r.Ingredients.Any(i => i.Name == searchTerm)));

            if (searchResult == null)
            {
                // There are no results.
                ViewBag.Message = "No Recipes matched those search terms.";
                return View();
            }
            else
            {
                ViewBag.Message = "Returned " + searchResult.Count().ToString() + " results.";
                return View(searchResult);
            }
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
