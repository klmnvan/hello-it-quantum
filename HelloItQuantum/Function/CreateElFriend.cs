using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Svg;
using Svg.Model;
using System;
using System.IO;

namespace HelloItQuantum.Function
{
	public static class CreateElFriend
	{
		private static Uri baseUri = new Uri("avares://HelloItQuantum/");

		public static Ellipse CreateEllipse(Color color, double size)
		{
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = new SolidColorBrush(color);
			ellipse.Width = size;
			ellipse.Height = size;
			return ellipse;
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

		public static Panel CreateEye(double size, Color color)
		{
			Panel panel = new Panel();
			Ellipse eyeball = CreateEllipse(color, size-5);
			panel.Children.Add(eyeball);
			Image eye = CreateSvgImage("/Assets/ImgCreateFriend/eye.svg", size, null);
			panel.Children.Add(eye);
			return panel;
		}

	}
}
