using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliveryOps.Application.UseCases;
using DeliveryOps.Domain.Entities;
using DeliveryOps.Domain.Enums;
using DeliveryOps.Mobile.Navigation;

namespace DeliveryOps.Mobile.ViewModels;

public partial class CreateDeliveryViewModel : ObservableObject
{
    private readonly GetProductsUseCase _getProductsUseCase;
    private readonly CreateDeliveryUseCase _createDeliveryUseCase;
    private readonly INavigationService _navigationService;

    public ObservableCollection<Product> Products { get; } = new();

    public IReadOnlyList<DeliveryPriority> Priorities { get; } =
        Enum.GetValues<DeliveryPriority>();

    [ObservableProperty]
    private Product? selectedProduct;

    [ObservableProperty]
    private string customerName = string.Empty;

    [ObservableProperty]
    private string customerPhone = string.Empty;

    [ObservableProperty]
    private DateTime deliveryDate = DateTime.Today.AddDays(1);

    [ObservableProperty]
    private DeliveryPriority selectedPriority =
        DeliveryPriority.Standard;

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    public CreateDeliveryViewModel(
        GetProductsUseCase getProductsUseCase,
        CreateDeliveryUseCase createDeliveryUseCase,
        INavigationService navigationService)
    {
        _getProductsUseCase = getProductsUseCase;
        _createDeliveryUseCase = createDeliveryUseCase;
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task LoadProductsAsync()
    {
        if (Products.Count > 0)
            return;

        var products =
            await _getProductsUseCase.ExecuteAsync();

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    [RelayCommand]
    private async Task CreateDeliveryAsync()
    {
        ErrorMessage = string.Empty;

        if (SelectedProduct is null)
        {
            ErrorMessage = "Please select a product.";
            return;
        }

        if (string.IsNullOrWhiteSpace(CustomerName))
        {
            ErrorMessage = "Customer name is required.";
            return;
        }

        if (string.IsNullOrWhiteSpace(CustomerPhone))
        {
            ErrorMessage = "Customer phone is required.";
            return;
        }

        if (IsLoading)
            return;

        try
        {
            IsLoading = true;

            var request = new CreateDeliveryRequest
            {
                ProductCode = SelectedProduct.Code,
                CustomerName = CustomerName,
                CustomerPhone = CustomerPhone,
                DeliveryDate = DeliveryDate,
                Priority = SelectedPriority
            };

            await _createDeliveryUseCase.ExecuteAsync(request);

            await _navigationService.GoBackAsync();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsLoading = false;
        }
    }
}