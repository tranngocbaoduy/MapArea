using MyMap.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMap.Model
{
    public partial class Circle : BaseViewModel
    {
        private double _CanvasLeft;
        public double CanvasLeft { get => _CanvasLeft; set { _CanvasLeft = value; OnPropertyChanged(); } }

        private double _CanvasTop;
        public double CanvasTop { get => _CanvasTop; set { _CanvasTop = value; OnPropertyChanged(); } }

        private int _Height;
        public int Height { get => _Height; set { _Height = value; OnPropertyChanged(); } }

        private int _Width;
        public int Width { get => _Width; set { _Width = value; OnPropertyChanged(); } }

        private int _Index;
        public int Index { get => _Index; set { _Index = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }


        public Circle()
        {
            CanvasTop = Int32.MinValue;
            CanvasLeft = Int32.MinValue;
            Height = 16;
            Width = 16;
            Index = 0;
        }

    }
}
