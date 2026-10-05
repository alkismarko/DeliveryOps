using DeliveryOps.Mobile.ViewModels;

namespace DeliveryOps.Mobile.Views;

public partial class DeliveriesPage : ContentPage
{
    public DeliveriesPage(DeliveriesViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}