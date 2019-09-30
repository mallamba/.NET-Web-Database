using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class NewItemController : Controller
    {
        // GET: NewItem
        public ActionResult Index()
        {
            var item = new Item();
            string s = HttpContext.Session.GetString("create");
            item = JsonConvert.DeserializeObject<Item>(s);
            ViewBag.Id = item.Id;
            ViewBag.Name = item.Name;
            return View();
        }

        // GET: NewItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var item = new Item();
                item.Name = collection["Name"];
                item.Id = Convert.ToInt32( collection["Id"] );
                string s = JsonConvert.SerializeObject(item);
                HttpContext.Session.SetString("create", s);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}