using MansimransBook.DataAccess.Repository.IRepository;
using MansimransBook.Models;
using MansimransBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MansimransBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverType covertype)
        {
            // use .NET LINQ to retrieve the first or default category object,
            // then pass the id as a generic entity which matches the category ID
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == covertype.Id);
            if (objFromDb != null) //save changes if not null
            {
                objFromDb.Name = covertype.Name;
                _db.SaveChanges();
            }
        }

    }
}
