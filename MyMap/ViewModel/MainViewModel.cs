using MyMap.DBConnection;
using MyMap.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyMap.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        #region
        public ICommand LoadedWindowCommand { get; set; } 
        public ICommand SignInCommand { get; set; }
        public ICommand ToAddressCommand { get; set; }
        public ICommand FromAddressCommand { get; set; }
        public ICommand MouseDown { get; set; } 

        public ICommand ChooseV1 { get; set; }
        public ICommand ChooseV2 { get; set; }

        #endregion

        private Model.VERTEX _V1 { get; set; }
        public Model.VERTEX V1 { get => _V1; set { _V1 = value; OnPropertyChanged(); } }

        private Model.VERTEX _V2 { get; set; }
        public Model.VERTEX V2 { get => _V2; set { _V2 = value; OnPropertyChanged(); } }

        private Model.VERTEX _SelectedVertex { get; set; }
        public Model.VERTEX SelectedVertex { get => _SelectedVertex; set { _SelectedVertex = value; OnPropertyChanged(); } }

        private int _IdVertexNearest { get; set; }
        public int IdVertexNearest { get => _IdVertexNearest; set { _IdVertexNearest = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.VERTEX> _VertexList { get; set; }
        public ObservableCollection<Model.VERTEX> VertexList { get => _VertexList; set { _VertexList = value; OnPropertyChanged(); } }

        private String _V1_VERTEXNAME { get; set; }
        public String V1_VERTEXNAME { get => _V1_VERTEXNAME; set { _V1_VERTEXNAME = value; OnPropertyChanged(); } }

        private String _V2_VERTEXNAME { get; set; }
        public String V2_VERTEXNAME { get => _V2_VERTEXNAME; set { _V2_VERTEXNAME = value; OnPropertyChanged(); } }

        private String _CoordinatorX { get; set; }
        public String CoordinatorX { get => _CoordinatorX; set { _CoordinatorX = value; OnPropertyChanged(); } }

        private String _CoordinatorY { get; set; }
        public String CoordinatorY { get => _CoordinatorY; set { _CoordinatorY = value; OnPropertyChanged(); } }

        private String _AddressNameCreate { get; set; }
        public String AddressNameCreate { get => _AddressNameCreate; set { _AddressNameCreate = value; OnPropertyChanged(); } }

        private String _CoordinatorXNear { get; set; }
        public String CoordinatorXNear { get => _CoordinatorXNear; set { _CoordinatorXNear = value; OnPropertyChanged(); } }

        private String _CoordinatorYNear { get; set; }
        public String CoordinatorYNear { get => _CoordinatorYNear; set { _CoordinatorYNear = value; OnPropertyChanged(); } }

        private String _AddressNameNear = "";
        public String AddressNameNear { get => _AddressNameNear; set { _AddressNameNear = value; OnPropertyChanged(); } }

        public int _vertexNumber; //số đỉnh
        public string[] _vertexName; //tên các đỉnh
        public double[,] _graphMatrix; //ma trận kề
        public List<int>[] _graphList; //danh sách kề
        public Point[] _vertexPosition; //tọa độ các đỉnh
                                        //private Point origin;
                                        //private Point start;
                                        //private Slider _slider;

        private ObservableCollection<String> _cboBegin { get; set; }
        public ObservableCollection<String> cboBegin { get => _cboBegin; set { _cboBegin = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _cboEnd { get; set; }
        public ObservableCollection<String> cboEnd { get => _cboEnd; set { _cboEnd = value; OnPropertyChanged(); } } 

        private List<Circle> _AllVertex { get; set; }
        public List<Circle> AllVertex { get => _AllVertex; set { _AllVertex = value; OnPropertyChanged(); } }

        private Circle _CurrentCircle { get; set; }
        public Circle CurrentCircle { get => _CurrentCircle; set { _CurrentCircle = value; OnPropertyChanged(); } }

        private double _p1;
        public double p1 { get => _p1; set { _p1 = value; OnPropertyChanged(); } }

        private double _p2;
        public double p2 { get => _p2; set { _p2 = value; OnPropertyChanged(); } }

        private double _p3;
        public double p3 { get => _p3; set { _p3 = value; OnPropertyChanged(); } }

        private double _p4;
        public double p4 { get => _p4; set { _p4 = value; OnPropertyChanged(); } }

        private ObservableCollection<MyPath> _PathList;
        public ObservableCollection<MyPath> PathList { get => _PathList; set { _PathList = value; OnPropertyChanged(); } }

        private double _DoLech = 3500;
        public double DoLech { get => _DoLech; set { _DoLech = value; OnPropertyChanged(); } }

        private String _SelectedItemBegin { get; set; }
        public String SelectedItemBegin
        {
            get => _SelectedItemBegin; set
            {
                _SelectedItemBegin = value; OnPropertyChanged();
                if (SelectedItemBegin != null)
                {
                    V1 = DataProvider.Ins.DB.Vertices.Where(i => i.VERTEXNAME == SelectedItemBegin).SingleOrDefault();
                    _startVertex = V1.ID;
                    p1 = _vertexPosition[_startVertex].X;
                    p2 = _vertexPosition[_startVertex].Y;
                    DrawPath();
                }
            }
        }

        private String _SelectedItemEnd { get; set; }
        public String SelectedItemEnd
        {
            get => _SelectedItemEnd; set
            {
                _SelectedItemEnd = value; OnPropertyChanged();
                if (SelectedItemEnd != null)
                {
                    V2 = DataProvider.Ins.DB.Vertices.Where(i => i.VERTEXNAME == SelectedItemEnd).SingleOrDefault();
                    _endVertex = V2.ID;
                    p3 = _vertexPosition[_endVertex].X;
                    p4 = _vertexPosition[_endVertex].Y;
                    DrawPath();
                }
            }
        }

        private Ellipse _elpBegin { get; set; }
        public Ellipse elpBegin { get => _elpBegin; set { _elpBegin = value; OnPropertyChanged(); } }

        private Ellipse _elpEnd { get; set; }
        public Ellipse elpEnd { get => _elpEnd; set { _elpEnd = value; OnPropertyChanged(); } }

        private PathGeometry _PatDirection;
        public PathGeometry PatDirection { get => _PatDirection; set { _PatDirection = value; OnPropertyChanged(); } }

        //public const string _fileUrl = "C:/Users/ADIM/source/repos/MyMap/MyMap/Resources/mapdata.txt";

        private int[] _parent;//kết quả dijkstra : parent[i] là đỉnh trước của đỉnh i 


        public const double MaxWeight = 1000000;

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                // Show form login when start program
                if (p != null)
                {
                    FillDataFromDBToGraph();
                    FillDataToArray(); 
                }
            });

            FromAddressCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    VertexList.Clear();
                    if (p != null && p.Text != "")
                    {
                        var listTemp = _vertexName
                                .Select((name, index) => new { VertexIndex = index, Name = name })
                                .Select(name => new { VertexIndex = name.VertexIndex, Name = name.Name.Replace('_', ' ') })
                                .Where(i => i.Name.ToLower().StartsWith(p.Text.ToLower()) || ConvertToUnsign(i.Name.ToLower()).Contains(ConvertToUnsign(p.Text.ToLower())));
                        foreach (var item in listTemp)
                        {
                            VertexList.Add(DataProvider.Ins.DB.Vertices.Where(i => i.ID == item.VertexIndex).SingleOrDefault());
                        }
                    }
                }
                catch 
                {
                    // bỏ qua lỗi null tham số
                }
            });

            ToAddressCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                try
                {
                    VertexList.Clear();
                    if (p != null && p.Text != "")
                    {
                        var listTemp = _vertexName
                                .Select((name, index) => new { VertexIndex = index, Name = name })
                                .Select(name => new { VertexIndex = name.VertexIndex, Name = name.Name.Replace('_', ' ') })
                                .Where(i => i.Name.ToLower().StartsWith(p.Text.ToLower()) || ConvertToUnsign(i.Name.ToLower()).Contains(ConvertToUnsign(p.Text.ToLower())));
                        foreach (var item in listTemp)
                        {
                            VertexList.Add(DataProvider.Ins.DB.Vertices.Where(i => i.ID == item.VertexIndex).SingleOrDefault());
                        }
                    }
                }
                catch
                {
                    // bỏ qua lỗi null tham số
                }
            }); 

            p1 = Int32.MinValue; p2 = Int32.MinValue; p3 = Int32.MinValue; p4 = Int32.MinValue;
            VertexList = new ObservableCollection<Model.VERTEX>();
            CurrentCircle = new Circle();
            cboBegin = new ObservableCollection<String>();
            cboEnd = new ObservableCollection<String>(); 
            PathList = new ObservableCollection<MyPath>();
            AllVertex = new List<Circle>(); 

            MouseDown = new RelayCommand<Canvas>((canvas) => { return true; }, (canvas) =>
              {
                  if (canvas != null)
                  {
                      Point point = Mouse.GetPosition(canvas);
                      CoordinatorX = (point.X - 8).ToString();
                      CoordinatorY = (point.Y - 8).ToString();

                      int convertXtoInt = (int)(point.X - 8);
                      int convertYtoInt = (int)(point.Y - 8);

                      var listItemNearest = DataProvider.Ins.DB.Vertices.Where(i => Math.Abs((int)i.X - convertXtoInt) <= 10 && Math.Abs((int)i.Y - convertYtoInt) <= 10).ToList();

                      if (listItemNearest != null && listItemNearest.Count() > 0)
                      {
                          CoordinatorXNear = listItemNearest.FirstOrDefault().X.ToString();
                          CoordinatorYNear = listItemNearest.FirstOrDefault().Y.ToString();
                          AddressNameNear = listItemNearest.FirstOrDefault().VERTEXNAME.ToString();
                          IdVertexNearest = listItemNearest.FirstOrDefault().ID;
                      }
                      else
                      {
                          CoordinatorXNear = "";
                          CoordinatorYNear = "";
                          AddressNameNear = "";
                      }

                  }
              });

            ChooseV1 = new RelayCommand<object>((p) => { if (SelectedVertex == null) { return false; } return true; },
            (p) =>
            {
                V1 = DataProvider.Ins.DB.Vertices.Where(i => i.ID == SelectedVertex.ID).SingleOrDefault();
                V1_VERTEXNAME = V1.VERTEXNAME;
                MessageBox.Show("Chọn " + V1.VERTEXNAME + " là điểm đi thành công");
                _startVertex = V1.ID;
                p1 = _vertexPosition[_startVertex].X - 8;
                p2 = _vertexPosition[_startVertex].Y - 8;

                if (V1 != null && V2 != null)
                {
                    DrawPath();
                }
                VertexList.Clear();
            });

            ChooseV2 = new RelayCommand<object>((p) => { if (SelectedVertex == null) { return false; } return true; },
            (p) =>
            {
                V2 = DataProvider.Ins.DB.Vertices.Where(i => i.ID == SelectedVertex.ID).SingleOrDefault();
                V2_VERTEXNAME = V2.VERTEXNAME;
                MessageBox.Show("Chọn " + V2.VERTEXNAME + " là điểm đến thành công");

                _endVertex = V2.ID;
                p3 = _vertexPosition[_endVertex].X - 8;
                p4 = _vertexPosition[_endVertex].Y - 8;
                if (V1 != null && V2 != null)
                {
                    DrawPath();
                }
                VertexList.Clear();
            });
        }
        static Regex ConvertToUnsign_rg = null;

        public static string ConvertToUnsign(string strInput)
        {
            if (ReferenceEquals(ConvertToUnsign_rg, null))
            {
                ConvertToUnsign_rg = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            }
            var temp = strInput.Normalize(NormalizationForm.FormD);
            return ConvertToUnsign_rg.Replace(temp, string.Empty).Replace("đ", "d").Replace("Đ", "D").ToLower();
        }
         

        void Refresh()
        {
            CoordinatorX = "";
            CoordinatorY = "";
            AddressNameCreate = "";
        }

        public double Dijkstra(int start, int end, ref int[] parent)
        {
            PathList.Clear(); 
            MessageBox.Show("Start :" + _vertexName.ElementAt(start) + " End: " + _vertexName.ElementAt(end));
            double[] distance = new double[_vertexNumber + 1];
            parent = new int[_vertexNumber];
            bool[] visited = new bool[_vertexNumber];
            int i; 
            for (i = 0; i < _vertexNumber; ++i)
            {
                distance[i] = _graphMatrix[start, i];
                parent[i] = start;
                visited[i] = false;
            } 
            visited[start] = true; 
            distance[start] = MaxWeight; 
            distance[_vertexNumber] = MaxWeight;
            while (true)
            {
                var min = _vertexNumber; 
                for (i = _vertexNumber - 1; i >= 0; --i)
                    if (visited[i] == false && distance[i] < distance[min])
                        min = i;
                if (min == _vertexNumber)
                    break;
                if (min == end)
                    break;
                var v = min; 
                visited[v] = true; 
                foreach (var u in _graphList[v]) // danh sach kề
                {
                    var sum = distance[v] + _graphMatrix[v, u]; // ma trận kề
                    if (visited[u] == false && distance[u] > sum)
                    {
                        distance[u] = sum;
                        parent[u] = v;

                    }
                }
            }
            return distance[end];
        }

        public void GetVertexPathForPathList(int start, int end, int[] parent)
        {
            List<int> result = new List<int>();
            int temp = end;
            while (temp != start)
            {
                result.Add(temp);
                temp = parent[temp];
            }
            result.Add(temp);
            result.Reverse();
            foreach (var i in result)
            {
                if (i == temp) continue;
                MyPath path = new MyPath();
                path.Distance = _graphMatrix[temp, i];
                var item = _vertexName.ElementAt(i);
                path.NamePath = item;
                if (PathList.Where(p => p.NamePath == item).Count() == 0)
                {
                    PathList.Add(path);
                }
                temp = i;
            }
            PathList.Reverse(); 
            if (PathList.Count() == 1 && PathList.FirstOrDefault().Distance == MaxWeight)
            {
                PathList.Clear();
                MessageBox.Show("Điểm đi và điểm nối chưa được nối. Xin hãy thêm đường nối hoặc báo với người quản lý");
              
            }
        }

        public List<int> GetVertexPath(int start, int end, int[] parent)
        {
            List<int> result = new List<int>();
            int temp = end;
            while (temp != start)
            {
                result.Add(temp);
                temp = parent[temp];
            }
            result.Add(temp);
            result.Reverse();
            return result;
        }

        private void FillDataFromDBToGraph()
        {
            var listVertices = DataProvider.Ins.DB.Vertices.ToList(); // get All Vertex in DB
            _vertexNumber = listVertices.Count();
            _vertexName = new string[_vertexNumber];
            _graphList = new List<int>[_vertexNumber * _vertexNumber];
            _graphMatrix = new double[_vertexNumber, _vertexNumber];
            _vertexPosition = new Point[_vertexNumber];
            int i, j, k, n;
            double w;  
            for (i = 0; i < _vertexNumber; ++i)
            {
                for (j = 0; j < _vertexNumber; ++j)
                {
                    if (i == j)
                        _graphMatrix[i, j] = 0;
                    else
                        _graphMatrix[i, j] = MaxWeight;
                }
            } 
            for (i = 0; i < _vertexNumber; ++i)
            {
                var currentVertex = listVertices.ElementAt(i);

                n = currentVertex.NUMBER_VERTEX_KE;

                var listKe = DataProvider.Ins.DB.VERTEX_VERTEX
                            .Where(item => item.V1 == currentVertex.ID || item.V2 == currentVertex.ID).ToList();

                _graphList[i] = new List<int>();

                foreach (var item in listKe)
                {
                    if (item.V1 == currentVertex.ID) //mỗi đỉnh kề của đỉnh i
                    {
                        k = (int)item.V2;
                    }
                    else
                    {
                        k = (int)item.V1;
                    }
                    w = item.WEIGHT; //trọng số đính kèm từ đỉnh i đến đỉnh k
                    _graphList[i].Add(k);
                    _graphMatrix[i, k] = w;
                }
                _vertexName[i] = currentVertex.VERTEXNAME; //tên đỉnh
                _vertexPosition[i].X = currentVertex.X - DoLech + 8; //tọa độ x
                _vertexPosition[i].Y = currentVertex.Y - DoLech + 8; //tọa độ y
            } 
        }

        public int _startVertex; //đỉnh đi
        public int _endVertex; //đỉnh đến

        public void FillDataToArray()
        {
            var userVertex = _vertexName
                  .Select((name, index) => new { VertexIndex = index, Name = name })
                  .Select(name => new { VertexIndex = name.VertexIndex, Name = name.Name.Replace('_', ' ') });
            foreach (var item in userVertex)
            {
                cboBegin.Add(item.Name);
                cboEnd.Add(item.Name);
            }
            AddAllVertex();
        }

        public void AddAllVertex()
        {
            var userVertex = _vertexName
                   .Select((name, index) => new { VertexIndex = index, Name = name })
                   .Select(name => new { VertexIndex = name.VertexIndex, Name = name.Name.Replace('_', ' ') });

            _startVertex = 0;
            foreach (var item in userVertex)
            {
                Circle temp = new Circle();
                temp.CanvasLeft = _vertexPosition[_startVertex].X;
                temp.Height = 16;
                temp.CanvasTop = _vertexPosition[_startVertex].Y;
                temp.Width = 16;
                temp.Index = _startVertex;
                temp.Name = item.Name;
                AllVertex.Add(temp);
                _startVertex++;
            }
        }

        public void DrawPath()
        {
            var minDistance = Dijkstra(_startVertex, _endVertex, ref _parent);
            GetVertexPathForPathList(_startVertex, _endVertex, _parent);
            var minPath = GetVertexPath(_startVertex, _endVertex, _parent);
            // get vertex path for my path list
            var pathSegmentCollection = new PathSegmentCollection();
            var pathFigure = new PathFigure()
            {
                StartPoint = _vertexPosition[minPath[0]],
                Segments = pathSegmentCollection
            };
            for (int i = 0; i < minPath.Count; i++)
                pathSegmentCollection.Add(new LineSegment(_vertexPosition[minPath[i]], true));

            var pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);
            var pathGeo = new PathGeometry(pathFigureCollection);
            PatDirection = pathGeo;
        }

    }
}
