using Clinic_Final.Models.Entities;

namespace Clinic_Final.Models.ViewModels
{
    public class AppointViewModel
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string Notes { get; set; }
        public int DocID {  get; set; }
        public int PatID {  get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

    }
}
