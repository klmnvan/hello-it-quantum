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
		public static Rectangle CreateRectangle(Color color)
		{
			Rectangle rectangle = new Rectangle();
			rectangle.Width = 100;
			rectangle.Height = 100;
			rectangle.RadiusX = 10;
			rectangle.RadiusY = 10;
			rectangle.Fill = new SolidColorBrush(color);
			return rectangle;
		}

		public static Ellipse CreateEllipse(Color color, double? size)
		{
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = new SolidColorBrush(color);
			ellipse.Width = size == null? 100 : (double) size;
			ellipse.Height = size == null ? 100 : (double) size;
			return ellipse;
		}

		public static Image GetSvgImage(string path, double? width, double? height, SvgParameters? svgParameters)
		{
			SvgImage svgImage = new SvgImage();
			svgImage.Source = SvgSource.Load(path, baseUri, svgParameters);
			Image convertedImage = new Image
			{
				Source = svgImage,
				Width = width != null ? (double)width : double.NaN,
				Height = height != null ? (double)height : double.NaN,
			};
			return convertedImage;
		}

	}
}
