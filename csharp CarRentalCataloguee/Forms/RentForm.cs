


var allCars = cars ?? CarsRepository.LoadAll();
int idx = allCars.FindIndex(c => c.CarID == selectedCar.CarID);
if (idx >= 0) allCars[idx] = selectedCar;
else allCars.Add(selectedCar);


CarsRepository.SaveAll(allCars);


var rental = new Rental
{
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

RentalsRepository.AddRental(rental);