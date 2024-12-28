using Clinic_Final.Models.Entities;
using Clinic_Final.Models.ViewModels;
using Clinic_Final.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Final.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IAppointRepo _appointRepo;
        public AppointmentController(IDoctorRepo doctorRepo, IPatientRepo patientRepo, IAppointRepo appointRepo)
        {
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _appointRepo = appointRepo;
        }
        public async Task<IActionResult> GetAllAppointments()
        {
            var app = await _appointRepo.GetAllAppointments();
            return View(app);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var p = await _patientRepo.GetAllPatients();
            var d = await _doctorRepo.GetAllDoctors();
            AppointViewModel v1 = new AppointViewModel()
            {
                         Doctors=d,
                         Patients=p,
            };
           
            return View(v1);
        }
        [HttpPost]
        public async Task <IActionResult>Create(AppointViewModel apvm)
        {
            await _appointRepo.Create(apvm);
            return RedirectToAction("GetAllAppointments");
        }
       
        [HttpGet]
        public async Task <IActionResult> Update(int id)
        {
            var a = await _appointRepo.GetById(id);
            var p = await _patientRepo.GetAllPatients();
            var d = await _doctorRepo.GetAllDoctors();
            AppointViewModel v1 = new AppointViewModel()
            {
                date=a.date,
                Notes=a.Notes,
                Doctors = d,
                Patients = p,
            };
            return View(v1);
        }
        [HttpPost]
        public async Task<IActionResult>Update(AppointViewModel apvm)
        {
             await _appointRepo.Update(apvm);
            return RedirectToAction("GetAllAppointments");
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var del = await _appointRepo.Details(id);
            return View(del);
        }
        [HttpPost]
        public async Task <IActionResult>Delete(Appointment app)
        {

            await _appointRepo.Delete(app);
            return RedirectToAction("GetAllAppointments");
        }public async Task<IActionResult>Details(int id)
        {
            var detail = await _appointRepo.Details(id);
            return View(detail);
        }
    }
}
