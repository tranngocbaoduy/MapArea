using MyMap.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap.Model
{
    public partial class MyPath :BaseViewModel
    {

        private String _NamePath;
        public String NamePath { get => _NamePath; set { _NamePath = value; OnPropertyChanged(); } }

        private double _Distance;
        public double Distance { get => _Distance; set { _Distance = value; OnPropertyChanged(); } }

        public MyPath()
        {
            Distance = 0;
            NamePath = "";
        }
    }
}
