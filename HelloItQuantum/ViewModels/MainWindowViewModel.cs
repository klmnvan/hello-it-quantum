namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{

        static PlaySectionViewModel playSectionViewModel = new PlaySectionViewModel();

        //HomeViewModel homeViewModel = new HomeViewModel();
        //public HomeViewModel HomeVM { get => homeViewModel; set => homeViewModel = value; }
        public static PlaySectionViewModel PlaySectionVM { get => playSectionViewModel; set => playSectionViewModel = value; }
    }
}
