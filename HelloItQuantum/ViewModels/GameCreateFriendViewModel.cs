using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Svg;
using Svg.Model;

namespace HelloItQuantum.ViewModels
{
	public class GameCreateFriendViewModel : MainWindowViewModel
	{
		private Uri baseUri = new Uri("avares://HelloItQuantum/");

		List<ComboBoxItem> cbItems = new List<ComboBoxItem>();
		public List<ComboBoxItem> CbItems { get => cbItems; set => cbItems = value; }

		public GameCreateFriendViewModel()
		{
			Rectangle rectangle = new Rectangle();
			rectangle.Width = 100;
			rectangle.Height = 100;
			rectangle.RadiusX = 10;
			rectangle.RadiusY = 10;
			rectangle.Fill = new SolidColorBrush(Color.FromRgb(0, 54, 160));
			AddItemToComboBox(rectangle);

			Ellipse ellipse = new Ellipse();
			ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 54, 160));
			ellipse.Width = 100;
			ellipse.Height = 100;
			AddItemToComboBox(ellipse);
		
			SvgParameters svgParameters = new SvgParameters(null, "path { fill: #0036A0; }");
			AddSvgToComboBox("/Assets/ImgCreateFriend/body.svg", 100, null, svgParameters);
			AddSvgToComboBox("/Assets/ImgCreateFriend/foot1.svg", null, 60, null);
			AddSvgToComboBox("/Assets/ImgCreateFriend/foot2.svg", null, 60, null);
			AddSvgToComboBox("/Assets/ImgCreateFriend/eye.svg", 30, null, null);
			AddSvgToComboBox("/Assets/ImgCreateFriend/eye.svg", 40, null, null);
		}

		private void AddSvgToComboBox(string path, double? width, double? height, SvgParameters? svgParameters)
		{
			SvgImage svgImage = new SvgImage();
			svgImage.Source = SvgSource.Load(path, baseUri, svgParameters);
			Image convertedImage = new Image
			{
				Source = svgImage,
				Width = width != null ? (double) width : double.NaN,
				Height = height != null ? (double) height : double.NaN,
			};
			AddItemToComboBox(convertedImage);
		}

		private void AddItemToComboBox<T>(T element)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = element;
			CbItems.Add(comboBoxItem);
		}	

	}
}