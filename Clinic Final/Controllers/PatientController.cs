using Clinic_Final.Models.Entities;
using Clinic_Final.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Final.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepo _patientRepo;
        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public async Task<IActionResult> GetAllPatients()
        {
            var docs = await _patientRepo.GetAllPatients();
            return View(docs);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (patient == null)
            {
                return View();
            }
            await _patientRepo.Create(patient);
            return RedirectToAction("GetAllPatients");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var docs = await _patientRepo.GetbyID(id);
            if (docs == null)
            {

                return View();
            }
            return View(docs);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Patient patient)
        {
            if (patient != null)
            {
                _patientRepo.Update(patient);
                return RedirectToAction("GetAllPatients");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var doc = await _patientRepo.GetbyID(id);
            return View(doc);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Patient patient)
        {
            if (patient == null)
            {
                return View();
            }
            await _patientRepo.Delete(patient);
            return RedirectToAction("GetAllPatients");
        }
    }
}
