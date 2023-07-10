using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class Enemy
    {
        public Enemy()
        {
            Episodes = new List<Episode>();
        }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
