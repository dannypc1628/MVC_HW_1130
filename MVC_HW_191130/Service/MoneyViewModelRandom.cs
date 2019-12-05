using MVC_HW_191130.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_HW_191130.Service
{
    public class MoneyViewModelRandom
    {
        /// <summary>
        /// 得到一筆假資料
        /// </summary>
        /// <returns></returns>
        public MoneyViewModel Get()
        {
            return new MoneyViewModel
            {
                類別 = Get類別(),
                時間 = Get時間(),
                金錢 = Get金錢()
            };

        }

        private string Get類別()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int i = random.Next(100);
            if (i %2== 0)
            {
                return "支出";
            }
            else
            {
                return "收入";
            }
        }

        private DateTime Get時間()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            DateTime dateTime = Convert.ToDateTime("2019-1-1");
            TimeSpan timeSpan = DateTime.Now - dateTime;

            dateTime = dateTime.AddDays(random.Next(timeSpan.Days - 1));
            dateTime = dateTime.AddHours(random.Next(24));
            dateTime = dateTime.AddMinutes(random.Next(60));
            dateTime = dateTime.AddSeconds(random.Next(60));
            dateTime = dateTime.AddMilliseconds(random.Next(100));

            return dateTime;            

        }

        private int Get金錢()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int i = random.Next(10,1000);
            int j = random.Next(4);
            return i* (int)Math.Pow(10,j) ;
        }
    }
}