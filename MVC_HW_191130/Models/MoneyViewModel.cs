using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_HW_191130.Models
{
    public class MoneyViewModel
    {

        [Display(Name="類別")]
        public CategoryEnum 類別 { get; set; }

        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime 時間 { get; set; }

        [Display(Name = "金額")]        
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int 金錢 { get; set; }
                
        public string 備註 { get; set; }
    }
}