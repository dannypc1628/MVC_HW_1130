using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_HW_191130.Service
{
    public class CategoryyyConvert
    {
        public static string ToStringName(int i)
        {
            if (i == 0)
                return "收入";
            else
                return "支出";
        }
    }
}