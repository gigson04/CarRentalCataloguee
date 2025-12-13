using System;
using System.Collections.Generic;

namespace CarRentalCataloguee.Forms.Classes
{
    public static class RentalsRepository
    {
        private static readonly List<Rental> rentals = new List<Rental>();

        // Event raised after the repository changes (add/remove/save)
        public static event EventHandler? RentalsChanged;

        public static List<Rental> LoadAll()
        {
            // return copy to prevent external mutation
            return new List<Rental>(rentals);
        }

        public static void AddRental(Rental rental)
        {
            if (rental == null) throw new ArgumentNullException(nameof(rental));
            rentals.Add(rental);

            // raise notification
            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }

        // optional remove/save APIs:
        public static void SaveAll(IEnumerable<Rental> items)
        {
            rentals.Clear();
            rentals.AddRange(items ?? Array.Empty<Rental>());
            RentalsChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}