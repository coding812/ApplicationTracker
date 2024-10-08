﻿using Microsoft.Extensions.Logging;
using ApplicationsHelper;
using System.Diagnostics;
namespace ApplicationTracker;

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
			});

		builder.Services.AddMauiBlazorWebView();
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "applications.db");
		Debug.WriteLine(dbPath);
        builder.Services.AddSingleton<DatabaseHelper>(sp => new DatabaseHelper(dbPath));

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
