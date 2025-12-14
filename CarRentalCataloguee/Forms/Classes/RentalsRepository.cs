using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarRentalCataloguee.Forms.Classes
{
    public static class RentalsRepository
    {
        private static readonly string dbPath;
        private static readonly object sync = new object();

        public static event EventHandler? RentalsChanged;

        static RentalsRepository()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);

            dbPath = Path.Combine(folder, "rentals.db");

            EnsureTable();
        }

        private static SQLiteConnection GetConnection()
        {
          
            return new SQLiteConnection(dbPath);
        }

        private static void EnsureTable()
        {
            lock (sync)
            {
                using var conn = GetConnection();
                conn.CreateTable<Rental>();
            }
        }

        public static List<Rental> LoadAll()
        {
            lock (sync)
            {
                using var conn = GetConnection();
                return conn.Table<Rental>().OrderByDescending(r => r.RentDate).ToList();
            }
        }

        public static void AddRental(Rental rental)
        {
            if (rental == null) throw new ArgumentNullException(nameof(rental));

            lock (sync)
            {
                using var conn = GetConnection();
                conn.RunInTransaction(() =>
                {
                    if (string.IsNullOrWhiteSpace(rental.RentalId))
                        rental.RentalId = Guid.NewGuid().ToString();

                    conn.Insert(rental);
                });
            }

            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void DeleteRental(string rentalId)
        {
            if (string.IsNullOrWhiteSpace(rentalId)) throw new ArgumentNullException(nameof(rentalId));

            lock (sync)
            {
                using var conn = GetConnection();
                var affected = conn.Delete<Rental>(rentalId);
                if (affected > 0)
                    RentalsChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void SaveAll(IEnumerable<Rental> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            lock (sync)
            {
                using var conn = GetConnection();
                conn.RunInTransaction(() =>
                {
                    conn.DeleteAll<Rental>();
                    foreach (var r in items)
                    {
                        if (string.IsNullOrWhiteSpace(r.RentalId))
                            r.RentalId = Guid.NewGuid().ToString();
                        conn.Insert(r);
                    }
                });
            }

            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }

        public static string GetDatabasePath() => dbPath;

        public static int GetRowCount()
        {
            lock (sync)
            {
                using var conn = GetConnection();
                return conn.Table<Rental>().Count();
            }
        }
    }
}