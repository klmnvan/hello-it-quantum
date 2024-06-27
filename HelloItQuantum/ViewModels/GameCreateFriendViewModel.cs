using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using HelloItQuantum.Function;
using HelloItQuantum.Models;
using HelloItQuantum.Views;

namespace HelloItQuantum.ViewModels
{
	public class GameCreateFriendViewModel : MainWindowViewModel
	{
		Dictionary<int, Color> keyValueColor = new Dictionary<int, Color>
		{
			{ 0, Color.Parse("#0036A0") },
			{ 1, Color.Parse("#F26527") },
			{ 2, Color.Parse("#B21E22") },
			{ 3, Color.Parse("#006838") }
		};

		#region Object and Property for Xaml
		ObservableCollection<FriendElement> listElements = new ObservableCollection<FriendElement>();
		public ObservableCollection<FriendElement> ListElements { get => listElements; set => SetProperty(ref listElements, value); }

		Panel pChildrens = new Panel();
		public Panel PChildrens { get => pChildrens; set => SetProperty(ref pChildrens, value); }

		bool isVisibleHello = false;
		public bool IsVisibleHello { get => isVisibleHello; set => SetProperty(ref isVisibleHello, value); }

		string btnContent = "СОЗДАТЬ";
		public string BtnContent { get => btnContent; set => SetProperty(ref btnContent, value); }

		SolidColorBrush btnColor = new SolidColorBrush(Color.Parse("#7CBE41"));
		public SolidColorBrush BtnColor { get => btnColor; set => SetProperty(ref btnColor, value); }
		#endregion

		public void ClickCreateElement()
		{
			FriendElement friendElement = new FriendElement();
			ObservableCollection<Ellipse> lColors = new ObservableCollection<Ellipse>();
			ObservableCollection<ComboBoxItem> lElements = new ObservableCollection<ComboBoxItem>();
			ObservableCollection<ComboBoxItem> lNavigateOne = new ObservableCollection<ComboBoxItem>();
			ObservableCollection<ComboBoxItem> lNavigateTwo = new ObservableCollection<ComboBoxItem>();
			for (int i = 0; i < 7; i++)
			{
				lElements.Add(Converts.GenericToItem(CreateElFriend.CreateElement(i, Color.Parse("#293558"))));
			}
			friendElement.CbElement = lElements;
			foreach (var item in keyValueColor)
			{
				lColors.Add(CreateElFriend.CreateEllipse(50, item.Value));
			}
			friendElement.CbColor = lColors;
			lNavigateOne.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/no_shift.svg", 30, null)));
			lNavigateOne.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/left.svg", 30, null)));
			lNavigateOne.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/right.svg", 30, null)));
			friendElement.CbNavigateOne = lNavigateOne;
			lNavigateTwo.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/no_shift.svg", 30, null)));
			lNavigateTwo.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/top.svg", 30, null)));
			lNavigateTwo.Add(Converts.GenericToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/bottom.svg", 30, null)));
			friendElement.CbNavigateTwo = lNavigateTwo;
			friendElement.Id = ListElements.Count;
			ListElements.Add(friendElement);
			UpdateDrawing(ListElements.Count - 1);
		}

		public void ClickCreateFriend()
		{
			if (btnContent == "СОЗДАТЬ")
			{
				IsVisibleHello = true;
				BtnContent = "ВЫЙТИ";
				BtnColor = new SolidColorBrush(Color.Parse("#F26527"));
			}
			else
			{
				PageSwitch.View = new PlaySectionView();
			}
		}

		public void UpdateDrawing(int id)
		{
			Color color = keyValueColor[ListElements[id].SelectedColorIndex];
			int indexEl = ListElements[id].SelectedElementIndex;
			Control element = CreateElFriend.CreateElement(indexEl, color);
			if (id < pChildrens.Children.Count)
				pChildrens.Children[id] = element; //Изменяем элемент
			else
				pChildrens.Children.Add(element); //Добавляем новый
			UpdateNavigate(id);
		}

		public void UpdateNavigate(int id)
		{
			int element = ListElements[id].SelectedElementIndex;
			pChildrens.Children[id].Margin = new Thickness(0, 0, 0, 0);
			if (element >= 3 && element <= 6)
			{
				int margin = (element == 3 || element == 4) ? 27 : 24;
				switch (ListElements[id].SelectedNavigateOne)
				{
					case 1:
						pChildrens.Children[id].HorizontalAlignment = HorizontalAlignment.Left;
						pChildrens.Children[id].Margin = new Thickness(margin, 0, 0, 0);
						break;
					case 2:
						pChildrens.Children[id].HorizontalAlignment = HorizontalAlignment.Right;
						pChildrens.Children[id].Margin = new Thickness(0, 0, margin, 0);
						break;
					default: pChildrens.Children[id].HorizontalAlignment = HorizontalAlignment.Center; break;
				}
				if (element == 5 || element == 6)
				{
					switch (ListElements[id].SelectedNavigateTwo)
					{
						case 1:
							pChildrens.Children[id].VerticalAlignment = VerticalAlignment.Top;
							pChildrens.Children[id].Margin = new Thickness(pChildrens.Children[id].Margin.Left, 40, pChildrens.Children[id].Margin.Right, 0);
							break;
						case 2:
							pChildrens.Children[id].VerticalAlignment = VerticalAlignment.Bottom;
							pChildrens.Children[id].Margin = new Thickness(pChildrens.Children[id].Margin.Left, 0, pChildrens.Children[id].Margin.Right, 40);
							break;
						default: pChildrens.Children[id].VerticalAlignment = VerticalAlignment.Center; break;
					}
				}
				else
				{
					pChildrens.Children[id].VerticalAlignment = VerticalAlignment.Bottom;
				}
			}
			else
			{
				pChildrens.Children[id].HorizontalAlignment = HorizontalAlignment.Center;
				pChildrens.Children[id].VerticalAlignment = VerticalAlignment.Center;
			}
		}

		/// <summary>
		/// Видимость дополнительного параметра для сдвига фигуры
		/// </summary>
		/// <param name="id"></param>
		public void UpdateVisible(int id)
		{
			if (ListElements[id].SelectedElementIndex == 5 || ListElements[id].SelectedElementIndex == 6)
			{
				ListElements[id].IsVisibleNavigateOne = true;
				ListElements[id].IsVisibleNavigateTwo = true;
			}
			else if (ListElements[id].SelectedElementIndex == 3 || ListElements[id].SelectedElementIndex == 4)
			{
				ListElements[id].IsVisibleNavigateOne = true;
				ListElements[id].IsVisibleNavigateTwo = false;
			}
			else
			{
				ListElements[id].IsVisibleNavigateOne = false;
				ListElements[id].IsVisibleNavigateTwo = false;
			}
		}
	}
}