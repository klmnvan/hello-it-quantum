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

        public void GoCreateFriend() => PageSwitch.View = new GameCreateFriendView();
   
        public void GoBack() => PageSwitch.View = new HomeView();
    }
}