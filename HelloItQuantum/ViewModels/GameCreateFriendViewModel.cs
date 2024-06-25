using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
		public Panel PChildrens { get => pChildrens; set => SetProperty(ref pChildrens, value);}
		
		#endregion	
		public void ClickCreateElement()
		{
			FriendElement friendElement = new FriendElement();
			ObservableCollection<Ellipse> listColors= new ObservableCollection<Ellipse>();
			ObservableCollection<ComboBoxItem> listEl = new ObservableCollection<ComboBoxItem>();
			//Добавление фигур
			SvgParameters svgParameters = new SvgParameters(null, "path { fill: #0036A0; }");
			listEl.Add(ConvertToItem(CreateElFriend.CreateRectangle(Color.Parse("#0036A0"), 100)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateEllipse(Color.Parse("#0036A0"), 100)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body.svg", 100, null, svgParameters)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot1.svg", null, 60, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot2.svg", null, 60, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", 30, null, null)));
			listEl.Add(ConvertToItem(CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", 40, null, null)));
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
				case 0: return (Control) CreateElFriend.CreateRectangle((Color) color, 100);
				case 1: return (Control) CreateElFriend.CreateEllipse((Color) color, 100);
				case 2: return (Control) CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/body.svg", 100, null, svg);
				case 3: return (Control) CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot1.svg", null, 60, svg);
				case 4: return (Control) CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/foot2.svg", null, 60, svg);

				case 5: return (Control) CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", 30, null, null);
				case 6: return (Control) CreateElFriend.CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", 40, null, null);

				default: throw new ArgumentException("Invalid indexElement value.");
			}		
		}
	}
}