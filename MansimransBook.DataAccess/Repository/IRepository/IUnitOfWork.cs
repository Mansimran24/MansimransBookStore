using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MansimransBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork 
    {
        ICategoryRepository Category { get; }
        ISP_Call SP_Call { get; }
    }
}
