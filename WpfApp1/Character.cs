using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Character
    {
        /// <summary>
        /// ///////////////////////////////////////TO DO Dodać obrazek do klasy!!!
        /// </summary>
        private string Name;
        private float LivePercentage;
        private int MaxLivePoints;
        private int ActualLivePoints;
        private int Iniciative;

        public Character(string name, int LivePoints, int initiative)
        {
            Name = name;
            MaxLivePoints = LivePoints;
            ActualLivePoints = LivePoints;
            CalculateLivePercentage();
            Iniciative = initiative;
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

        public void CalculateLivePercentage()
        {
            LivePercentage = ((float)ActualLivePoints / MaxLivePoints) * 100;
        }

    }
}
