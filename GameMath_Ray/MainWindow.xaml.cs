using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameMath_Ray
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Boundary> walls;
    Random rng;
    Player player;

    public MainWindow()
    {
      InitializeComponent();
      rng = new Random();
      Walls();
      player = new Player(Canvas2D);
    }

    private void Canvas2D_MouseMove(object sender, MouseEventArgs e)
    {
      player.UpdatePosition(Mouse.GetPosition(Canvas2D));
      player.Look(walls);
    }

    //Creates a List of Walls and sets them in the scene
    public void Walls()
    {
      walls = new List<Boundary>();
      for (int i = 0; i < 9; i++)
      {
        walls.Add(new Boundary(rng.Next(10, (int)((int)Canvas2D.Width * 0.5f) - 10), rng.Next(10, (int)((int)Canvas2D.Height * 0.5f) - 10),
          rng.Next(10, (int)((int)Canvas2D.Width * 0.5f) - 10), rng.Next(10, (int)((int)Canvas2D.Height * 0.5f) - 10), Canvas2D));
      }
      walls.Add(new Boundary(0, 0, 0, Canvas2D.Height , Canvas2D));
      walls.Add(new Boundary(0, 0, Canvas2D.Width * 0.5f, 0, Canvas2D));
      walls.Add(new Boundary(Canvas2D.Width * 0.5f, 0, Canvas2D.Width * 0.5f, Canvas2D.Height , Canvas2D));
      walls.Add(new Boundary(0, Canvas2D.Height , Canvas2D.Width * 0.5f, Canvas2D.Height , Canvas2D));
    }

    //Redraws the walls in case the mouse moves
    public void ShowWalls()
    {
      foreach (Boundary wall in walls)
        wall.Show();
    }

    private void FovSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      player.ChangeFOV(FovSlider.Value);
      slierLabel.Content = FovSlider.Value;
    }
  }
}
