using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameMath_Ray
{
  class Circle
  {
    Ellipse circle;
    public void Make(double x1, double y1, double x2, double y2, int size, Canvas drawArea)
    {
      circle = new Ellipse()
      {
        Width = size,
        Height = size,
        Margin = new Thickness(x1, y1, x2, y2),
        Stroke = new SolidColorBrush(Colors.Green),
        Fill = new SolidColorBrush(Colors.Green),
      };
      drawArea.Children.Add(circle);
    }
  }
}
