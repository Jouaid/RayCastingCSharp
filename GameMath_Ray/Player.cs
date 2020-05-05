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
  class Player
  {
    Ellipse player;
    Vector position;
    Ray[] rays;
    int size = 10;

    Canvas drawArea;

    List<Line> listOfLine;
    Line line;

    public Player(Canvas drawArea)
    {
      this.drawArea = drawArea;
      player = new Ellipse
      {
        Margin = new Thickness(drawArea.Width * 0.5f, drawArea.Height * 0.5f, drawArea.Width * 0.5f, drawArea.Height * 0.5f),
        Width = size,
        Height = size,
        Stroke = new SolidColorBrush(Colors.Red),
        Fill = new SolidColorBrush(Colors.Red),
      };
      drawArea.Children.Add(player);

      listOfLine = new List<Line>();

      rays = new Ray[360];
      for (int i = 0; i < rays.Length; i++)
      {
        rays[i] = new Ray(position, Math.PI * i / 180.0, drawArea);
        listOfLine.Add(line = new Line());
      }
    }

    /// <summary>
    /// Changes player position and Updates the rays position according to the targets.
    /// </summary>
    /// <param name="a">Mouse Pos</param>
    public void UpdatePosition(Point a)
    {
      position = (Vector)a;

      //Redraw the rays according to the new player pos
      for (int i = 0; i < rays.Length; i++)
        rays[i].Show(position, Math.PI * i / 180.0);

      //Sets new player pos
      player.Margin = new Thickness(position.X - size * 0.5f, position.Y - size * 0.5f, position.X, position.Y);
    }

    public void Look(List<Boundary> walls)
    {
      for (int i = 0; i < rays.Length; i++)
      {
        Vector closest = new Vector(0, 0);
        double record = 50000;

        //We check if one of the rays is intersecting a wall
        foreach (Boundary wall in walls)
        {
          Vector point = new Vector(0, 0);
          //Checks for intersection
          point = rays[i].Cast(wall);

          //If there is an intersection we take the point
          if (point != new Vector(0, 0))
          {
            double d = Math.Sqrt(Math.Pow((position.X - point.X), 2) + Math.Pow((position.Y - point.Y), 2));

            if (d < record)
            {
              record = d;
              closest = point;
            }
          }
        }

        //We draw according to the intersection above
        if (closest != new Vector(0, 0))
        {
          drawArea.Children.Remove(listOfLine[i]);

          listOfLine[i].X1 = position.X;
          listOfLine[i].Y1 = position.Y;
          listOfLine[i].X2 = closest.X;
          listOfLine[i].Y2 = closest.Y;
          listOfLine[i].Stroke = new SolidColorBrush(Colors.Orange);

          drawArea.Children.Add(listOfLine[i]);
        }
        else
          drawArea.Children.Remove(listOfLine[i]);
      }
    }

    public void ChangeFOV(double number)
    {
      //We remove old player add new one
      drawArea.Children.Remove(player);
      player = new Ellipse
      {
        Margin = new Thickness(drawArea.Width * 0.5f, drawArea.Height * 0.5f, drawArea.Width * 0.5f, drawArea.Height * 0.5f),
        Width = size,
        Height = size,
        Stroke = new SolidColorBrush(Colors.Red),
        Fill = new SolidColorBrush(Colors.Red),
      };
      drawArea.Children.Add(player);

      //We remove all the ray casts
      for (int i = 0; i < rays.Length; i++)
      {
        drawArea.Children.Remove(listOfLine[i]);
        rays[i].RemoveShow();
      }

      //We empty the rays and the lines
      rays = null;
      listOfLine = null;
      rays = new Ray[(int)number];
      listOfLine = new List<Line>();

      //We remake the rays and lines according to the value we inputed
      for (int i = 0; i < rays.Length; i++)
      {
        rays[i] = new Ray(-position, Math.PI * i / 180.0, drawArea);
        listOfLine.Add(line = new Line());
      }
    }
  }
}
