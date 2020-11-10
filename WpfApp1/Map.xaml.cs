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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
        }

        BitmapImage bim;
        ImageBrush ibr=new ImageBrush();
        Line[] h_lines;
        Line[] v_lines;
        private int gridSize=0;
        int horiz_lin_number_;
        int vert_lin_number;
        public bool ShouldDrawGrid = false;
        private bool IsThisWindowMaximized;
        private bool IsGridDroven=false;

        public void DeleteGrid()
        {
            IsGridDroven = false;
            for (int i=0; i<horiz_lin_number_; i++)
            {
                Canvas1.Children.Remove(h_lines[i]);
            }
            for(int i=0; i<vert_lin_number; i++)
            {
                Canvas1.Children.Remove(v_lines[i]);
            }
        }

        public void DrawGrid()
        {
            int width_;
            int heigth_;
            if(IsGridDroven == true)
            {
                MessageBox.Show("Najpierw usuń starą kratę!!!");
            }
            if (ShouldDrawGrid == true && IsGridDroven==false)
            {
                IsGridDroven = true;
                if (gridSize == 0)
                {
                    MessageBox.Show("Internal error!!! Code=1 Pretensje do Adama...");
                    this.Close();
                }
                if (IsThisWindowMaximized==true)
                {
                    width_ = (int)SystemParameters.MaximizedPrimaryScreenWidth;
                    heigth_ = (int)SystemParameters.MaximizedPrimaryScreenHeight;
                }
                else
                {
                    width_ = (int)this.Width;
                    heigth_ = (int)this.Height;
                }
                horiz_lin_number_ = (int)heigth_ / gridSize;
                vert_lin_number = (int)width_ / gridSize;

                h_lines = new Line[horiz_lin_number_];
                v_lines = new Line[vert_lin_number];

                for (int i = 0; i < vert_lin_number; i++)
                {
                    v_lines[i] = new Line();
                    v_lines[i].Stroke = System.Windows.Media.Brushes.Black;
                    v_lines[i].Fill = System.Windows.Media.Brushes.Black;
                    v_lines[i].X1 = (int)(width_ * i) / vert_lin_number;
                    v_lines[i].X2 = (int)(width_ * i) / vert_lin_number;
                    v_lines[i].Y1 = 0;
                    v_lines[i].Y2 = heigth_;
                    Canvas1.Children.Add(v_lines[i]);
                }
                for (int i = 0; i < horiz_lin_number_; i++)
                {
                    h_lines[i] = new Line();
                    h_lines[i].Stroke = System.Windows.Media.Brushes.Black;
                    h_lines[i].Fill = System.Windows.Media.Brushes.Black;
                    h_lines[i].X1 = 0;
                    h_lines[i].X2 = width_;
                    h_lines[i].Y1 = (int)(heigth_ * i) / horiz_lin_number_;
                    h_lines[i].Y2 = (int)(heigth_ * i) / horiz_lin_number_;
                    Canvas1.Children.Add(h_lines[i]);
                }
            }
        }
       public int gridSize_
        {
            get => gridSize;
            set => gridSize = value;
        }
        public void LoadMap(string path)
        {
            if(path!="")
            {
                bim = new BitmapImage(new Uri(path));
                ibr.ImageSource = bim;
                Canvas1.Background = ibr;
            }
            
        }

        public void ReloadBackgroundMap(string path_)
        {
            LoadMap(path_);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DeleteGrid();
            DrawGrid();
            if (MapWindow.WindowState == WindowState.Maximized)
            {
                IsThisWindowMaximized = true;
            }
        }

        private void Canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*
            Point anchorPoint;
            Ellipse blueRectangle = new Ellipse();
            Canvas1.CaptureMouse();
            anchorPoint = e.MouseDevice.GetPosition(Canvas1);

            double minX =  anchorPoint.X;
            double minY = anchorPoint.Y;
            double maxX =  anchorPoint.X;
            double maxY =anchorPoint.Y;

            Canvas.SetTop(blueRectangle, minY);
            Canvas.SetLeft(blueRectangle, minX);

            
            blueRectangle.Height = 10;
            blueRectangle.Width = 10;
            // Create a blue and a black Brush    
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            // Set Ellipse's width and color    
            blueRectangle.StrokeThickness = 4;
            blueRectangle.Stroke = blackBrush;
            
            // Fill rectangle with blue color    
            blueRectangle.Fill = blueBrush;
            // Add Ellipse to the Grid.    
            Canvas1.Children.Add(blueRectangle);
            */
        }
        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // we are now no longer drawing
            //Canvas1.ReleaseMouseCapture();
        }
    }
}
