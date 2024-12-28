using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Final.Models.Entities
{
    public class Appointment
    {
        public int AppointmentId {  get; set; }
        public DateTime date { get; set; }
        public string Notes { get; set; }
        public int Doctoridd {  get; set; }
        [ForeignKey("Doctoridd")]
        public Doctor doctors { get; set; }
        public int Patientidd {  get; set; }
        [ForeignKey("Patientidd")]
        public Patient patients { get; set; }
    }
}
