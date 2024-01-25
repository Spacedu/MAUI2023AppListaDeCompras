using AppListaDeCompras.Views;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
namespace AppListaDeCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RemoveBorders();

            MainPage = VersionTracking.IsFirstLaunchEver ? new FirstPage() : new AppShell();
        }

        public void RemoveBorders()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless",(handler, view) => {
#if ANDROID
    handler.PlatformView.Background = null;
    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
    handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
            });

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) => {
#if ANDROID
    handler.PlatformView.Background = null;
    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
    handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
            });
        }
    }
}
