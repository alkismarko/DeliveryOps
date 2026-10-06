namespace DeliveryOps.Mobile.Navigation;

public interface INavigationService
{
    Task GoToCreateDeliveryAsync();

    Task GoBackAsync();
}