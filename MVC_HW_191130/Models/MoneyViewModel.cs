using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_HW_191130.Models
{
    public class MoneyViewModel
    {

        [Display(Name="類別")]
        [Range(0,1)]
        public CategoryEnum 類別 { get; set; }

        [Display(Name = "日期")]        
        [Remote("Date","Valid",ErrorMessage ="日期不可以超過今天")]
        [DataType(DataType.Date,ErrorMessage ="這不是日期格式")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime 時間 { get; set; }

        [Display(Name = "金額")]
        [Range(0,Int32.MaxValue,ErrorMessage ="請輸入大於0之正整數")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int 金錢 { get; set; }
                
        [MaxLength(100,ErrorMessage ="最多輸入100個字元")]
        public string 備註 { get; set; }
    }
}