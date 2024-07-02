using HelloItQuantum.Views;

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
            ProgressVM = new ProgressViewModel();
            PageSwitch.View = new ProgressView();
        }

		public void ClickExit()
		{
            AuthVM = new AuthViewModel();
            PageSwitch.View = new AuthView();
            /* //Это код для закрытия программы
             * Window window = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
			if (window != null)
				window.Close();*/
        }
	}
}