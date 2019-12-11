using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HW_191130.Models;

namespace MVC_HW_191130.Service
{
    public class AccountBookService
    {
        private readonly SkillTreeHomeworkEntities db;

        public AccountBookService()
        {
            db = new SkillTreeHomeworkEntities();
        }

        public List<AccountBook> GetAllAccountBooks()
        {
            return this.db.AccountBook.ToList();
        }

        public AccountBook GetSingleAccountBook(System.Guid Id)
        {
            return this.db.AccountBook.SingleOrDefault(d => d.Id == Id);
        }

        public void Add(AccountBook accountBook)
        {
            db.AccountBook.Add(accountBook);
        }

        public void Edit(AccountBook old,AccountBook newAccountBook)
        {
            old.Categoryyy = newAccountBook.Categoryyy;
            old.Amounttt = newAccountBook.Amounttt;
            old.Dateee = newAccountBook.Dateee;
        }

        public void Delete(AccountBook accountBook)
        {
            db.AccountBook.Remove(accountBook);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}