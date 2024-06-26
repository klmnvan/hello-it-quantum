using Avalonia.Controls;

namespace HelloItQuantum.Function
{
	public static class Converts
	{
		public static ComboBoxItem GenericToItem<T>(T element)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = element;
			return comboBoxItem;
		}
	}
}
