csharp CarRentalCataloguee/Forms/Classes/RentalsRepository.cs
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

namespace CarRentalCataloguee.Forms.Classes
{
    public static class RentalsRepository
    {
        private static readonly string dbPath;
        private static readonly string connectionString;
        private static readonly object sync = new object();

        public static event EventHandler? RentalsChanged;

        static RentalsRepository()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);

            dbPath = Path.Combine(folder, "rentals.db");
            connectionString = $"Data Source={dbPath}";

            EnsureTable();
        }

        private static void EnsureTable()
        {
            lock (sync)
            {
                using var conn = new SqliteConnection(connectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Rentals (
                        RentalId TEXT PRIMARY KEY,
                        CarId TEXT,
                        RenterName TEXT,
                        DriverLicense TEXT,
                        RenterAddress TEXT,
                        RenterBirthdate TEXT,
                        RentDate TEXT,
                        ReturnDate TEXT,
                        EstimatedCost REAL
                      );";
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Rental> LoadAll()
        {
            var list = new List<Rental>();
            lock (sync)
            {
                using var conn = new SqliteConnection(connectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT RentalId, CarId, RenterName, DriverLicense, RenterAddress, RenterBirthdate, RentDate, ReturnDate, EstimatedCost FROM Rentals ORDER BY RentDate DESC;";
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var r = new Rental
                    {
                        RentalId = rdr.IsDBNull(0) ? Guid.NewGuid().ToString() : rdr.GetString(0),
                        CarId = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                        RenterName = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                        DriverLicense = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                        RenterAddress = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                        RenterBirthdate = rdr.IsDBNull(5) ? DateTime.MinValue : DateTime.Parse(rdr.GetString(5)),
                        RentDate = rdr.IsDBNull(6) ? DateTime.MinValue : DateTime.Parse(rdr.GetString(6)),
                        ReturnDate = rdr.IsDBNull(7) ? DateTime.MinValue : DateTime.Parse(rdr.GetString(7)),
                        EstimatedCost = rdr.IsDBNull(8) ? 0.0 : rdr.GetDouble(8)
                    };
                    list.Add(r);
                }
            }
            return list;
        }

        public static void AddRental(Rental rental)
        {
            if (rental == null) throw new ArgumentNullException(nameof(rental));

            lock (sync)
            {
                using var conn = new SqliteConnection(connectionString);
                conn.Open();
                using var tran = conn.BeginTransaction();
                using var cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT INTO Rentals (RentalId, CarId, RenterName, DriverLicense, RenterAddress, RenterBirthdate, RentDate, ReturnDate, EstimatedCost)
                      VALUES ($id,$car,$name,$license,$addr,$birth,$rent,$return,$cost);";

                cmd.Parameters.AddWithValue("$id", rental.RentalId ?? Guid.NewGuid().ToString());
                cmd.Parameters.AddWithValue("$car", (object?)rental.CarId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$name", (object?)rental.RenterName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$license", (object?)rental.DriverLicense ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$addr", (object?)rental.RenterAddress ?? DBNull.Value);
                cmd.Parameters.AddWithValue("$birth", rental.RenterBirthdate == DateTime.MinValue ? DBNull.Value : (object)rental.RenterBirthdate.ToString("o"));
                cmd.Parameters.AddWithValue("$rent", rental.RentDate == DateTime.MinValue ? DBNull.Value : (object)rental.RentDate.ToString("o"));
                cmd.Parameters.AddWithValue("$return", rental.ReturnDate == DateTime.MinValue ? DBNull.Value : (object)rental.ReturnDate.ToString("o"));
                cmd.Parameters.AddWithValue("$cost", rental.EstimatedCost);

                cmd.ExecuteNonQuery();
                tran.Commit();
            }

            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SaveAll(IEnumerable<Rental> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            lock (sync)
            {
                using var conn = new SqliteConnection(connectionString);
                conn.Open();
                using var tran = conn.BeginTransaction();
                using (var delete = conn.CreateCommand())
                {
                    delete.CommandText = "DELETE FROM Rentals;";
                    delete.ExecuteNonQuery();
                }
                using var insert = conn.CreateCommand();
                insert.CommandText =
                    @"INSERT INTO Rentals (RentalId, CarId, RenterName, DriverLicense, RenterAddress, RenterBirthdate, RentDate, ReturnDate, EstimatedCost)
                      VALUES ($id,$car,$name,$license,$addr,$birth,$rent,$return,$cost);";

                foreach (var r in items)
                {
                    insert.Parameters.Clear();
                    insert.Parameters.AddWithValue("$id", r.RentalId ?? Guid.NewGuid().ToString());
                    insert.Parameters.AddWithValue("$car", (object?)r.CarId ?? DBNull.Value);
                    insert.Parameters.AddWithValue("$name", (object?)r.RenterName ?? DBNull.Value);
                    insert.Parameters.AddWithValue("$license", (object?)r.DriverLicense ?? DBNull.Value);
                    insert.Parameters.AddWithValue("$addr", (object?)r.RenterAddress ?? DBNull.Value);
                    insert.Parameters.AddWithValue("$birth", r.RenterBirthdate == DateTime.MinValue ? DBNull.Value : (object)r.RenterBirthdate.ToString("o"));
                    insert.Parameters.AddWithValue("$rent", r.RentDate == DateTime.MinValue ? DBNull.Value : (object)r.RentDate.ToString("o"));
                    insert.Parameters.AddWithValue("$return", r.ReturnDate == DateTime.MinValue ? DBNull.Value : (object)r.ReturnDate.ToString("o"));
                    insert.Parameters.AddWithValue("$cost", r.EstimatedCost);
                    insert.ExecuteNonQuery();
                }
                tran.Commit();
            }

            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}