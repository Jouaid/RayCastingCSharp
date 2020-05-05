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
  class Ray
  {
    Vector position;
    Vector direction;

    Canvas drawArea;
    Line myLine;

    public Ray(Vector pos, double rad, Canvas drawArea)
    {
      this.drawArea = drawArea;

      position = new Vector(pos.X, pos.Y);
      direction = new Vector(Math.Sin(rad), Math.Cos(rad));
      direction.Normalize();

      myLine = new Line()
      {
        X1 = position.X,
        Y1 = position.Y,
        X2 = position.X + direction.X * 50,
        Y2 = position.Y + direction.Y * 50,
        Stroke = new SolidColorBrush(Colors.White)
      };
      drawArea.Children.Add(myLine);
    }

    public void RemoveShow()
    {
      drawArea.Children.Remove(myLine);
    }

    public void Show(Vector pos, double rad)
    {
      position = pos;
      direction.X += Math.Sin(rad);
      direction.Y += Math.Cos(rad);
      direction.Normalize();

      myLine.X1 = pos.X;
      myLine.Y1 = pos.Y;
      myLine.X2 = pos.X + direction.X * 10;
      myLine.Y2 = pos.Y + direction.Y * 10;
    }

    public Vector Cast(Boundary wall)
    {
      //Wall Pos
      double x1 = wall.a.X;
      double y1 = wall.a.Y;
      double x2 = wall.b.X;
      double y2 = wall.b.Y;

      //Pos of ray and end point
      double x3 = position.X;
      double y3 = position.Y;
      double x4 = position.X + direction.X;
      double y4 = position.Y + direction.Y;

      //The Denominator for T and U 
      double den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
      // If 0 they are parallel
      if (den == 0)
        return new Vector(0, 0);

      //Wiki
      double t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
      double u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

      if (t > 0 && t < 1 && u > 0)
      {
        Vector point = new Vector();
        //Intersection point Wiki
        point.X = x1 + t * (x2 - x1);
        point.Y = y1 + t * (y2 - y1);
        return point;
      }
      else
        return new Vector(0, 0);
    }
  }
}
