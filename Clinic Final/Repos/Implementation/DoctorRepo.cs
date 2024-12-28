using Clinic_Final.Models;
using Clinic_Final.Models.Entities;
using Clinic_Final.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Final.Repos.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AppDBContext _appDBContext;
        public DoctorRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            //بجيب ليست من الدكتور 
            var docs = await _appDBContext.Doctors.ToListAsync();
            return docs;
        }

        public async Task Create(Doctor doctor)
        {
            if (doctor != null) {
                await _appDBContext.Doctors.AddAsync(doctor);
                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Doctor doctor)
        {
            if (doctor != null)
            {
                 _appDBContext.Doctors.Remove(doctor);
                await _appDBContext.SaveChangesAsync();
            }
        }

       

        public async Task<Doctor> GetbyID(int id)
        {
            var doc = await _appDBContext.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
            return doc;
        }

        public async Task Update(Doctor doctor)
        {
            _appDBContext.Doctors.Update(doctor);
            await _appDBContext.SaveChangesAsync();
        }
    }
}
