using HelloItQuantum.Models;

namespace HelloItQuantum.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region ViewModel-objects
		static HomeViewModel homeVM = new HomeViewModel();
		public static HomeViewModel HomeVM { get => homeVM; set => homeVM = value; }

        static AuthViewModel authVM = new AuthViewModel();
        public static AuthViewModel AuthVM { get => authVM; set => authVM = value; }

        static ProgressViewModel progressVM;
        public static ProgressViewModel ProgressVM { get => progressVM; set => progressVM = value; }

        static CreateProfileViewModel createProfileVM = new CreateProfileViewModel();
        public static CreateProfileViewModel CreateProfileVM { get => createProfileVM; set => createProfileVM = value; }

        static PlaySectionViewModel? playSectionVM;
		public static PlaySectionViewModel PlaySectionVM { get => playSectionVM; set => playSectionVM = value; }

		static GameCreateFriendViewModel gameCreateFriendVM = new GameCreateFriendViewModel();
		public static GameCreateFriendViewModel GameCreateFriendVM { get => gameCreateFriendVM; set => gameCreateFriendVM = value; }

		static HotkeysViewModel hotkeysVM;
        public static HotkeysViewModel HotkeysVM { get => hotkeysVM; set => hotkeysVM = value; }
        
        static LabyrinthViewModel labyrinthVM = new LabyrinthViewModel();
		public static LabyrinthViewModel LabyrinthVM { get => labyrinthVM; set => labyrinthVM = value; }

        static User currentUser;
        public static User CurrentUser { get => currentUser; set => currentUser = value; }
        #endregion
    }
}