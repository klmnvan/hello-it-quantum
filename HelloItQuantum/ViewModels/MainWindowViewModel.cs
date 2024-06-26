namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region ViewModel-objects
		static PlaySectionViewModel playSectionViewModel = new PlaySectionViewModel();

        static HomeViewModel homeViewModel = new HomeViewModel();

        static GameCreateFriendViewModel? gameCreateFriendViewModel;

        static HotkeysViewModel hotkeysViewModel = new HotkeysViewModel();
		public static HomeViewModel HomeVM { get => homeViewModel; set => homeViewModel = value; }
        public static PlaySectionViewModel PlaySectionVM { get => playSectionViewModel; set => playSectionViewModel = value; }
		public static GameCreateFriendViewModel GameCreateFriendVM { get => gameCreateFriendViewModel; set => gameCreateFriendViewModel = value; }
        public static HotkeysViewModel HotkeysVM { get => hotkeysViewModel; set => hotkeysViewModel = value; }
        #endregion
    }
}