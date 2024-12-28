using Clinic_Final.Models.Entities;

namespace Clinic_Final.Repos.IRepos
{
    public interface IDoctorRepo
    {
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task Create(Doctor doctor);
        public Task Delete(Doctor doctor);
        public Task Update(Doctor doctor);

        public Task<Doctor> GetbyID(int id);
    }
}
