using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNET_MVC.Models;
using System.Threading;

namespace ASPNET_MVC.Controllers
{
    public class TODOListItemsController : Controller
    {
        private ASPNET_MVCContext storage = ASPNET_MVCContext.Instance;

        // GET: TODOListItems
        public ActionResult Index()
        {
            return View(storage.TODOListItems.Values);
        }

        // GET: TODOListItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOListItem tODOListItem;
            storage.TODOListItems.TryGetValue((int)id, out tODOListItem);
            if (tODOListItem == null)
            {
                return HttpNotFound();
            }
            return View(tODOListItem);
        }

        // GET: TODOListItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODOListItems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TODO")] TODOListItem tODOListItem)
        {
            if (ModelState.IsValid)
            {
                tODOListItem.Id = storage.id;
                if (storage.TODOListItems.TryAdd(storage.id, tODOListItem))
                    Interlocked.Increment(ref storage.id);
                return RedirectToAction("Index");
            }

            return View(tODOListItem);
        }

        // GET: TODOListItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOListItem tODOListItem;
            storage.TODOListItems.TryGetValue((int)id, out tODOListItem);
            if (tODOListItem == null)
            {
                return HttpNotFound();
            }
            return View(tODOListItem);
        }

        // POST: TODOListItems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TODO")] TODOListItem tODOListItem)
        {
            if (ModelState.IsValid)
            {
                TODOListItem tODOListItemOldvalue;
                storage.TODOListItems.TryGetValue(tODOListItem.Id, out tODOListItemOldvalue);
                storage.TODOListItems.TryUpdate(tODOListItem.Id, tODOListItem, tODOListItemOldvalue);
                return RedirectToAction("Index");
            }
            return View(tODOListItem);
        }

        // GET: TODOListItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODOListItem tODOListItem;
            storage.TODOListItems.TryGetValue((int)id, out tODOListItem);
            if (tODOListItem == null)
            {
                return HttpNotFound();
            }
            return View(tODOListItem);
        }

        // POST: TODOListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODOListItem tODOListItem;
            storage.TODOListItems.TryRemove(id, out tODOListItem);
            return RedirectToAction("Index");
        }
    }
}
