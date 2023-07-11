using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        void CreateDoctor(int doctorNumber, string doctorName,
                DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate)
        {
            var doctor = new Doctor
            {
                DoctorNumber = doctorNumber,
                DoctorName = doctorName,
                BirthDate = birthDate,
                FirstEpisodeDate = firstEpisodeDate,
                LastEpisodeDate = lastEpisodeDate,


            };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        
        void UpdateDoctor(int doctorId, string newDoctorName, DateTime newBirthDate, int episodeId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            var episode = _context.Episodes.FirstOrDefault(e => e.EpisodeId == episodeId);

            if (doctor != null)
            {
                doctor.DoctorName = newDoctorName;
                doctor.BirthDate = newBirthDate;
            }
            if (episode != null)
            {
                doctor.Episodes.Add(episode);
            }

            _context.SaveChanges();
        }
        void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors
                .Include(d => d.Episodes)
                .FirstOrDefault(d => d.DoctorId == doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            //var state = _context.ChangeTracker.DebugView.ShortView;
            _context.SaveChanges();
        }
        public Doctor GetDoctorById(int? doctorId)
        {
            if (doctorId.HasValue)
            {
                var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                return doctor;
            }

            return null;
        }

        void GetAllDoctors()
        {
            var doctors = _context.Doctors
                .Include(d => d.Episodes)
                .ToList();

            doctors.ForEach(d =>
            {
                Console.WriteLine(d.DoctorName + " has " + d.Episodes.Count + " Episodes.");
            });

        }

    }
}
