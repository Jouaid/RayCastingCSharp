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
  class MyLine
  {
    Line line;

    public void Make(double x1, double y1, double x2, double y2, Canvas drawArea)
    {
      line = new Line()
      {
        X1 = x1,
        X2 = x2,
        Y1 = y1,
        Y2 = y2,
        Stroke = new SolidColorBrush(Colors.Red),
      };
      drawArea.Children.Add(line);
    }
  }
}
