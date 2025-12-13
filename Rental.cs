using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarRentalCataloguee.Forms.Classes
{
    public static class RentalsRepository
    {
        private static string GetFilePath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "rentals.json");
        }

        public static List<Rental> LoadAll()
        {
            try
            {
                string path = GetFilePath();
                if (!File.Exists(path)) return new List<Rental>();
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Rental>>(json) ?? new List<Rental>();
            }
            catch
            {
                return new List<Rental>();
            }
        }

        public static void SaveAll(List<Rental> rentals)
        {
            try
            {
                string path = GetFilePath();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(rentals, options);
                File.WriteAllText(path, json);
            }
            catch
            {
                // swallow or log
            }
        }

        public static void AddRental(Rental rental)
        {
            var list = LoadAll();
            list.Add(rental);
            SaveAll(list);
        }
    }
}