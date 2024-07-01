using System;
using System.Collections.Generic;
using HelloItQuantum.Views;
using ReactiveUI;

namespace HelloItQuantum.ViewModels
{
	public class ProgressViewModel : MainWindowViewModel
	{
        #region
        int pbGameHotkeys = 0;
        int pbGameCreateFriend = 0;
        int pbGameLabyrinth = 0;

        public int PbGameHotkeys { get => pbGameHotkeys; set => SetProperty(ref pbGameHotkeys, value); }
        public int PbGameCreateFriend { get => pbGameCreateFriend; set => SetProperty(ref pbGameCreateFriend, value); }
        public int PbGameLabyrinth { get => pbGameLabyrinth; set => SetProperty(ref pbGameLabyrinth, value); }
        #endregion

        public ProgressViewModel()
        {
            PbGameHotkeys = CurrentUser.GameHotkeys;
            PbGameCreateFriend = CurrentUser.GameCreateFriend;
            PbGameLabyrinth = CurrentUser.GameLabyrinth;
        }

        public void GoBack()
        {
            PageSwitch.View = new HomeView();
        }
    }
}