using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_HW_191130.Models;
using MVC_HW_191130.Repository;

namespace MVC_HW_191130.Service
{
    public class AccountBookService
    {
        private readonly Repository<AccountBook> repository;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            repository = new Repository<AccountBook>(unitOfWork);
        }

        public List<AccountBook> GetAllAccountBooks()
        {
            return repository.All().ToList();
        }

        public AccountBook GetSingleAccountBook(System.Guid Id)
        {
            return repository.GetSingle(d => d.Id == Id);
        }

        public void Add(AccountBook accountBook)
        {
            repository.Create(accountBook);
        }

        public void Edit(AccountBook old,AccountBook newAccountBook)
        {
            old.Categoryyy = newAccountBook.Categoryyy;
            old.Amounttt = newAccountBook.Amounttt;
            old.Dateee = newAccountBook.Dateee;
            old.Remarkkk = newAccountBook.Remarkkk;
        }

        public void Delete(AccountBook accountBook)
        {
            repository.Remove(accountBook);
        }

        

    }
}