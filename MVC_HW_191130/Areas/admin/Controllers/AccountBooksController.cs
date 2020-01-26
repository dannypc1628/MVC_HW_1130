using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_HW_191130.Models;
using MVC_HW_191130.Repository;
using MVC_HW_191130.Service;

namespace MVC_HW_191130.Areas.admin.Controllers
{
    public class AccountBooksController : Controller
    {
        private readonly AccountBookService _service ;
        private readonly UnitOfWork _unitOfWork;

        public AccountBooksController()
        {
            _unitOfWork = new UnitOfWork();
            _service = new AccountBookService(_unitOfWork);
        }

        // GET: admin/AccountBooks
        public ActionResult Index()
        {
            return View(_service.GetAllAccountBooks());
        }

        

      

        // GET: admin/AccountBooks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = _service.GetSingleAccountBook((Guid)id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: admin/AccountBooks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                AccountBook oldBook = _service.GetSingleAccountBook(accountBook.Id);
                _service.Edit(oldBook, accountBook);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(accountBook);
        }

        // GET: admin/AccountBooks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = _service.GetSingleAccountBook((Guid)id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: admin/AccountBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBook accountBook = _service.GetSingleAccountBook(id);
            _service.Delete(accountBook);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
