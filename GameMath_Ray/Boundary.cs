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
  class Boundary
  {
    Line line;
    public Vector a, b;
    public double x1, y1, x2, y2;
    Canvas drawArea;

    public Boundary(double x1, double y1, double x2, double y2, Canvas drawArea)
    {
      this.x1 = x1;
      this.x2 = x2;
      this.y1 = y1;
      this.y2 = y2;
      this.drawArea = drawArea;
      Draw();
    }

    /// <summary>
    /// Creates a Line which we are using as a Wall
    /// </summary>
    /// <param name="x1">sets position</param>
    /// <param name="y1">sets position</param>
    /// <param name="x2">sets position</param>
    /// <param name="y2">sets position</param>
    /// <param name="drawArea">canvas you draw on</param>
    public void Draw()
    {
      a = new Vector(x1, y1);
      b = new Vector(x2, y2);

      line = new Line
      {
        X1 = x1,
        Y1 = y1,
        X2 = x2,
        Y2 = y2,
        Stroke = new SolidColorBrush(Colors.Yellow)
      };
      drawArea.Children.Add(line);
    }

    public void Show()
    {
      drawArea.Children.Add(line);
    }
  }
}
