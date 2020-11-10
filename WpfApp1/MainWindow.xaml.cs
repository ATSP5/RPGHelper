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
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables:
        int WindowWidth;
        string mapImagePath="";
        Map map;
        GridModalWindow gridMw;

        /// global variables
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuPlikExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RPGMainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = (int)RPGMainWindow.Width;
            MainMenu.Width = WindowWidth;
            if(RPGMainWindow.WindowState==WindowState.Maximized)
            {
                WindowWidth = (int)SystemParameters.MaximizedPrimaryScreenWidth;
                MainMenu.Width = WindowWidth;
            }
        }

        private void AboutTab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Jeśli program nie działa lub Ci się nie podoba usuń go i nie zawracaj nam dupy.");
        }

        private void Show_Map_Click(object sender, RoutedEventArgs e)
        {
            map = new Map();
            map.LoadMap(mapImagePath);
            map.Show();
        }

        private void RPGMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(map!=null)
            {
                map.Close();
            }
        }

        private void LoadMap_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.bmp; *.jpg; |All files|*.*";
            ofd.FilterIndex = 1;
            if(ofd.ShowDialog()==true)
            {
                mapImagePath = ofd.FileName;
                if(map!=null)
                {
                    map.ReloadBackgroundMap(mapImagePath);
                }
                IsMapLoadedCheckBox.IsChecked = true;
            }
            else
            {
                MessageBox.Show("Nie można załadować tej mapy!!!");
            }
        }

        private void DrawNewGrid_Click(object sender, RoutedEventArgs e)
        {
            gridMw = new GridModalWindow(ref map);
            gridMw.Owner = this;
            gridMw.ShowDialog();
        }

        private void DeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            map.DeleteGrid();
        }

        private void CharactersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddCharacter_Click(object sender, RoutedEventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////TO DO Otwierane okno gdzie się ustawia parametry + lista obiektów!!!
            Character character = new Character("Buldog", 240,30);
            CharactersList.Items.Add(character);
        }
    }
}
