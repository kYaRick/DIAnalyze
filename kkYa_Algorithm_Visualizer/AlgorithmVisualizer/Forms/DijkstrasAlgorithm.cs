using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Drawing;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;
using AlgorithmVisualizer.Properties;
using AlgorithmVisualizer.Forms;

namespace DjikstraRoads
{
    public partial class DijkstrasAlgorithm : Form
    {
        /// <summary> Коодинати вузлів </summary>
        private Dictionary<int, PointLatLng> NodesCoordinates;
        /// <summary> ID вузлів за назвами </summary>
        private Dictionary<string, int> NodesIDs;
        /// <summary> Табиця інформації про вузли </summary>
        private DataTable NodesInfo;
        /// <summary> Табиця інформації про ребра </summary>
        private DataTable EdgesInfo;
        /// <summary> Граф доріг (переходи ID-ID) </summary>
        public List<List<int>> IDsGraphAjadencyList;
        /// <summary> Граф часів переходів (час з ID в ID) </summary>
        public List<List<double>> DistancesGraphAjadencyList;
        /// <summary> Шар карти </summary>
        private GMapOverlay TopLayer;
        /// <summary> Прапорець проставляння галаочок в treeView </summary>
        public bool IsChecking = false;

        /// <summary>
        /// Конструктор форми
        /// </summary>
        /// 
        private MainUIForm parentForm;

        public DijkstrasAlgorithm()
        {
            InitializeComponent();
        }

        public DijkstrasAlgorithm(MainUIForm _parentForm)
        {
            InitializeComponent();
            parentForm = _parentForm;
        }

        /// <summary>
        /// Після завантаження форми
        /// </summary>
        /// <param name="sender">Надсилач</param>
        /// <param name="e">Декскриптор події</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.SetPositionByKeywords("Ukraine");
            gMapControl1.Position = new PointLatLng(49.43015530560421, 32.05334365655051);
            gMapControl1.MaxZoom = 6;
            gMapControl1.Zoom = 6;
            gMapControl1.ShowCenter = false;
            TopLayer = new GMapOverlay("Cities");
            gMapControl1.Overlays.Add(TopLayer);
            gMapControl1.ShowTileGridLines = false;
            LoadDataBase();
        }

        //// <summary>
        /// Після завантаження форми
        /// </summary>
        /// <param name="sender">Надсилач</param>
        /// <param name="e">Декскриптор події</param>
        private void LoadDataBase()
        {
            OleDbConnection ExcelFile = new OleDbConnection(
                   string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES; IMEX=1\"", @"./input data.xlsx"));
            ExcelFile.Open();
            OleDbDataAdapter DA;
            DA = new OleDbDataAdapter("SELECT [Name], [Y], [X] FROM [Nodes info$] ORDER BY [Name];", ExcelFile);
            NodesInfo = new DataTable();
            DA.Fill(NodesInfo);
            NodesCoordinates = new Dictionary<int, PointLatLng>();
            NodesIDs = new Dictionary<string, int>();
            for (int i = 0; i < NodesInfo.Rows.Count; i++)
            {
                NodesCoordinates.Add(i, new PointLatLng(Convert.ToDouble(NodesInfo.Rows[i]["Y"]), Convert.ToDouble(NodesInfo.Rows[i]["X"])));
                NodesIDs.Add(NodesInfo.Rows[i]["Name"].ToString(), i);
            }
            DA = new OleDbDataAdapter("SELECT [Route], [Distance, km] FROM [Edges info$] ORDER BY [Route];", ExcelFile);
            EdgesInfo = new DataTable();
            DA.Fill(EdgesInfo);
            for (int i = 0; i < EdgesInfo.Rows.Count; i++)
                EdgesInfo.Rows[i]["Distance, km"] = EdgesInfo.Rows[i]["Distance, km"].ToString().Split(new char[] { ' ' })[0];
            BuildNodesTree();
            BuildEdgesTree();
            treeView1.AfterCheck += new TreeViewEventHandler(this.treeView1_AfterCheck);
            treeView2.AfterCheck += new TreeViewEventHandler(this.treeView2_AfterCheck);
            RefreshMap();
            ExcelFile.Close();

            //using (OpenFileDialog ofd = new OpenFileDialog())
            //{
            //    ofd.InitialDirectory = Application.StartupPath + "../../../input data.xlsx";
            //    ofd.Filter = @"Excel files|*.xls;*.xlsx";
            //    if (ofd.ShowDialog() != DialogResult.OK || ofd.FileName.Equals("")) return;
            //    OleDbConnection ExcelFile = new OleDbConnection(
            //        string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES; IMEX=1\"", ofd.FileName));
            //    ExcelFile.Open();
            //    OleDbDataAdapter DA;
            //    DA = new OleDbDataAdapter("SELECT [Name], [Y], [X] FROM [Nodes info$] ORDER BY [Name];", ExcelFile);
            //    NodesInfo = new DataTable();
            //    DA.Fill(NodesInfo);
            //    NodesCoordinates = new Dictionary<int, PointLatLng>();
            //    NodesIDs = new Dictionary<string, int>();
            //    for (int i = 0; i < NodesInfo.Rows.Count; i++)
            //    {
            //        NodesCoordinates.Add(i, new PointLatLng(Convert.ToDouble(NodesInfo.Rows[i]["Y"]), Convert.ToDouble(NodesInfo.Rows[i]["X"])));
            //        NodesIDs.Add(NodesInfo.Rows[i]["Name"].ToString(), i);
            //    }
            //    DA = new OleDbDataAdapter("SELECT [Route], [Distance, km] FROM [Edges info$] ORDER BY [Route];", ExcelFile);
            //    EdgesInfo = new DataTable();
            //    DA.Fill(EdgesInfo);
            //    for (int i = 0; i < EdgesInfo.Rows.Count; i++)
            //        EdgesInfo.Rows[i]["Distance, km"] = EdgesInfo.Rows[i]["Distance, km"].ToString().Split(new char[] { ' ' })[0];
            //    BuildNodesTree();
            //    BuildEdgesTree();
            //    treeView1.AfterCheck += new TreeViewEventHandler(this.treeView1_AfterCheck);
            //    treeView2.AfterCheck += new TreeViewEventHandler(this.treeView2_AfterCheck);
            //    RefreshMap();
            //    ExcelFile.Close();
            //}
        }


        /// <summary>
        /// Побудова графу
        /// </summary>
        private void BuildGraph()
        {
            IDsGraphAjadencyList = new List<List<int>>();
            DistancesGraphAjadencyList = new List<List<double>>();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                IDsGraphAjadencyList.Add(new List<int>());
                DistancesGraphAjadencyList.Add(new List<double>());
            }
            for (int i = 0; i < treeView2.Nodes.Count; i++)
                if (treeView2.Nodes[i].Checked)
                {
                    string[] Names = treeView2.Nodes[i].Text.Split(new string[] { " – " }, StringSplitOptions.None);
                    string From = Names[0];
                    string To = Names[1];
                    int index = 0;
                    for (int j = 0; j < EdgesInfo.Rows.Count; j++)
                        if (EdgesInfo.Rows[j][0].ToString()== treeView2.Nodes[i].Text)
                        {
                            index = j;
                            break;
                        }
                    IDsGraphAjadencyList[NodesIDs[From]].Add(NodesIDs[To]);
                    DistancesGraphAjadencyList[NodesIDs[From]].Add(Double.Parse(EdgesInfo.Rows[index][1].ToString()));
                    IDsGraphAjadencyList[NodesIDs[To]].Add(NodesIDs[From]);
                    DistancesGraphAjadencyList[NodesIDs[To]].Add(Double.Parse(EdgesInfo.Rows[index][1].ToString()));
                }
        }

        /// <summary>
        /// Візуалізація графу на мапі
        /// </summary>
        private void ShowGraphOnMap()
        {
            gMapControl1.Overlays.Clear();
            TopLayer.Markers.Clear();
            gMapControl1.Overlays.Add(TopLayer);
            TopLayer.Clear();
            for( int i = 0; i < treeView1.Nodes.Count; i++)
                if (treeView1.Nodes[i].Checked)
                    TopLayer.Markers.Add(new GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(NodesInfo.Rows[i]["Y"]), Convert.ToDouble(NodesInfo.Rows[i]["X"])),
                        GMarkerGoogleType.green_small));
            for (int i = 0; i < treeView2.Nodes.Count; i++)
                if (treeView2.Nodes[i].Checked)
                {                    
                    string[] Names = treeView2.Nodes[i].Text.Split(new string[] { " – " }, StringSplitOptions.None);
                    string From = Names[0];
                    string To = Names[1];
                    GMapRoute Route = new GMapRoute(
                        new List<PointLatLng>() {
                            new PointLatLng() { Lat = NodesCoordinates[NodesIDs[From]].Lat, Lng = NodesCoordinates[NodesIDs[From]].Lng },
                            new PointLatLng() { Lat = NodesCoordinates[NodesIDs[To]].Lat, Lng = NodesCoordinates[NodesIDs[To]].Lng  }
                        }, " ");
                    Route.Stroke.Color = Color.Yellow;
                    TopLayer.Routes.Add(Route);
                }
        }

        /// <summary>
        /// Побудова дерева вузлів
        /// </summary>
        private void BuildNodesTree()
        {
            for (int i = 0; i < NodesInfo.Rows.Count; i++)
            {
                treeView1.Nodes.Add(NodesInfo.Rows[i]["Name"].ToString()).Checked = true;
                treeView1.Nodes[i].Name = NodesInfo.Rows[i]["Name"].ToString();
            }
        }

        /// <summary>
        /// Побудова дерева зв'язків
        /// </summary>
        private void BuildEdgesTree()
        {
            for (int i = 0; i < EdgesInfo.Rows.Count; i++)
            {
                treeView2.Nodes.Add(EdgesInfo.Rows[i]["Route"].ToString()).Checked = true;
                treeView2.Nodes[i].Name = EdgesInfo.Rows[i]["Route"].ToString();
            }
        }

        //// <summary>
        /// Після завантаження форми
        /// </summary>
        /// <param name="sender">Надсилач</param>
        /// <param name="e">Декскриптор події</param>
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!IsChecking)
            {
                IsChecking = true;
                for (int i = 0; i < treeView2.Nodes.Count; i++)
                    if (treeView2.Nodes[i].Text.Contains(e.Node.Text))
                        treeView2.Nodes[i].Checked = e.Node.Checked;
                IsChecking = false;
                RefreshMap();
            }         
        }

        //// <summary>
        /// Після завантаження форми
        /// </summary>
        /// <param name="sender">Надсилач</param>
        /// <param name="e">Декскриптор події</param>
        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!IsChecking)
            {
                IsChecking = true;
                string[] Names = e.Node.Text.Split(new string[] { " – " }, StringSplitOptions.None);
                string From = Names[0];
                string To = Names[1];
                int ExistFrom = 0;
                int ExistTo = 0;
                for (int i = 0; i < treeView2.Nodes.Count; i++)
                {
                    if (treeView2.Nodes[i].Checked && treeView2.Nodes[i].Text.Contains(From))
                        ExistFrom++;
                    if (treeView2.Nodes[i].Checked && treeView2.Nodes[i].Text.Contains(To))
                        ExistTo++;
                }
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                    if (treeView1.Nodes[i].Text.Contains(From))
                    {
                        treeView1.Nodes[i].Checked = ExistFrom > 0 ? true : false;
                        break;
                    }
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                    if (treeView1.Nodes[i].Text.Contains(To))
                    {
                        treeView1.Nodes[i].Checked = ExistTo > 0 ? true : false ;
                        break;
                    }
                IsChecking = false;
                RefreshMap();
            }
        }
        
        /// <summary>
        /// Оновлення мапи
        /// </summary>
        private void RefreshMap()
        {
            BuildGraph();
            ShowGraphOnMap();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                if (treeView1.Nodes[i].Checked)
                {
                    comboBox1.Items.Add(treeView1.Nodes[i].Text);
                    comboBox2.Items.Add(treeView1.Nodes[i].Text);
                }
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        //// <summary>
        /// Після завантаження форми
        /// </summary>
        /// <param name="sender">Надсилач</param>
        /// <param name="e">Декскриптор події</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (((comboBox1.Text == null || comboBox2.Text == null) || (comboBox1.Text == "" | comboBox2.Text == ""))
                )
            {
                MessageBox.Show("Задайте цільові вершини!!!");
                return;
            }
            int k1 = -1;
            int k2 = -2;
            k1 = treeView1.Nodes.IndexOfKey(comboBox1.Text);
            k2 = treeView1.Nodes.IndexOfKey(comboBox2.Text);
            if (!(treeView1.Nodes[k1].Checked && treeView1.Nodes[k2].Checked))
            {
                MessageBox.Show("Задайте правильно цільові вершини!!!");
                return;
            }
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("Та сама вершина, відстань - 0");
                return;
            }
            int[] way;
            ShowGraphOnMap();
            double? Length = DjikstraShortestWayLenght(NodesIDs[comboBox1.Text], NodesIDs[comboBox2.Text], Convert.ToInt32(numericUpDown1.Value), out way);            
            TopLayer = new GMapOverlay("Path");
            gMapControl1.Overlays.Add(TopLayer);
            if (way == null)
            {
                ShowGraphOnMap();
                return;
            }
            for (int i = 0; i < way.Length-1; i++)
            {
                GMapRoute Route = new GMapRoute(
                    new List<PointLatLng>() {
                        new PointLatLng() { Lat = NodesCoordinates[way[i]].Lat, Lng = NodesCoordinates[way[i]].Lng },
                        new PointLatLng() { Lat = NodesCoordinates[way[i+1]].Lat, Lng = NodesCoordinates[way[i+1]].Lng  }
                    }, " ");
                Route.Stroke = new Pen(Brushes.Red);
                Route.Stroke.Width = 7;
                TopLayer.Routes.Add(Route);
                TopLayer.Markers.Add(new GMarkerGoogle(new PointLatLng()
                { Lat = NodesCoordinates[way[i]].Lat, Lng = NodesCoordinates[way[i]].Lng }, GMarkerGoogleType.blue_small)
                { ToolTipMode = MarkerTooltipMode.Always, ToolTipText = NodesIDs.FirstOrDefault(node => node.Value == way[i]).Key }
                );
            }
            TopLayer.Markers.Add(new GMarkerGoogle(new PointLatLng()
            { Lat = NodesCoordinates[way[way.Length - 1]].Lat, Lng = NodesCoordinates[way[way.Length - 1]].Lng }, GMarkerGoogleType.blue_small)
            { ToolTipMode = MarkerTooltipMode.Always, ToolTipText = NodesIDs.FirstOrDefault(node => node.Value == way[way.Length - 1]).Key }
            );
            MessageBox.Show("Шлях від " + comboBox1.Text + " до " + comboBox2.Text + " складає "
                + Length + " кілометрів.");
        }
        
        /// <summary>
        /// Алгоритм Дейкстри, знаходить найкоротшу відстань між точками графа і шлях по точках
        /// </summary>
        /// <param name="startIndex"> Стартова точка </param>
        /// <param name="endIndex"> Кінцева точка </param>
        /// <param name="way"> Масив, в якому по порядку вказано ID точок для проїзду (найкоротший шлях) </param>
        /// <returns> Довжина найкоротшого шляху </returns>
        public double? DjikstraShortestWayLenght(int startIndex, int endIndex, int miliSeconds, out int[] way)
        {
            double[] MinimalLenghts = new double[IDsGraphAjadencyList.Count];
            for (int i = 0; i < MinimalLenghts.Length; i++)
                MinimalLenghts[i] = Double.MaxValue;
            MinimalLenghts[startIndex] = 0;
            bool[] PermanenlLabels = new bool[IDsGraphAjadencyList.Count];
            int[] PreviousNodes = new int[IDsGraphAjadencyList.Count];
            int CurrentIndex = startIndex;
            TopLayer = new GMapOverlay("Djikstra");
            gMapControl1.Overlays.Add(TopLayer);
            TopLayer.Markers.Add(new GMarkerGoogle(
                new PointLatLng() { Lat = NodesCoordinates[CurrentIndex].Lat, Lng = NodesCoordinates[CurrentIndex].Lng},
                GMarkerGoogleType.orange_small));
            gMapControl1.Refresh();
            PermanenlLabels[startIndex] = true;
            try
            {
                do
                {
                    for (int v = 0; v < IDsGraphAjadencyList[CurrentIndex].Count; v++)
                        if (!PermanenlLabels[IDsGraphAjadencyList[CurrentIndex][v]])
                            if (MinimalLenghts[IDsGraphAjadencyList[CurrentIndex][v]] > MinimalLenghts[CurrentIndex] + DistancesGraphAjadencyList[CurrentIndex][v])
                            {
                                MinimalLenghts[IDsGraphAjadencyList[CurrentIndex][v]] = MinimalLenghts[CurrentIndex] + DistancesGraphAjadencyList[CurrentIndex][v];
                                PreviousNodes[IDsGraphAjadencyList[CurrentIndex][v]] = CurrentIndex;
                            }
                    int MinimalLenghtVertexIndex = -1;
                    double MinL = double.MaxValue;
                    for (int i = 0; i < IDsGraphAjadencyList.Count; i++)
                        if (!PermanenlLabels[i])
                            if (MinimalLenghts[i] < MinL)
                            {
                                MinL = MinimalLenghts[i];
                                MinimalLenghtVertexIndex = i;
                            }
                    PermanenlLabels[MinimalLenghtVertexIndex] = true;
                    CurrentIndex = MinimalLenghtVertexIndex;
                    GMapRoute Route = new GMapRoute(
                        new List<PointLatLng>() {
                    new PointLatLng() { Lat = NodesCoordinates[PreviousNodes[CurrentIndex]].Lat, Lng = NodesCoordinates[PreviousNodes[CurrentIndex]].Lng },
                    new PointLatLng() { Lat = NodesCoordinates[MinimalLenghtVertexIndex].Lat, Lng = NodesCoordinates[MinimalLenghtVertexIndex].Lng  }
                        }, " ");
                    Route.Stroke = new Pen(Brushes.Orange);
                    Route.Stroke.Width = 5;
                    TopLayer.Routes.Add(Route);
                    TopLayer.Markers.Add(new GMarkerGoogle(
                        new PointLatLng() { Lat = NodesCoordinates[CurrentIndex].Lat, Lng = NodesCoordinates[CurrentIndex].Lng },
                        GMarkerGoogleType.orange_small));
                    gMapControl1.Refresh();
                    System.Threading.Thread.Sleep(miliSeconds);
                } while (CurrentIndex != endIndex);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Неможливо доступитися до цільової вершини!!!", "СТОП");
                way = null;
                return null;
            }
            List<int> Way = new List<int>();
            while (CurrentIndex != startIndex)
            {
                Way.Add(CurrentIndex);
                CurrentIndex = PreviousNodes[CurrentIndex];
            }
            Way.Add(startIndex);
            Way.Reverse();
            way = Way.ToArray();
            return MinimalLenghts[endIndex];
        }
    }
}
