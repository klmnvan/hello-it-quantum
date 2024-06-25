using System;
using System.Collections.Generic;
using Avalonia.Controls;
using HelloItQuantum.Navigation;
using HelloItQuantum.Views;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class PlaySectionViewModel : MainWindowViewModel
    {

        public void GoCommands()
        {
            PageSwitch.View = new HotkeysView();
        }

        public void GoLabyrinth()
        {
            //PageSwitch.View = new UserControl();
        }

        public void GoCreateFriend()
        {
            PageSwitch.View = new GameCreateFriendView();
        }

    }
}