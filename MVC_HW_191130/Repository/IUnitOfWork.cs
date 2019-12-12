using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_HW_191130.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }

        void Commit();
    }
}
