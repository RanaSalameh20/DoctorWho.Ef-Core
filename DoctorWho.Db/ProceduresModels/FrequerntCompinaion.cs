using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    [Keyless]
    public class FrequerntCompinaion
    {   
        public string CompanionName { get; set; }

        [Column("CompanionAppearances")]
        public int Frequency { get; set;}
    }
}
