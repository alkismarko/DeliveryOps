using Microsoft.Extensions.Logging;
using DeliveryOps.Application.Abstractions;
using DeliveryOps.Application.UseCases;
using DeliveryOps.Infrastructure.Services;
using DeliveryOps.Mobile.ViewModels;
using DeliveryOps.Mobile.Views;
using DeliveryOps.Domain.Services;
using DeliveryOps.Mobile.Navigation;

namespace DeliveryOps.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IDeliveryRepository,InMemoryDeliveryRepository>();

            builder.Services.AddSingleton<IProductCatalogService,FakeProductCatalogService>();

            builder.Services.AddSingleton<PackageRuleService>();

            builder.Services.AddTransient<GetDeliveriesUseCase>();
            builder.Services.AddTransient<CreateDeliveryUseCase>();

            builder.Services.AddTransient<DeliveriesViewModel>();
            builder.Services.AddTransient<DeliveriesPage>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddTransient<GetProductsUseCase>();
            builder.Services.AddTransient<CreateDeliveryUseCase>();

            builder.Services.AddTransient<CreateDeliveryViewModel>();
            builder.Services.AddTransient<CreateDeliveryPage>();
            return builder.Build();
        }
    }
}
