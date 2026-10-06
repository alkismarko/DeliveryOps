using DeliveryOps.Mobile.ViewModels;

namespace DeliveryOps.Mobile.Views;

public partial class CreateDeliveryPage : ContentPage
{
    private readonly CreateDeliveryViewModel _viewModel;

    public CreateDeliveryPage(
        CreateDeliveryViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadProductsCommand.ExecuteAsync(null);
    }
}