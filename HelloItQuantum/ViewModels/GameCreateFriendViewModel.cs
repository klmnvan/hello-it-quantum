using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		List<ComboBoxItem> listElement = new List<ComboBoxItem>();
		public List<ComboBoxItem> ListElement { get => listElement; set => SetProperty(ref listElement, value); }

		List<Ellipse> listColors = new List<Ellipse>();
		public List<Ellipse> ListColors { get => listColors; set => SetProperty(ref listColors, value); }

		ObservableCollection<FriendElement> listElements = new ObservableCollection<FriendElement>();
		public ObservableCollection<FriendElement> ListElements { get => listElements; set => SetProperty(ref listElements, value); }
		#endregion

		public GameCreateFriendViewModel()
		{
			//Добавление фигур
			AddItemToComboBox(CreateElFriend.CreateRectangle(Color.Parse("#0036A0")));
			AddItemToComboBox(CreateElFriend.CreateEllipse(Color.Parse("#0036A0"), null));
			SvgParameters svgParameters = new SvgParameters(null, "path { fill: #0036A0; }");
			AddItemToComboBox(CreateElFriend.GetSvgImage("/Assets/ImgCreateFriend/body.svg", 100, null, svgParameters));
			AddItemToComboBox(CreateElFriend.GetSvgImage("/Assets/ImgCreateFriend/foot1.svg", null, 60, null));
			AddItemToComboBox(CreateElFriend.GetSvgImage("/Assets/ImgCreateFriend/foot2.svg", null, 60, null));
			AddItemToComboBox(CreateElFriend.GetSvgImage("/Assets/ImgCreateFriend/eye.svg", 30, null, null));
			AddItemToComboBox(CreateElFriend.GetSvgImage("/Assets/ImgCreateFriend/eye.svg", 40, null, null));
			//Добавление цветов
			ListColors.Add(CreateElFriend.CreateEllipse(Color.Parse("#0036A0"), 50));
			ListColors.Add(CreateElFriend.CreateEllipse(Color.Parse("#F26527"), 50));
			ListColors.Add(CreateElFriend.CreateEllipse(Color.Parse("#B21E22"), 50));
			ListColors.Add(CreateElFriend.CreateEllipse(Color.Parse("#006838"), 50));
		}

		public void ClickCreateElement()
		{
			FriendElement friendElement = new FriendElement();
			friendElement.CbElement = CopyComboBoxItem(ListElement);
			friendElement.CbColor = CopyEllipse(ListColors);
			ListElements.Add(friendElement);

			//Не получается добавить несколько элементов.
			//Пофиксить: сделать добавление одного элемента листа и его вывод. то есть выбираем все поля и нажимаем ок
			//
			//
			//Color c = ((SolidColorBrush)ListColor[0].Fill).Color;			
		}

		/// <summary>
		/// Добавляет элемент в ComboBox
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="element"></param>
		private void AddItemToComboBox<T>(T element)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = element;
			listElement.Add(comboBoxItem);
		}

		private List<ComboBoxItem> CopyComboBoxItem(List<ComboBoxItem> elements)
		{
			List<ComboBoxItem> elementCopy = new List<ComboBoxItem>();
            foreach (var item in elements)
            {
				elementCopy.Add(item);
			}
			return elementCopy;
		}

		private List<Ellipse> CopyEllipse(List<Ellipse> colors)
		{
			List<Ellipse> colorCopy = new List<Ellipse>();
			foreach (var item in colors)
			{
				colorCopy.Add(item);
			}
			return colorCopy;
		}

	}
}