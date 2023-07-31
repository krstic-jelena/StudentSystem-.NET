using Microsoft.AspNetCore.Mvc;
using StSluzba.DataAccess.Data;
using StSluzba.DataAccess.Repository.IRepository;
using StSluzba.Models;

namespace StSluzbaWeb.Controllers
{
    
    
    public class KurseviController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KurseviController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Kursevi> objKurseviList = _unitOfWork.Kursevi.GetAll().ToList();
            return View(objKurseviList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kursevi obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Kursevi.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspjesno dodat kursevi";
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
            var kurseviFromDb = _unitOfWork.Kursevi.Get(u => u.Id == id);
           
            if(kurseviFromDb == null) 
            {
                return NotFound();
            }
            return View(kurseviFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Kursevi obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Kursevi.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uspjesno izmijenjen kursevi";
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
            var kurseviFromDb = _unitOfWork.Kursevi.Get(u => u.Id == id);

            if (kurseviFromDb == null)
            {
                return NotFound();
            }
            return View(kurseviFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Kursevi.Get(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
                _unitOfWork.Kursevi.Remove(obj);
                _unitOfWork.Save();
            TempData["success"] = "Uspjesno izbrisan kursevi";
            return RedirectToAction("Index");
            
           
        }
    }
}

