namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region ViewModel-objects
		static HomeViewModel homeVM = new HomeViewModel();
		public static HomeViewModel HomeVM { get => homeVM; set => homeVM = value; }

		static PlaySectionViewModel? playSectionVM;
		public static PlaySectionViewModel PlaySectionVM { get => playSectionVM; set => playSectionVM = value; }

		static GameCreateFriendViewModel? gameCreateFriendVM;
		public static GameCreateFriendViewModel GameCreateFriendVM { get => gameCreateFriendVM; set => gameCreateFriendVM = value; }

		static HotkeysViewModel hotkeysVM = new HotkeysViewModel();
        public static HotkeysViewModel HotkeysVM { get => hotkeysVM; set => hotkeysVM = value; }
        
        static LabyrinthViewModel labyrinthVM = new LabyrinthViewModel();
		public static LabyrinthViewModel LabyrinthVM { get => labyrinthVM; set => labyrinthVM = value; }
		#endregion
	}
}