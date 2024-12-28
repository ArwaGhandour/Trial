using Clinic_Final.Models.Entities;
using Clinic_Final.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Final.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepo _doctorRepo;
        public DoctorController(IDoctorRepo doctorRepo)
        {
            _doctorRepo= doctorRepo;
        }
        public async Task<IActionResult> GetAllDoctors()
        {
            var docs=await _doctorRepo.GetAllDoctors();
            return View(docs);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (doctor == null)
            {
                return View();
            }
            await _doctorRepo.Create(doctor);
            return RedirectToAction("GetAllDoctors");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var docs = await _doctorRepo.GetbyID(id);
            if(docs == null)
            {
               
                return View();
            }
            return View(docs);
        }
        [HttpPost]
        public async Task<IActionResult>Update(Doctor doctor)
        {
            if (doctor != null)
            {
                _doctorRepo.Update(doctor);
                return RedirectToAction("GetAllDoctors");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var doc = await _doctorRepo.GetbyID(id);
            return View(doc);
        }
        [HttpPost,ActionName("Delete")]
        public async Task <IActionResult>Delete(Doctor doctor)
        {
            if (doctor == null)
            {
                return View();
            }
            await _doctorRepo.Delete(doctor);
            return RedirectToAction("GetAllDoctors");
        }
    }
}
