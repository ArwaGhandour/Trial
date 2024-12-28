using Clinic_Final.Models.Entities;
using Clinic_Final.Models;
using Clinic_Final.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Clinic_Final.Repos.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDBContext _appDBContext;
        public PatientRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task Create(Patient patient)
        {
            if (patient != null)
            {
                await _appDBContext.patients.AddAsync(patient);
                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Patient patient)
        {
            if (patient != null)
            {
                _appDBContext.patients.Remove(patient);
                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            var pats = await _appDBContext.patients.ToListAsync();
               return pats;
        }

        public async Task<Patient> GetbyID(int id)
        {
            var doc = await _appDBContext.patients.FirstOrDefaultAsync(x => x.PatientId == id);
               return doc;
        }

        public async Task Update(Patient patient)
        {
            _appDBContext.patients.Update(patient);
               await _appDBContext.SaveChangesAsync();
        }
    }
}
