using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC_HW_191130.Models
{
    public class DataByDapper
    {
        private string ConnetionString { get; set; }

        public DataByDapper()
        {
            this.ConnetionString = WebConfigurationManager.ConnectionStrings["ado"].ConnectionString;
        }
        public List<MoneyViewModel> GetAllAccountBook()
        {
            List<MoneyViewModel> result = new List<MoneyViewModel>();

            using (var con = new SqlConnection(this.ConnetionString))
            {
                var selectCommand = "Select Id,Categoryyy,Amounttt,Dateee,Remarkkk From AccountBook";
                var list = con.Query(selectCommand);
                foreach (var item in list)
                {                    
                    result.Add(new MoneyViewModel
                    {
                        類別 = (CategoryEnum)item.Categoryyy,
                        時間 = item.Dateee,
                        金錢 = (int)item.Amounttt
                        
                    });
                }

            }
            return result;
        }
    }
}