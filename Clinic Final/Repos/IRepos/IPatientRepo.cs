using Clinic_Final.Models.Entities;

namespace Clinic_Final.Repos.IRepos
{
    public interface IPatientRepo
    {
        public Task<IEnumerable<Patient>> GetAllPatients();
        public Task Create(Patient patient);
        public Task Delete(Patient patient);
        public Task Update(Patient patient);

        public Task<Patient> GetbyID(int id);
    }
}
