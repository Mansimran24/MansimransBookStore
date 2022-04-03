using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MansimransBook.Models;
using MansimransBook.DataAccess.Repository.IRepository;

namespace MansimransBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)  //action method for Upsert
        {
            Category category = new Category();   // using MansimransBook.Models;
            if(id == null)
            {
                // this is for create
                return View(category);
            }
            // this for the edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if(category == null)
            {
                return NotFound();
            }
            return View();
        }

        //API calls here
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            //return NotFound();
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
