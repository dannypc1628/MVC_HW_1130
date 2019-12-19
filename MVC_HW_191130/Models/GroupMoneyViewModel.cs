using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_HW_191130.Models
{
    public class GroupMoneyViewModel
    {
        public MoneyViewModel Money { get; set; }
        public List<MoneyViewModel> ListMoney { get; set; }
    }
}