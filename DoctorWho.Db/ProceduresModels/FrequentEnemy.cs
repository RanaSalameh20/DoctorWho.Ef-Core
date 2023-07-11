using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.ProceduresModels
{
    [Keyless]
    public class FrequentEnemy
    {
        public string EnemyName { get; set; }

        public int EnemyAppearances { get; set; }
    }
}
