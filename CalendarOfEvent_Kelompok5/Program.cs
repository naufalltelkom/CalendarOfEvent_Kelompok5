
using System;
using System.Linq;
using CalendarOfEvent_Kelompok5.Models;

namespace CalendarOfEvent_Kelompok5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
                DbSeeder.Seed(db);

                int pilihan;

                do
                {
                    Console.Clear();
                    Console.WriteLine("==================================");
                    Console.WriteLine("       CALENDAR OF EVENT");
                    Console.WriteLine("      SMK TELKOM PURWOKERTO");
                    Console.WriteLine("==================================");
                    Console.WriteLine("1. Tambah Kegiatan");
                    Console.WriteLine("2. Tampilkan Kegiatan");
                    Console.WriteLine("3. Ubah Kegiatan");
                    Console.WriteLine("4. Hapus Kegiatan");
                    Console.WriteLine("5. Keluar");
                    Console.WriteLine("==================================");
                    Console.Write("Pilih menu: ");

                    if (!int.TryParse(Console.ReadLine(), out pilihan))
                        pilihan = 0;

                    switch (pilihan)
                    {
                        case 1:
                            TambahKegiatan(db);
                            break;

                        case 2:
                            TampilkanKegiatan(db);
                            break;

                        case 3:
                            UbahKegiatan(db);
                            break;

                        case 4:
                            HapusKegiatan(db);
                            break;

                        case 5:
                            Console.WriteLine("Terima kasih!");
                            break;

                        default:
                            Console.WriteLine("Pilihan tidak valid!");
                            break;
                    }

                    if (pilihan != 5)
                    {
                        Console.WriteLine("\nTekan Enter untuk kembali...");
                        Console.ReadLine();
                    }

                } while (pilihan != 5);
            }
        }

        // CREATE
        static void TambahKegiatan(AppDbContext db)
        {
            Console.WriteLine("\n=== TAMBAH KEGIATAN ===");

            Console.Write("Nama kegiatan: ");
            string nama = Console.ReadLine() ?? "";

            Console.Write("Deskripsi: ");
            string deskripsi = Console.ReadLine() ?? "";

            Console.Write("Tanggal (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime tanggal))
            {
                Console.WriteLine("Format tanggal tidak valid!");
                return;
            }

            Console.Write("Lokasi: ");
            string lokasi = Console.ReadLine() ?? "";

            Console.Write("Sasaran kelas: ");
            string kelas = Console.ReadLine() ?? "";

            Console.Write("Kategori: ");
            string kategori = Console.ReadLine() ?? "";

            var kegiatan = new Kegiatan
            {
                NamaKegiatan = nama,
                Deskripsi = deskripsi,
                Tanggal = tanggal,
                Lokasi = lokasi,
                SasaranKelas = kelas,
                Kategori = kategori
            };

            db.Kegiatans.Add(kegiatan);
            db.SaveChanges();

            Console.WriteLine("Kegiatan berhasil ditambahkan!");
        }

        // READ
        static void TampilkanKegiatan(AppDbContext db)
        {
            Console.WriteLine("\n=== DAFTAR KEGIATAN ===");

            var daftar = db.Kegiatans
                .OrderBy(k => k.Tanggal)
                .ToList();

            if (daftar.Count == 0)
            {
                Console.WriteLine("Belum ada data kegiatan.");
                return;
            }

            foreach (var k in daftar)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("ID       : " + k.Id);
                Console.WriteLine("Nama     : " + k.NamaKegiatan);
                Console.WriteLine("Tanggal  : " + k.Tanggal.ToString("dd-MM-yyyy"));
                Console.WriteLine("Lokasi   : " + k.Lokasi);
                Console.WriteLine("Kelas    : " + k.SasaranKelas);
                Console.WriteLine("Kategori : " + k.Kategori);
            }
            Console.WriteLine("------------------------------");
        }

        // UPDATE
        static void UbahKegiatan(AppDbContext db)
        {
            Console.WriteLine("\n=== UBAH KEGIATAN ===");

            TampilkanKegiatan(db);

            Console.Write("\nMasukkan ID kegiatan: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!");
                return;
            }

            var kegiatan = db.Kegiatans.Find(id);

            if (kegiatan == null)
            {
                Console.WriteLine("Data tidak ditemukan!");
                return;
            }

            Console.Write("Nama baru: ");
            kegiatan.NamaKegiatan = Console.ReadLine() ?? "";

            Console.Write("Lokasi baru: ");
            kegiatan.Lokasi = Console.ReadLine() ?? "";

            Console.Write("Kategori baru: ");
            kegiatan.Kategori = Console.ReadLine() ?? "";

            db.SaveChanges();

            Console.WriteLine("Kegiatan berhasil diperbarui!");
        }

        // DELETE
        static void HapusKegiatan(AppDbContext db)
        {
            Console.WriteLine("\n=== HAPUS KEGIATAN ===");

            TampilkanKegiatan(db);

            Console.Write("\nMasukkan ID kegiatan: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid!");
                return;
            }

            var kegiatan = db.Kegiatans.Find(id);

            if (kegiatan == null)
            {
                Console.WriteLine("Data tidak ditemukan!");
                return;
            }

            Console.Write("Yakin ingin menghapus? (y/n): ");
            string konfirmasi = Console.ReadLine() ?? "";

            if (konfirmasi.ToLower() == "y")
            {
                db.Kegiatans.Remove(kegiatan);
                db.SaveChanges();

                Console.WriteLine("Kegiatan berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("Penghapusan dibatalkan.");
            }
        }
    }
}
