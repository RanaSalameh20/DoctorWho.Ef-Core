using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class Episode
    {
        public Episode()
        {
            //Doctor = new Doctor();
            Enemies = new List<Enemy>();
            Companions = new List<Companion>();
        }
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string? Notes { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public ICollection<Enemy> Enemies { get; set; }
        public ICollection<Companion>? Companions { get; set; }



    }
}
