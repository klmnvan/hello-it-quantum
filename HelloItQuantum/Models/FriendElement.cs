using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Collections.Generic;

namespace HelloItQuantum.Models
{
	public class FriendElement
	{
		public List<ComboBoxItem> CbElement { get; set; }

		public List<Ellipse>? CbColor { get; set; }
		
		public List<ComboBoxItem>? CbNavigate { get; set; }

	}
}
