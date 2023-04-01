using RolePlayer.MAUI.UI;

namespace RolePlayer.MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

