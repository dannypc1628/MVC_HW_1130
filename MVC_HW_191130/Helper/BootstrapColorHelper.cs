using MVC_HW_191130.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_HW_191130.Helper
{
    public static class BootstrapColorHelper
    {
        public static string GetPrimaryOrDanger(CategoryEnum category)
        {
            var textColor = "";
            if (category.ToString() == "支出")
            {
                textColor = "text-danger";
            }
            else
            {
                textColor = "text-primary";
            }
            return textColor;
        }
    }
}