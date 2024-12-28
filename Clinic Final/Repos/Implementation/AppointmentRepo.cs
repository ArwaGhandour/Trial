using Clinic_Final.Models;
using Clinic_Final.Models.Entities;
using Clinic_Final.Models.ViewModels;
using Clinic_Final.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Final.Repos.Implementation
{
    public class AppointmentRepo : IAppointRepo
    {
        private readonly AppDBContext _appDB;
        public AppointmentRepo(AppDBContext appDB)
        {
            _appDB = appDB;
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            var get = await _appDB.appointments.Include(p => p.patients).Include(d => d.doctors).ToListAsync();
            return get;
        }

        public async Task Create(AppointViewModel appvm)
        {
            //هجبهم ك ليست 
            var pat=await _appDB.patients.ToListAsync();
            var doc = await _appDB.Doctors.ToListAsync();
            Appointment app = new Appointment()
            {
                date = appvm.date,
                Notes=appvm.Notes,
                Doctoridd=appvm.DocID,
                Patientidd=appvm.PatID
            };
            await _appDB.appointments.AddAsync(app);
            await _appDB.SaveChangesAsync();

        }

        public  async Task Delete(Appointment app)
        {
            _appDB.appointments.Remove(app);
            await _appDB.SaveChangesAsync();

        }

        public async Task<Appointment> Details(int id)
        {
            var det = await _appDB.appointments.Include(x => x.patients).Include(d => d.doctors).FirstOrDefaultAsync(x => x.AppointmentId == id);
            return det;
        }

       

        public async Task<Appointment> GetById(int id)
        {
            var apps = await _appDB.appointments.FirstOrDefaultAsync(x => x.AppointmentId == id);
            return apps;
        }

        public async Task Update(AppointViewModel appvm)
        {
            var app = await _appDB.appointments.FirstOrDefaultAsync(x => x.AppointmentId == appvm.Id);
            if (app != null)
            {
                app.date = appvm.date;
                app.Notes = appvm.Notes;
                app.Doctoridd = appvm.DocID;
                app.Patientidd = appvm.PatID;
                 _appDB.appointments.Update(app);
                await _appDB.SaveChangesAsync();
            }
        }
    }
}
