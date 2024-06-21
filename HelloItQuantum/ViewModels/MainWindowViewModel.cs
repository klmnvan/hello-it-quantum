namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region Property
		static PlaySectionViewModel playSectionViewModel = new PlaySectionViewModel();

        static HomeViewModel homeViewModel = new HomeViewModel();

		static GameCreateFriendViewModel gameCreateFriendViewModel = new GameCreateFriendViewModel();
		public static HomeViewModel HomeVM { get => homeViewModel; set => homeViewModel = value; }
        public static PlaySectionViewModel PlaySectionVM { get => playSectionViewModel; set => playSectionViewModel = value; }
		public static GameCreateFriendViewModel GameCreateFriendVM { get => gameCreateFriendViewModel; set => gameCreateFriendViewModel = value; }
		#endregion


	}
}