using ListViewMauiSwiping.View;

namespace ListViewMauiSwiping;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new SwipingPage());
	}
}
