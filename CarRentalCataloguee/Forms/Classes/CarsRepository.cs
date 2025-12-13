using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarRentalCataloguee.Forms.Classes
{
    public static class CarsRepository
    {
        private static readonly string dataFilePath;
        private static readonly object sync = new object();
        private static List<Car>? cached;

        public static event EventHandler? CarsChanged; // <-- event added

        static CarsRepository()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);
            dataFilePath = Path.Combine(folder, "cars.json");
        }

        // Public static loader required by DashboardForm reflection (and other callers).
        public static List<Car> LoadAll()
        {
            lock (sync)
            {
                if (cached != null)
                    return new List<Car>(cached);

                if (!File.Exists(dataFilePath))
                {
                    cached = new List<Car>();
                    return new List<Car>(cached);
                }

                try
                {
                    string json = File.ReadAllText(dataFilePath);
                    var list = JsonSerializer.Deserialize<List<Car>>(json);
                    cached = list ?? new List<Car>();
                }
                catch
                {
                    cached = new List<Car>();
                }

                return new List<Car>(cached);
            }
        }

        // Helper to save changes when other parts of the app want to persist modifications.
        public static void SaveAll(IEnumerable<Car> cars)
        {
            lock (sync)
            {
                cached = new List<Car>(cars);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(cached, options);
                File.WriteAllText(dataFilePath, json);

                // notify subscribers that cars were changed
                CarsChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}