using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using HelloItQuantum.Function;
using HelloItQuantum.Models;
using Svg.Model;

namespace HelloItQuantum.ViewModels
{
	public class GameCreateFriendViewModel : MainWindowViewModel
	{
		#region Object and Property for Xaml

		Dictionary<int, Color> keyValueColor = new Dictionary<int, Color>
		{
			{ 0, Color.Parse("#0036A0") },
			{ 1, Color.Parse("#F26527") },
			{ 2, Color.Parse("#B21E22") },
			{ 3, Color.Parse("#006838") }
		};

		ObservableCollection<FriendElement> listElements = new ObservableCollection<FriendElement>();
		public ObservableCollection<FriendElement> ListElements { get => listElements; set => SetProperty(ref listElements, value); }

		Panel pChildrens = new Panel();
		public Panel PChildrens { get => pChildrens; set => SetProperty(ref pChildrens, value); }

		#endregion
		public void ClickCreateElement()
		{
			FriendElement friendElement = new FriendElement();
			ObservableCollection<Ellipse> listColors = new ObservableCollection<Ellipse>();
			ObservableCollection<ComboBoxItem> listEl = new ObservableCollection<ComboBoxItem>();
			//Добавление фигур
			SvgParameters svgParameters = new SvgParameters(null, "path { fill: #293558; }");
			listEl.Add(ConvertToItem(CreateElFriend.CreateEllipse(Color.Parse("#293558"), 100)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body1.svg", 100, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body2.svg", 100, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot1.svg", 60, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot2.svg", 60, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateEye(30, Color.Parse("#293558"))));
			listEl.Add(ConvertToItem(CreateElFriend.CreateEye(30, Color.Parse("#293558"))));
			friendElement.CbElement = listEl;
			//Добавление цветов
			foreach (var item in keyValueColor)
			{
				listColors.Add(CreateElFriend.CreateEllipse(item.Value, 50));
			}
			friendElement.CbColor = listColors;
			friendElement.Id = ListElements.Count;
			ListElements.Add(friendElement);
			UpdateDrawing(ListElements.Count - 1);
		}

		private ComboBoxItem ConvertToItem<T>(T element)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = element;
			return comboBoxItem;
		}

		public void UpdateDrawing(int id)
		{
			Color color = keyValueColor[ListElements[id].SelectedColorIndex];
			int indexEl = ListElements[id].SelectedElementIndex;
			Control element = GetElement(indexEl, color);
			if (id < pChildrens.Children.Count) //Изменяем элемент
				pChildrens.Children[id] = element;
			else //Добавляем новый
				pChildrens.Children.Add(element);
		}

		public void UpdateNavigate(int id)
		{
			//pChildrens.Children[id].HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;


			//CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", 30, null, null);
			//
			//	no_shift
			//	
			//	switch (ListElements[id].SelectedNavigate)
			//	{
			//		case 0: return (Control)CreateElFriend.CreateRectangle((Color)color, 100);
			//		case 1: return (Control)CreateElFriend.CreateRectangle((Color)color, 100);
			//		case 2: return (Control)CreateElFriend.CreateRectangle((Color)color, 100);
			//		case 3: return (Control)CreateElFriend.CreateRectangle((Color)color, 100);
			//		default: throw new ArgumentException("Invalid indexElement value.");
			//	}
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

		/// <summary>
		/// Создает элемент нужного цвета
		/// </summary>
		/// <param name="indexElement"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public Control GetElement(int indexElement, Color? color)
		{
			SvgParameters svg;
			if (color != null)
				svg = new SvgParameters(null, $"path {{ fill: #{color.ToString().Substring(3)}; }}");
			switch (indexElement)
			{
				case 0: return (Control)CreateElFriend.CreateEllipse((Color)color, 100);
				case 1: return (Control)CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body1.svg", 100, svg);
				case 2: return (Control)CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body2.svg", 100, svg);
				case 3: return (Control)CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot1.svg", 60, svg);
				case 4: return (Control)CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot2.svg", 60, svg);
				case 5: 
				case 6: 

				default: throw new ArgumentException("Invalid indexElement value.");
			}
		}
	}
}