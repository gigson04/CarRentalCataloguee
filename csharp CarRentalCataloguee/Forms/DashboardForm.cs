using CarRentalCataloguee.Forms.Classes;

public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();

        // initial population
        UpdateDashboardLabels();

        // Subscribe to repository change events
        CarsRepository.CarsChanged += CarsRepository_Changed;
        RentalsRepository.RentalsChanged += RentalsRepository_Changed;

        // Also refresh when form is activated (optional)
        this.Activated += (s, e) => UpdateDashboardLabels();
    }

    private void CarsRepository_Changed(object? sender, EventArgs e) => UpdateDashboardLabels();
    private void RentalsRepository_Changed(object? sender, EventArgs e) => UpdateDashboardLabels();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Unsubscribe to avoid leaks
        CarsRepository.CarsChanged -= CarsRepository_Changed;
        RentalsRepository.RentalsChanged -= RentalsRepository_Changed;
        base.OnFormClosed(e);
    }

    // existing UpdateDashboardLabels() method remains and will be called on events
}