using System;

namespace CalendarOfEvent_Kelompok5.Models
{
    public class Kegiatan
    {
        public int Id { get; set; }

        public string NamaKegiatan { get; set; }

        public string Deskripsi { get; set; }

        public DateTime Tanggal { get; set; }

        public string Lokasi { get; set; }

        public string SasaranKelas { get; set; }

        public string Kategori { get; set; }
    }
}
