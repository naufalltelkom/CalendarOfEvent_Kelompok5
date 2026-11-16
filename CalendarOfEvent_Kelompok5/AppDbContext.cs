using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using CalendarOfEvent_Kelompok5.Models;

namespace CalendarOfEvent_Kelompok5
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kegiatan> Kegiatans { get; set; }

        public DbSet<JadwalPelajaran> JadwalPelajarans { get; set; }

        public DbSet<MataPelajaran> MataPelajarans { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "CalendarOfEvent.db");

            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}