using MyMap.DBConnection;
using MyMap.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyMap.ViewModel
{
    public partial class MapCreateViewModel : BaseViewModel
    {
        #region
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand OnKeyUpCommand { get; set; }
        public ICommand MouseDown { get; set; }
        public ICommand MouseDownPoint { get; set; }
        public ICommand CreateNewVertex { get; set; }
        public ICommand UpdateVertexChoose { get; set; }
        public ICommand DeleteVertex_Vertex { get; set; }

        public ICommand ChooseV1 { get; set; }
        public ICommand ChooseV2 { get; set; }
        public ICommand ChooseDiemDi { get; set; }
        public ICommand ChooseDiemDen { get; set; }
        public ICommand CreateNewVertex_Vertex { get; set; }
        #endregion

        private Model.VERTEX _SelectedVertex { get; set; }
        public Model.VERTEX SelectedVertex { get => _SelectedVertex; set { _SelectedVertex = value; OnPropertyChanged(); } }

        private int _IdVertexNearest { get; set; }
        public int IdVertexNearest { get => _IdVertexNearest; set { _IdVertexNearest = value; OnPropertyChanged(); } }

        private Model.VERTEX _V1 { get; set; }
        public Model.VERTEX V1 { get => _V1; set { _V1 = value; OnPropertyChanged(); } }

        private Model.VERTEX _V2 { get; set; }
        public Model.VERTEX V2 { get => _V2; set { _V2 = value; OnPropertyChanged(); } }

        private Model.VERTEX _VertexDi { get; set; }
        public Model.VERTEX VertexDi { get => _VertexDi; set { _VertexDi = value; OnPropertyChanged(); } }

        private Model.VERTEX _VertexDen { get; set; }
        public Model.VERTEX VertexDen { get => _VertexDen; set { _VertexDen = value; OnPropertyChanged(); } }

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

        private ObservableCollection<String> _SearchingList { get; set; }
        public ObservableCollection<String> SearchingList { get => _SearchingList; set { _SearchingList = value; OnPropertyChanged(); } }

        private ObservableCollection<String> _TempSearchingList { get; set; }
        public ObservableCollection<String> TempSearchingList { get => _TempSearchingList; set { _TempSearchingList = value; OnPropertyChanged(); } }

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

        private Ellipse _elpBegin { get; set; }
        public Ellipse elpBegin { get => _elpBegin; set { _elpBegin = value; OnPropertyChanged(); } }

        private Ellipse _elpEnd { get; set; }
        public Ellipse elpEnd { get => _elpEnd; set { _elpEnd = value; OnPropertyChanged(); } }

        private PathGeometry _PatDirection;
        public PathGeometry PatDirection { get => _PatDirection; set { _PatDirection = value; OnPropertyChanged(); } }

        //public const string _fileUrl = "C:/Users/ADIM/source/repos/MyMap/MyMap/Resources/mapdata.txt";

        private int[] _parent;//kết quả dijkstra : parent[i] là đỉnh trước của đỉnh i 


        public const double MaxWeight = 1000000;

        public MapCreateViewModel()
        {
            p1 = Int32.MinValue; p2 = Int32.MinValue; p3 = Int32.MinValue; p4 = Int32.MinValue;

            CurrentCircle = new Circle();
            cboBegin = new ObservableCollection<String>();
            cboEnd = new ObservableCollection<String>();
            SearchingList = new ObservableCollection<String>();
            TempSearchingList = new ObservableCollection<String>();
            PathList = new ObservableCollection<MyPath>();
            AllVertex = new List<Circle>();
            FillDataFromDBToGraph();
            FillDataToArray();


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

            CreateNewVertex = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CoordinatorX)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorY)) { return false; }
                if (string.IsNullOrEmpty(AddressNameCreate)) { return false; }
                return true;
            }, (p) => { CreateNewAddress(); });


            ChooseV1 = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CoordinatorXNear)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorYNear)) { return false; }
                if (string.IsNullOrEmpty(AddressNameNear)) { return false; }
                return true;
            }, (p) => { V1 = DataProvider.Ins.DB.Vertices.Where(i => i.ID == IdVertexNearest).SingleOrDefault(); MessageBox.Show("Chọn " + V1.VERTEXNAME + " là điểm 1 thành công"); });

            ChooseV2 = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CoordinatorXNear)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorYNear)) { return false; }
                if (string.IsNullOrEmpty(AddressNameNear)) { return false; }
                return true;
            }, (p) => { V2 = DataProvider.Ins.DB.Vertices.Where(i => i.ID == IdVertexNearest).SingleOrDefault(); MessageBox.Show("Chọn " + V2.VERTEXNAME + " là điểm 2 thành công"); });

            ChooseDiemDi = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CoordinatorXNear)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorYNear)) { return false; }
                if (string.IsNullOrEmpty(AddressNameNear)) { return false; }
                if (IdVertexNearest.ToString() == "") { return false; }
                return true;
            },
           (p) =>
           {
               var list = DataProvider.Ins.DB.Vertices.Where(i => i.ID == IdVertexNearest).ToList();
               if (list != null && list.Count() > 0 && list.First() != null)
               {
                   VertexDi = list.FirstOrDefault(); 
                   if (DataProvider.Ins.DB.Vertices.Count() != VertexDi.ID)
                   { 
                       MessageBox.Show("Chọn " + VertexDi.VERTEXNAME + " là điểm đi thành công");
                       _startVertex = VertexDi.ID;
                       p1 = _vertexPosition[_startVertex].X - 8;
                       p2 = _vertexPosition[_startVertex].Y - 8;
                       if (VertexDi != null && VertexDen != null)
                       {
                           if (DataProvider.Ins.DB.Vertices.Count() == VertexDen.ID  || DataProvider.Ins.DB.Vertices.Count() == VertexDi.ID)
                           {
                               return;
                           }
                           DrawPath();
                       } 
                   }
                   else
                   {
                       MessageBox.Show("Lỗi trên đường đi chưa có điểm nối");
                   }
               }

           });

            ChooseDiemDen = new RelayCommand<object>((p) =>
            {
                if (IdVertexNearest.ToString() == "") { return false; }
                if (string.IsNullOrEmpty(CoordinatorXNear)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorYNear)) { return false; }
                if (string.IsNullOrEmpty(AddressNameNear)) { return false; }
                return true;
            },
            (p) =>
            {
                var list = DataProvider.Ins.DB.Vertices.Where(i => i.ID == IdVertexNearest).ToList();
                if (list != null && list.Count() > 0 && list.First() != null)
                {
                    VertexDen = list.FirstOrDefault();
                   
                    if (DataProvider.Ins.DB.Vertices.Count() != VertexDen.ID )
                    {
                        if(VertexDi != null)
                        {
                            if(DataProvider.Ins.DB.Vertices.Count() == VertexDi.ID) {
                                return;
                            }
                        }
                        MessageBox.Show("Chọn " + VertexDen.VERTEXNAME + " là điểm đến thành công");

                        _endVertex = VertexDen.ID;
                        p3 = _vertexPosition[_endVertex].X - 8;
                        p4 = _vertexPosition[_endVertex].Y - 8;
                        if (VertexDi != null && VertexDen != null)
                        {
                            if (DataProvider.Ins.DB.Vertices.Count() == VertexDen.ID || DataProvider.Ins.DB.Vertices.Count() == VertexDi.ID)
                            {
                                return;
                            }
                            DrawPath();
                        } 
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trên đường đi chưa có điểm nối");
                    }
                }
            });

            CreateNewVertex_Vertex = new RelayCommand<object>((p) =>
            {
                if (V1 == null) { return false; }
                if (V2 == null) { return false; }
                return true;
            }, (p) => { CreateWeightBetweenTwoVertex(); });


            UpdateVertexChoose = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CoordinatorXNear)) { return false; }
                if (string.IsNullOrEmpty(CoordinatorYNear)) { return false; }
                if (string.IsNullOrEmpty(AddressNameNear)) { return false; }
                if (string.IsNullOrEmpty(IdVertexNearest.ToString())) { return false; }
                return true;
            }, (p) => { UpdateVertex(); });


            DeleteVertex_Vertex = new RelayCommand<object>((p) =>
            {
                if (V1 == null) { return false; }
                if (V2 == null) { return false; }
                return true;
            }, (p) => { DeleteWeightBetweenTwoVertex(); });

        }

        public void UpdateVertex()
        {
            if (MessageBox.Show("Cập nhật?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemChoosing = DataProvider.Ins.DB.Vertices.Where(i => i.ID == IdVertexNearest).SingleOrDefault();

                itemChoosing.VERTEXNAME = AddressNameNear;
                itemChoosing.X = (double)Double.Parse(CoordinatorXNear);
                itemChoosing.Y = (double)Double.Parse(CoordinatorYNear);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
            }

        }

        public void CreateWeightBetweenTwoVertex()
        {
            var itemCheck = DataProvider.Ins.DB.VERTEX_VERTEX.Where(i => (i.V1 == V1.ID && i.V2 == V2.ID) || (i.V1 == V2.ID && i.V2 == V1.ID)).Count();
            if (itemCheck > 0) { MessageBox.Show("Hai Điểm Đã Nối Rồi"); return; }
            double xMax = 0;
            double yMax = 0;
            double xMin = 0;
            double yMin = 0;

            // get x max and y max to calculate weight 
            if (V1.X > V2.X)
            {
                xMax = V1.X;
                xMin = V2.X;
            }
            else
            {
                xMin = V1.X;
                xMax = V2.X;
            }

            if (V1.Y > V2.Y)
            {
                yMax = V1.Y;
                yMin = V2.Y;
            }
            else
            {
                yMin = V1.Y;
                yMax = V2.Y;
            }

            double weight = Math.Sqrt(Math.Pow((xMax - xMin), 2) + Math.Pow((yMax - yMin), 2));
            MessageBox.Show(weight + " ");

            Model.VERTEX_VERTEX newVERTEX_VERTEX = new Model.VERTEX_VERTEX();
            newVERTEX_VERTEX.V1 = V1.ID;
            newVERTEX_VERTEX.V2 = V2.ID;
            newVERTEX_VERTEX.WEIGHT = weight;

            DataProvider.Ins.DB.VERTEX_VERTEX.Add(newVERTEX_VERTEX);
            V1.NUMBER_VERTEX_KE += 1;
            V2.NUMBER_VERTEX_KE += 1;
            DataProvider.Ins.DB.SaveChanges();
            Refresh();
            MessageBox.Show("Nối 2 điểm thành công");
        }

        public void DeleteWeightBetweenTwoVertex()
        {
            if (MessageBox.Show("Xoá nối hai điểm?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                var itemCheck = DataProvider.Ins.DB.VERTEX_VERTEX.Where(i => (i.V1 == V1.ID && i.V2 == V2.ID) || (i.V1 == V2.ID && i.V2 == V1.ID)).ToList();
                if (itemCheck.Count() > 0)
                {
                    DataProvider.Ins.DB.VERTEX_VERTEX.Remove(itemCheck.FirstOrDefault());
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Xoá nối 2 điểm thành công");
                    FillDataFromDBToGraph();
                    cboBegin.Clear();
                    cboEnd.Clear();
                    FillDataToArray(); Refresh();
                }
                else
                {
                    MessageBox.Show("Hai điểm chưa được nối");
                }
            }
        }

        public void CreateNewAddress()
        {
            Model.VERTEX newVertex = new Model.VERTEX();
            newVertex.VERTEXNAME = AddressNameCreate.Trim();
            newVertex.X = Double.Parse(CoordinatorX);
            newVertex.Y = Double.Parse(CoordinatorY);
            newVertex.NUMBER_VERTEX_KE = 0;

            DataProvider.Ins.DB.Vertices.Add(newVertex);
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Tạo thành công");

            FillDataFromDBToGraph();
            cboBegin.Clear();
            cboEnd.Clear();
            FillDataToArray();
            Refresh();
        }

        void Refresh()
        {
            CoordinatorX = "";
            V1 = new VERTEX();
            V2 = new VERTEX();
            CoordinatorY = "";
            AddressNameCreate = "";

            cboBegin.Clear();
            cboEnd.Clear();
            PathList.Clear();
            FillDataFromDBToGraph();
            FillDataToArray();
        }

        public double Dijkstra(int start, int end, ref int[] parent)
        {
            double[] distance = new double[_vertexNumber + 1];
            PathList.Clear();
            // start = 1; 
            parent = new int[_vertexNumber];
            bool[] visited = new bool[_vertexNumber];
            int i;
            // tìm các thăng kề với đỉnh start 
            // tất cả phần tử mảng parent sẽ là đỉnh bắt đầu
            // tạo mới mảng visit false;
            for (i = 0; i < _vertexNumber; ++i)
            {
                distance[i] = _graphMatrix[start, i];
                parent[i] = start;
                visited[i] = false;
            }
            // distance[0] = 43; 
            // distance[2] = 65;
            // còn lại là MaxWeight

            // đã check đỉnh bắt đầu
            visited[start] = true;
            // đỉnh bắt đầu bằng MaxWeight
            distance[start] = MaxWeight;
            // đỉnh lớn nhất là MaxWeight;
            distance[_vertexNumber] = MaxWeight;
            while (true)
            {
                var min = _vertexNumber;
                // 8 -> 7 if 7 < 8 thì min = i; min = 7; sai min = 8;
                // 6 -> 7 if 6 < 7 thì min = i; min = 6; sai min = 8;
                // ...
                // 3 -> 2 if 2 < 3 thì min = i; min 2;
                // 2 -> 1 if 1 < 2 thì min = i; min =1 ; sai min vẫn là 2;
                // 1 -> 0 if 0 < 1 thì min = i; đúng nên min cuối cùng là 0;
                for (i = _vertexNumber - 1; i >= 0; --i)
                    if (visited[i] == false && distance[i] < distance[min])
                        min = i;
                if (min == _vertexNumber)
                    break;
                if (min == end)
                    break;
                var v = min;

                visited[v] = true;
                // v = 0; u là các phần tử đỉnh kề với đỉnh 0 
                //  MessageBox.Show(" đỉnh :" + v + " có " + _graphList[v].Count().ToString() + "đỉnh kề");
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
            if(PathList.Count() ==1 && PathList.FirstOrDefault().Distance == MaxWeight)
            {
                PathList.Clear();
                MessageBox.Show("Điểm đi và điểm nối chưa được nối");  
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
            // create matrix weight with i!= j => 100000 
            // i == j => 0
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

                var listKe = DataProvider.Ins.DB.VERTEX_VERTEX.Where(item => item.V1 == currentVertex.ID || item.V2 == currentVertex.ID).ToList();

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
                _vertexPosition[i].X = currentVertex.X; //tọa độ x
                _vertexPosition[i].Y = currentVertex.Y; //tọa độ y
            }
            //textReader.Close();

            for (int t = 0; t < _vertexNumber; t++)
            {
                for (int r = 0; r < _vertexNumber; r++)
                {
                    Console.Write(_graphMatrix[t, r] + "\t\t\t\t\t");
                }
                Console.WriteLine();
            }

            //TextReader textReader = new StreamReader(fileUrl);
            //_vertexNumber = int.Parse(textReader.ReadLine());
            //_vertexName = new string[_vertexNumber];
            //_graphList = new List<int>[_vertexNumber];
            //_graphMatrix = new double[_vertexNumber, _vertexNumber];
            //_vertexPosition = new Point[_vertexNumber];
            //int i, j, k, n;
            //double w;
            //string[] buffStringArray;
            //for (i = 0; i < _vertexNumber; ++i)
            //    for (j = 0; j < _vertexNumber; ++j)
            //        if (i == j)
            //            _graphMatrix[i, j] = 0;
            //        else
            //            _graphMatrix[i, j] = MaxWeight;

            //for (i = 0; i < _vertexNumber; ++i)
            //{
            //    buffStringArray = textReader.ReadLine().Split(' ');
            //    n = int.Parse(buffStringArray[0]);
            //    _graphList[i] = new List<int>();
            //    for (j = 0; j < n; ++j)
            //    {
            //        k = int.Parse(buffStringArray[j * 2 + 1]); //mỗi đỉnh kề của đỉnh i
            //        w = double.Parse(buffStringArray[j * 2 + 2]); //trọng số đính kèm từ đỉnh i đến đỉnh k
            //        _graphList[i].Add(k);
            //        _graphMatrix[i, k] = w;
            //    }
            //    _vertexName[i] = buffStringArray[n * 2 + 1]; //tên đỉnh
            //    _vertexPosition[i].X = double.Parse(buffStringArray[n * 2 + 2]); //tọa độ x
            //    _vertexPosition[i].Y = double.Parse(buffStringArray[n * 2 + 3]); //tọa độ y
            //}
            //textReader.Close();

        }

        public int _startVertex; //đỉnh đi
        public int _endVertex; //đỉnh đến

        public void FillDataToArray()
        {
            var userVertex = _vertexName
                .Select((name, index) => new { VertexIndex = index, Name = name });

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
                temp.CanvasLeft = _vertexPosition[_startVertex].X - 8;
                temp.Height = 16;
                temp.CanvasTop = _vertexPosition[_startVertex].Y - 8;
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
            // get vertex path for my path list
            GetVertexPathForPathList(_startVertex, _endVertex, _parent);
            var minPath = GetVertexPath(_startVertex, _endVertex, _parent);
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
