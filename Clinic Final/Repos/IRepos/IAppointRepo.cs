using Clinic_Final.Models.Entities;
using Clinic_Final.Models.ViewModels;

namespace Clinic_Final.Repos.IRepos
{
    public interface IAppointRepo
    {
        public Task<IEnumerable<Appointment>> GetAllAppointments();
        public Task Create(AppointViewModel appvm);
        public Task Update(AppointViewModel appvm);
        public Task Delete(Appointment appoint);
        public Task<Appointment> Details(int id);
        public Task<Appointment> GetById(int id);
    }
}
