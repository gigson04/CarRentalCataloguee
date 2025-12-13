// ... inside btnConfirmRent_Click after selectedCar.Availability = false;

// Persist change to cars
var allCars = cars ?? CarsRepository.LoadAll();
int idx = allCars.FindIndex(c => c.CarID == selectedCar.CarID);
if (idx >= 0) allCars[idx] = selectedCar;
else allCars.Add(selectedCar);

// Save to repository (this will raise CarsChanged)
CarsRepository.SaveAll(allCars);

// Create and record rental (use your Rental type shape)
var rental = new Rental
{
    // Assign properties relevant to your Rental class.
    // If your RentalId is int, let repository assign it or set an appropriate value.
    RentalId = /* your id logic */,
    CarId = selectedCar.CarID,
    RenterName = fullName,
    DriverLicense = license,
    RenterAddress = address,
    RenterBirthdate = dtpBirthday.Value,
    RentDate = DateTime.Now,
    ReturnDate = selectedReturnDate.Value,
    EstimatedCost = estimatedCost
};

// Add to repository (this will raise RentalsChanged)
RentalsRepository.AddRental(rental);