using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Svg;
using Svg.Model;
using System;

namespace HelloItQuantum.Function
{
	public static class CreateElFriend
	{
		private static Uri baseUri = new Uri("avares://HelloItQuantum/");
		private static Panel CreateEye(double size, Color color)
		{
			Panel panel = new Panel();
			Ellipse eyeball = CreateEllipse(size - 2, color);
			panel.Children.Add(eyeball);
			Image eye = CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", size, null);
			panel.Children.Add(eye);
			return panel;
		}
		private static Rectangle CreateRectangle(double size, Color color)
		{
			Rectangle rectangle = new Rectangle();
			rectangle.Width = size;
			rectangle.Height = size;
			rectangle.RadiusX = 10;
			rectangle.RadiusY = 10;
			rectangle.Fill = new SolidColorBrush(color);
			return rectangle;
		}
		public static Image CreateSvgImage(string path, double height, SvgParameters? svgParameters)
		{
			SvgImage svgImage = new SvgImage();
			svgImage.Source = SvgSource.Load(path, baseUri, svgParameters);
			Image convertedImage = new Image
			{
				Source = svgImage,
				Height = height
			};
			return convertedImage;
		}
		public static Ellipse CreateEllipse(double size, Color color)
		{
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = new SolidColorBrush(color);
			ellipse.Width = size;
			ellipse.Height = size;
			return ellipse;
		}
		public static Control CreateElement(int indexElement, Color color)
		{
			string textColor = color.ToString().Substring(3);
			SvgParameters svg = new SvgParameters(null, $"path {{ fill: #{textColor}; }}");
			switch (indexElement)
			{
				case 0: return (Control) CreateEllipse(110, color);
				case 1: return (Control) CreateRectangle(110, color);
				case 2: return (Control) CreateSvgImage("/Assets/ImgCreateFriend/body.svg", 110, svg);
				case 3: return (Control) CreateSvgImage("/Assets/ImgCreateFriend/foot1.svg", 60, svg);
				case 4: return (Control) CreateSvgImage("/Assets/ImgCreateFriend/foot2.svg", 60, svg);
				case 5: return (Control) CreateEye(35, color);
				case 6: return (Control) CreateEye(45, color);
				default: return (Control) CreateEllipse(110, color);
			}
		}
	}
}
