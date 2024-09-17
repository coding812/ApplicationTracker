using ApplicationsHelper;

namespace ApplicationTracker;

public partial class App : Application
{
	static DatabaseHelper? databaseHelper;
	public static DatabaseHelper DatabaseHelper
	{
		get
		{
			if (databaseHelper == null)
			{
				databaseHelper = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Applications.db3"));
			}
			return databaseHelper;
		}
	}
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
