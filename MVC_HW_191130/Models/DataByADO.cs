using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVC_HW_191130.Models
{
    public class DataByADO
    {
        private string ConnetionString { get; set; }

        public DataByADO()
        {
            this.ConnetionString = WebConfigurationManager.ConnectionStrings["ado"].ConnectionString;
        }

        public List<MoneyViewModel> GetAllAccountBook()
        {
            List<MoneyViewModel> result = new List<MoneyViewModel>();

            using(DbConnection connection = new SqlConnection(this.ConnetionString))
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select Id,Categoryyy,Amounttt,Dateee,Remarkkk From AccountBook";
                    connection.Open();
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string cate = reader["Categoryyy"].ToString();
                        if (cate == "0")
                            cate = "支出";
                        else
                            cate = "收入";
                        result.Add(new MoneyViewModel
                        {
                            類別 = cate,
                            時間 = Convert.ToDateTime(reader["Dateee"].ToString()),
                            金錢 = Convert.ToInt32(reader["Amounttt"].ToString())
                        });
                    }

                }
               
            }
            return result;
        }
    }
}