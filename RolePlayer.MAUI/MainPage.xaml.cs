namespace RolePlayer.MAUI;

public partial class MainPage : ContentPage
{
    private readonly ActivityIndicator _activityIndicator = new() { IsRunning = true, Color = Colors.SeaGreen };
    private readonly Label _label = new() { Text = "Процесс 1" };
    private readonly Label _label2 = new() { Text = "Процесс 2" };
    private readonly ProgressBar _progressBar = new() { ProgressColor = Colors.SeaGreen };

    public MainPage()
    {
        Content = new StackLayout
        {
            Padding = 20,
            Children = { _label, _label2, _progressBar, _activityIndicator }
        };
        // InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await RunProgress();
        await RunActivityIndicator();
        base.OnAppearing();

        async Task RunActivityIndicator()
        {
            var count = 0;
            while (count != 100)
            {
                _label2.Text = $"Состояние процесса: {count} %";
                await Task.Delay(2000);
                count += 10;
            }

            _label2.Text = "Процесс закончен";
            _activityIndicator.IsRunning = false;
        }

        async Task RunProgress()
        {
            while (_progressBar.Progress < 0.9999)
            {
                _progressBar.Progress += 0.0001;
                _label.Text = $"Состояние процесса: {Math.Round(_progressBar.Progress, 2) * 100} %";
                await Task.Delay(1);
            }

            _label.Text = "Процесс закончен";
        }
    }

    private void OnLoadFileCLicked(object sender, EventArgs e)
    {
        // SemanticScreenReader.Announce(CounterBtn.Text);
    }
}