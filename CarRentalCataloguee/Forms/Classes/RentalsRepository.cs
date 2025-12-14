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

        // Event raised after the repository changes (add/remove/save)
        public static event EventHandler? RentalsChanged;

        static RentalsRepository()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);

            // sqlite-net accepts a file path (no "Data Source=" prefix)
            dbPath = Path.Combine(folder, "rentals.db");

            EnsureTable();
        }

        private static SQLiteConnection GetConnection()
        {
            // sqlite-net opens the file if missing.
            // It's fine to create/close connections per operation for desktop apps.
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
                // Order by RentDate desc; sqlite-net returns IQueryable-like Table<T>
                return conn.Table<Rental>().OrderByDescending(r => r.RentDate).ToList();
            }
        }

        public static void AddRental(Rental rental)
        {
            if (rental == null) throw new ArgumentNullException(nameof(rental));

            lock (sync)
            {
                using var conn = GetConnection();
                // Use Action instead of Action<SQLiteConnection> because RunInTransaction expects Action
                conn.RunInTransaction(() =>
                {
                    // Ensure RentalId exists
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

        // Debug helpers (optional)
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