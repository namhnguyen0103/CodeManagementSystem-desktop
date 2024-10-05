using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace HeThongQuanLy;

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
				fonts.AddFont("Mulish-Regular.ttf", "MulishRegular");
				fonts.AddFont("Mulish-SemiBold.ttf", "MulishSemibold");
				fonts.AddFont("Mulish-Light.ttf", "MulishLight");
			});
			builder.Services.AddTransientPopup<Views.LoginPopup, ViewModels.LoginPopupViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif
		// builder.Services.AddSingleton<ViewModels.ShoppingCartViewModel>();
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if  IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
		return builder.Build();
	}
}
