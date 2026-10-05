using Microsoft.Extensions.Logging;
using DeliveryOps.Application.Abstractions;
using DeliveryOps.Application.UseCases;
using DeliveryOps.Infrastructure.Services;
using DeliveryOps.Mobile.ViewModels;
using DeliveryOps.Mobile.Views;

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
            builder.Services.AddSingleton<IDeliveryService, FakeDeliveryService>();
            builder.Services.AddTransient<GetDeliveriesUseCase>();
            builder.Services.AddTransient<DeliveriesViewModel>();
            builder.Services.AddTransient<DeliveriesPage>();
            return builder.Build();
        }
    }
}
