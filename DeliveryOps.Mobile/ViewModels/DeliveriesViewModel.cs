using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliveryOps.Application.UseCases;
using DeliveryOps.Domain.Entities;
using DeliveryOps.Mobile.Navigation;

namespace DeliveryOps.Mobile.ViewModels;

public partial class DeliveriesViewModel : ObservableObject
{
    private readonly GetDeliveriesUseCase _getDeliveriesUseCase;
    private readonly INavigationService _navigationService;
    public ObservableCollection<Delivery> Deliveries { get; } = new();

    [ObservableProperty]
    private bool isLoading;

    public DeliveriesViewModel(
    GetDeliveriesUseCase getDeliveriesUseCase,
    INavigationService navigationService)
    {
        _getDeliveriesUseCase = getDeliveriesUseCase;
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task LoadDeliveriesAsync()
    {
        if (IsLoading)
            return;

        try
        {
            IsLoading = true;

            var deliveries = await _getDeliveriesUseCase.ExecuteAsync();

            Deliveries.Clear();

            foreach (var delivery in deliveries)
            {
                Deliveries.Add(delivery);
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task OpenCreateDeliveryAsync()
    {
        await _navigationService.GoToCreateDeliveryAsync();
    }
}