using Avalonia.Controls.ApplicationLifetimes;
using HelloItQuantum.Views;
using Avalonia.Controls;

namespace HelloItQuantum.ViewModels
{
	public class HomeViewModel : MainWindowViewModel
	{
		public void ClickPlay()
		{
			PlaySectionVM = new PlaySectionViewModel();
			PageSwitch.View = new PlaySectionView();
		}

		public void ClickStatistic()
		{
			//PageSwitch.View = new UserControl();
		}

		public void ClickExit()
		{
			Window window = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
			if (window != null)
				window.Close();
		}
	}
}