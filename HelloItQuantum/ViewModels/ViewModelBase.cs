using CommunityToolkit.Mvvm.ComponentModel;
using HelloItQuantum.Navigation;

namespace HelloItQuantum.ViewModels
{
	public class ViewModelBase : ObservableObject
	{
		#region navigation
		private static PageSwitcher _pageSwitch = new PageSwitcher();
		public static PageSwitcher PageSwitch { get => _pageSwitch; set => _pageSwitch = value; }
		#endregion
	}
}
