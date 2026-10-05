using DeliveryOps.Mobile.Views;

namespace DeliveryOps.Mobile;

public partial class App : Microsoft.Maui.Controls.Application
{
    private readonly DeliveriesPage _deliveriesPage;

    public App(DeliveriesPage deliveriesPage)
    {
        InitializeComponent();

        _deliveriesPage = deliveriesPage;
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        return new Window(
            new NavigationPage(_deliveriesPage));
    }
}