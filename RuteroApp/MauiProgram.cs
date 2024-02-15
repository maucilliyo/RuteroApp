using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using RuteroApp.Utilidades;

namespace RuteroApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddDbContext<ConexionDb>();
            builder.Services.AddTransient<MainPage>();
            builder.UseMauiApp<App>().UseMauiCommunityToolkitCore();
            //TEST DE CONEXION
            var dbContex = new ConexionDb();
            dbContex.Database.EnsureCreated();
            dbContex.Dispose();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
