using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.ViewsModels
{
        public class ViewEpisode
        {
            public int EpisodeId { get; set; }
            public int SeriesNumber { get; set; }
            public int EpisodeNumber { get; set; }
            public string EpisodeType { get; set; }
            public string Title { get; set; }
            public DateTime EpisodeDate { get; set; }
            public int? AuthorId { get; set; }
            public int? DoctorId { get; set; }
            public string Author { get; set; }
            public string Doctor { get; set; }
            public string Companions { get; set; }
            public string Enemies { get; set; }
        }
}
