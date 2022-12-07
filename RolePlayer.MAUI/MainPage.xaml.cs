namespace RolePlayer.MAUI;

public partial class MainPage : ContentPage
{
	int count = int.MaxValue - 5;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		
		if (count % 2 == 0)
		{
			Image.Source = ImageSource.FromFile("index.jpg");
		}
		else
		{
			Image.Source = ImageSource.FromFile("dotnet_bot.png");
		}

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


