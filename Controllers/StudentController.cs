using Microsoft.AspNetCore.Mvc;
using StSluzba.DataAccess.Data;
using StSluzba.DataAccess.Repository.IRepository;
using StSluzba.Models;

namespace StSluzbaWeb.Controllers
{
    
    
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _unitOfWork.Student.GetAll().ToList();
            return View(objStudentList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspjesno dodat student";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _unitOfWork.Student.Get(u => u.Id == id);
           
            if(studentFromDb == null) 
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspjesno izmijenjen student";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _unitOfWork.Student.Get(u => u.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Student.Get(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
                _unitOfWork.Student.Remove(obj);
                _unitOfWork.Save();
            TempData["success"] = "Uspjesno izbrisan student";
            return RedirectToAction("Index");
            
           
        }
    }
}

