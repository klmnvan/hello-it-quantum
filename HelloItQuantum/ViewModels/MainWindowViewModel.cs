namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{

        static PlaySectionViewModel playSectionViewModel = new PlaySectionViewModel();

        static HomeViewModel homeViewModel = new HomeViewModel();
        public static HomeViewModel HomeVM { get => homeViewModel; set => homeViewModel = value; }
        public static PlaySectionViewModel PlaySectionVM { get => playSectionViewModel; set => playSectionViewModel = value; }

    }
}