using expensesetracker;
using expensesetracker.Models.DbService;
using Microcharts.Maui;
using Microsoft.Extensions.Logging;

namespace expensestracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ExpensesDB>();
            builder.Services.AddTransient<ADD_PAGE>();
            builder.Services.AddTransient<VIEWINCOME_PAGE>();
            builder.Services.AddTransient<MainPage>();
            
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
