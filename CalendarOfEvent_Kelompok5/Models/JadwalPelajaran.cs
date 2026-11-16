using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarOfEvent_Kelompok5.Models
{
    public class JadwalPelajaran
    {
        public int Id { get; set; }

        public string Kelas { get; set; }

        public string Hari { get; set; }

        public string NamaMapel { get; set; }

        public string Guru { get; set; }

        public string Ruangan { get; set; }

        public TimeSpan JamMulai { get; set; }

        public TimeSpan JamSelesai { get; set; }

        public string Status { get; set; }
    }
}