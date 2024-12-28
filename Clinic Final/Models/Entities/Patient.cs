namespace Clinic_Final.Models.Entities
{
    public class Patient
    {
        public int PatientId {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
