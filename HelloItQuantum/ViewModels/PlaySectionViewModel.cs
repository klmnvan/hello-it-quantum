using HelloItQuantum.Views;

namespace HelloItQuantum.ViewModels
{
	public class PlaySectionViewModel : MainWindowViewModel
    {

        public void GoCommands()
        {
            HotkeysVM = new HotkeysViewModel();
            PageSwitch.View = new HotkeysView();
        }

        public void GoLabyrinth()
        {

            PageSwitch.View = new LabyrinthView();
        }

        public void GoCreateFriend()
        {
			GameCreateFriendVM = new GameCreateFriendViewModel();
			PageSwitch.View = new GameCreateFriendView();
        }

    }
}