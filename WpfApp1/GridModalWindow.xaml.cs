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
    /// Logika interakcji dla klasy GridModalWindow.xaml
    /// </summary>
    public partial class GridModalWindow : Window
    {
        Map l_map;
        public GridModalWindow(ref Map map_)
        {
            InitializeComponent();
            l_map = map_;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBoxGridSizeSel.SelectedIndex)
            {
                case 0:
                    l_map.gridSize_ = 10;
                    break;
                case 1:
                    l_map.gridSize_ = 20;
                    break;
                case 2:
                    l_map.gridSize_ = 30;
                    break;
                case 3:
                    l_map.gridSize_ = 40;
                    break;
                case 4:
                    l_map.gridSize_ = 50;
                    break;
                case 5:
                    l_map.gridSize_ = 60;
                    break;
                case 6:
                    l_map.gridSize_ = 70;
                    break;
                default:
                    l_map.gridSize_ = 50;
                    break;
            }
            l_map.ShouldDrawGrid = true;
            l_map.DrawGrid();
            this.Close();
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
