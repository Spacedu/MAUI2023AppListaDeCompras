using Microsoft.Extensions.Logging;
using Mopups.Hosting;

namespace AppListaDeCompras
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Light.ttf", "PoppinsLight"); 
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular"); //OpenSansRegular
                    fonts.AddFont("Poppins-ExtraBold.ttf", "PoppinsExtraBold");  //OpenSansSemibold
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
