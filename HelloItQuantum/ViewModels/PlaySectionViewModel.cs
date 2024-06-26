using HelloItQuantum.Views;

namespace HelloItQuantum.ViewModels
{
	public class PlaySectionViewModel : MainWindowViewModel
    {

        public void GoCommands()
        {
            //PageSwitch.View = new UserControl();
        }

        public void GoLabyrinth()
        {
            //PageSwitch.View = new UserControl();
        }

        public void GoCreateFriend()
        {
			GameCreateFriendVM = new GameCreateFriendViewModel();
			PageSwitch.View = new GameCreateFriendView();
        }

    }
}