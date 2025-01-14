using Microsoft.Extensions.Logging;
using ReviewFlixMobile.ViewModels;
using ReviewFlixMobile.Views;
using ReviewFlixMobile.Services;

namespace ReviewFlixMobile
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

            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddTransient<FilmListViewModel>();
            builder.Services.AddTransient<FilmDetailsViewModel>();
            builder.Services.AddTransient<FilmListPage>();
            builder.Services.AddTransient<FilmDetailsPage>();
            builder.Services.AddTransient<AddReviewPage>();
            builder.Services.AddTransient<AddReviewViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
