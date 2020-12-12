using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class Character
    {
        /// <summary>
        /// ///////////////////////////////////////TO DO Dodać obrazek do klasy!!!
        /// </summary>
        private string Name;
        private string Owner;
        private string Allignment;
        private float LivePercentage;
        private int MaxLivePoints;
        private int ActualLivePoints;
        private int Iniciative;
        private BitmapImage Alias;

        public Character(string name, string allignment, string owner, int max_live_points, int initiative )
        {
            Name = name;
            Allignment = allignment;
            Owner = owner;
            MaxLivePoints = max_live_points;
            ActualLivePoints = max_live_points;
            CalculateLivePercentage();
            Iniciative = initiative;
        }

        public string owner_
        {
            get { return Owner; }
            set { Owner = owner_; }
        }
        public BitmapImage alias_
        {
            get { return Alias; }
            set { Alias = alias_; }
        }

        public string name_
        {
            get { return Name; }
            set { Name = name_; }
        }

        public float live_percentage_
        {
            get { return LivePercentage; }
            set { LivePercentage = live_percentage_; }
        }

        public int iniciative_
        {
            get { return Iniciative; }
            set { Iniciative = iniciative_; }
        }

        public int max_live_points_
        {
            get { return MaxLivePoints; }
            set { MaxLivePoints = max_live_points_; }
        }

        public int actual_live_points_
        {
            get { return ActualLivePoints; }
            set { MaxLivePoints = actual_live_points_; }
        }

        public string allignment_
        {
            get { return Allignment; }
            set { Allignment = value; }
        }

        public void CalculateLivePercentage()
        {
            LivePercentage = ((float)ActualLivePoints / MaxLivePoints) * 100;
        }

    }
}
