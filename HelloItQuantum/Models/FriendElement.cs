using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using HelloItQuantum.ViewModels;
using System.Collections.ObjectModel;

namespace HelloItQuantum.Models
{
	public class FriendElement : MainWindowViewModel
	{
		int selectedElementIndex = 0;
		int selectedColorIndex = 0;
		int selectedNavigateOne = 0;
		int selectedNavigateTwo = 0;
		bool isVisibleNavigateOne = false;
		bool isVisibleNavigateTwo = false;
		public int Id { get; set; }
		public ObservableCollection<ComboBoxItem> CbElement { get; set; }
		public ObservableCollection<Ellipse> CbColor { get; set; }	
		public ObservableCollection<ComboBoxItem> CbNavigateOne { get; set; }
		public ObservableCollection<ComboBoxItem> CbNavigateTwo { get; set; }		
		public int SelectedElementIndex
		{
			get => selectedElementIndex;
			set
			{ 
				selectedElementIndex = value;
				GameCreateFriendVM.UpdateVisible(Id);
				GameCreateFriendVM.UpdateDrawing(Id);
			}
		}
		public int SelectedColorIndex
		{
			get => selectedColorIndex;
			set
			{
				selectedColorIndex = value;
				GameCreateFriendVM.UpdateDrawing(Id);
			}
		}
		public int SelectedNavigateOne
		{
			get => selectedNavigateOne;
			set
			{
				selectedNavigateOne = value;
				GameCreateFriendVM.UpdateNavigate(Id);
			}
		}
		public int SelectedNavigateTwo
		{
			get => selectedNavigateTwo;
			set
			{
				selectedNavigateTwo = value;
				GameCreateFriendVM.UpdateNavigate(Id);
			}
		}
		public bool IsVisibleNavigateOne
		{
			get => isVisibleNavigateOne;
			set => SetProperty(ref isVisibleNavigateOne, value);
		}
		public bool IsVisibleNavigateTwo
		{
			get => isVisibleNavigateTwo;
			set => SetProperty(ref isVisibleNavigateTwo, value);
		}
	}
}
