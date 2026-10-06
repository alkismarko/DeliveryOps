using DeliveryOps.Mobile.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryOps.Mobile.Navigation;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task GoToCreateDeliveryAsync()
    {
        var page =
            _serviceProvider.GetRequiredService<CreateDeliveryPage>();

        var navigation = GetNavigation();

        await navigation.PushAsync(page);
    }

    public async Task GoBackAsync()
    {
        var navigation = GetNavigation();

        await navigation.PopAsync();
    }

    private INavigation GetNavigation()
    {
        var page =
            Microsoft.Maui.Controls.Application
                .Current?
                .Windows
                .FirstOrDefault()?
                .Page;

        if (page is null)
        {
            throw new InvalidOperationException(
                "Application navigation is not available.");
        }

        return page.Navigation;
    }
}