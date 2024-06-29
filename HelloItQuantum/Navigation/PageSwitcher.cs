using Avalonia.Controls;
using HelloItQuantum.Views;
using HelloItQuantum.ViewModels;

namespace HelloItQuantum.Navigation
{
	/// <summary>
	/// Используется для смены страницы/активности
	/// </summary>
	public class PageSwitcher : ViewModelBase
	{
		private UserControl? view = new AuthView();

		/// <summary>
		/// Текущая отображаемая страница
		/// </summary>
		public UserControl View
		{
			get => view;
			set
			{
				view = value;
				OnPropertyChanged(nameof(View));
			}
		}
	}
}
