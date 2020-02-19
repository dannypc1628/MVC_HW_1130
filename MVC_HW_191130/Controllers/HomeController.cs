using MVC_HW_191130.Models;
using MVC_HW_191130.Service;
using MVC_HW_191130.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_HW_191130.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookService;

        private readonly UnitOfWork _unitOfWork;
        
        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
            _accountBookService = new AccountBookService(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Money()
        {
            var data = _accountBookService.GetAllAccountBooks();
            var ListMoneyViewModel = from d in data
                              select new MoneyViewModel
                              {
                                  類別 = (CategoryEnum)d.Categoryyy,
                                  時間 = d.Dateee,
                                  金錢 = d.Amounttt,
                                  備註 = d.Remarkkk 
                              };            
            return View(ListMoneyViewModel);
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult CreateMoney()
        {          
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMoney(MoneyViewModel moneyData)
        {
            if (ModelState.IsValid)
            {
                _accountBookService.Add(new AccountBook
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = (int)moneyData.類別,
                     Amounttt = moneyData.金錢,
                      Dateee =moneyData.時間,
                       Remarkkk= moneyData.備註
                });
                _unitOfWork.Commit();
            }
            var data = _accountBookService.GetAllAccountBooks();
            var mappingData = from d in data
                              select new MoneyViewModel
                              {
                                  類別 = (CategoryEnum)d.Categoryyy,
                                  時間 = d.Dateee,
                                  金錢 = d.Amounttt,
                                  備註 = d.Remarkkk
                              };
            
            return PartialView("ListMoney",mappingData.ToList());
                       
        }
    }
}