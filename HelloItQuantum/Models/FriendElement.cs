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

		public int Id { get; set; }
		public ObservableCollection<ComboBoxItem> CbElement { get; set; }

		public ObservableCollection<Ellipse> CbColor { get; set; }
		
		public ObservableCollection<ComboBoxItem>? CbNavigate { get; set; }

		public int SelectedElementIndex
		{
			get => selectedElementIndex;
			set
			{
				selectedElementIndex = value;
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

	}
}
