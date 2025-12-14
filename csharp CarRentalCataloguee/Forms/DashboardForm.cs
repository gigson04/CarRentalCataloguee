using CarRentalCataloguee.Forms.Classes;

public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();

        UpdateDashboardLabels();

        CarsRepository.CarsChanged += CarsRepository_Changed;
        RentalsRepository.RentalsChanged += RentalsRepository_Changed;

        this.Activated += (s, e) => UpdateDashboardLabels();
    }

    private void CarsRepository_Changed(object? sender, EventArgs e) => UpdateDashboardLabels();
    private void RentalsRepository_Changed(object? sender, EventArgs e) => UpdateDashboardLabels();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        CarsRepository.CarsChanged -= CarsRepository_Changed;
        RentalsRepository.RentalsChanged -= RentalsRepository_Changed;
        base.OnFormClosed(e);
    }

}