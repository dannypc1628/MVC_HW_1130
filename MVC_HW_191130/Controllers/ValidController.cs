using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_HW_191130.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult Amount([Bind(Prefix = "Money.金錢")]int 金錢)
        {            
            bool isValidate = 金錢 > 0 ;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Date([Bind(Prefix = "Money.時間")]DateTime 時間)
        {            
            bool isValidate = 時間 <= DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}