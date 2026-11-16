using System;
using System.Linq;
using CalendarOfEvent_Kelompok5.Models;

namespace CalendarOfEvent_Kelompok5
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (!db.Kegiatans.Any())
            {
                db.Kegiatans.AddRange(
                    new Kegiatan
                    {
                        NamaKegiatan = "Upacara Bendera",
                        Deskripsi = "Upacara rutin setiap hari Senin",
                        Tanggal = new DateTime(2026, 1, 5),
                        Lokasi = "Lapangan Sekolah",
                        SasaranKelas = "Semua Kelas",
                        Kategori = "Rutin"
                    },
                    new Kegiatan
                    {
                        NamaKegiatan = "Class Meeting",
                        Deskripsi = "Pekan olahraga dan seni antar kelas",
                        Tanggal = new DateTime(2026, 1, 12),
                        Lokasi = "Aula Sekolah",
                        SasaranKelas = "X, XI, XII",
                        Kategori = "Akademik"
                    },
                    new Kegiatan
                    {
                        NamaKegiatan = "Pentas Seni",
                        Deskripsi = "Penampilan seni akhir semester",
                        Tanggal = new DateTime(2026, 1, 20),
                        Lokasi = "Aula Sekolah",
                        SasaranKelas = "Semua Kelas",
                        Kategori = "Seni"
                    });
            }

            if (!db.MataPelajarans.Any())
            {
                db.MataPelajarans.AddRange(
                    new MataPelajaran
                    {
                        NamaMapel = "Pemrograman",
                        NamaGuru = "Budi Santoso",
                        Keterangan = "Mata pelajaran produktif RPL"
                    },
                    new MataPelajaran
                    {
                        NamaMapel = "Matematika",
                        NamaGuru = "Siti Aminah",
                        Keterangan = "Mata pelajaran umum"
                    });
            }

            if (!db.JadwalPelajarans.Any())
            {
                db.JadwalPelajarans.AddRange(
                    new JadwalPelajaran
                    {
                        Kelas = "XI RPL 1",
                        Hari = "Senin",
                        NamaMapel = "Pemrograman",
                        Guru = "Budi Santoso",
                        Ruangan = "Lab RPL",
                        JamMulai = new TimeSpan(7, 0, 0),
                        JamSelesai = new TimeSpan(9, 30, 0),
                        Status = "Aktif"
                    },
                    new JadwalPelajaran
                    {
                        Kelas = "XI RPL 1",
                        Hari = "Selasa",
                        NamaMapel = "Matematika",
                        Guru = "Siti Aminah",
                        Ruangan = "Ruang 12",
                        JamMulai = new TimeSpan(7, 0, 0),
                        JamSelesai = new TimeSpan(8, 30, 0),
                        Status = "Aktif"
                    });
            }

            db.SaveChanges();
        }
    }
}