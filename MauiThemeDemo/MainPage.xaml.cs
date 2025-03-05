namespace MauiThemeDemo;

/// <summary>
/// A simple page that demonstrates how to change the theme of the application.
/// </summary>
public partial class MainPage : ContentPage
{
	int count = 0;

	/// <summary>
	/// Initializes a new instance of the <see cref="MainPage"/> class.
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Demonstrates changing the theme of the application.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	/// <summary>
	/// Demonstrates changing the theme of the application.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnThemeClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string theme = button.Text;
		ThemeHelper.SetTheme(theme);
		Application.Current!.UserAppTheme = theme == "Dark" ? AppTheme.Dark : AppTheme.Light;
	}
}
