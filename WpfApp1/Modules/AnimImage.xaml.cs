using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Modules
{
    /// <summary>
    /// AnimImage.xaml 的交互逻辑
    /// </summary>
    public partial class AnimImage : UserControl
    {
        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(AnimImage), new UIPropertyMetadata(0.0));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(AnimImage), new UIPropertyMetadata(0.0));

        public double ScaleX
        {
            get { return (double)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }
        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register("ScaleX", typeof(double), typeof(AnimImage), new UIPropertyMetadata(1.0));

        public double ScaleY
        {
            get { return (double)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }
        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register("ScaleY", typeof(double), typeof(AnimImage), new UIPropertyMetadata(1.0));

        public double Degree;
        private string FileSrc = "";

        private bool _IsVisible = false;
        public new bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                if (value)
                    this.LoadUiImmediate();
            }
        }

        private bool IsUiLoaded = false;

        public void LoadUiImmediate()
        {
            if (!IsUiLoaded)
            {
                IsUiLoaded = true;
                try
                {
                    //if (File.Exists(FileSrc))
                    //this.ImgMain.Source = new BitmapImage(new Uri(FileSrc));
                }
                catch { }

                //Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        public AnimImage(string CnName, string EnName)
        {
            InitializeComponent();
            this.TbkTitle.Text = CnName;
            this.TbkTitle.Name = EnName;
            this.Loaded += ImageItem_Loaded;
            this.DataContext = this;
        }

        ObservableCollection<BitmapImage> backgroundList;
        ObservableCollection<BitmapImage> circleList;

        public int index1 = 0;  //记录索引
        public bool isRendering1 = false;

        public int index2 = 0;  //记录索引
        public bool isRendering2 = false;

        private void ImageItem_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ImageItem_Loaded;
            AsynchUtils.AsynchSleepExecuteFunc(this.Dispatcher, LoadUiImmediate, 0.5);

            InitBackgroundImageList();
            InitCircleImageList();

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        public void Dispose()
        {
            //this.ImgMain.Source = null;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                isRendering1 = true;
                isRendering2 = true;
                System.Threading.Thread.Sleep(40); //停1秒
            }
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (isRendering1)
            {
                if (index1 < backgroundList.Count)
                {
                    this.imgViewer1.Source = backgroundList[index1];
                    index1++;
                }
                else
                {
                    index1 = 0;
                }
                isRendering1 = false;
            }
            else
            {
                //this.imgViewer1.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\animImagenormal.png"));
            }

            if (isRendering2)
            {
                if (index2 < circleList.Count)
                {
                    this.imgViewer2.Source = circleList[index2];
                    index2++;
                }
                else
                {
                    index2 = 0;
                }
                isRendering2 = false;
            }
          
        }

        public void InitBackgroundImageList()
        {
            backgroundList = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < 39; i++)
            {
                BitmapImage bmImg = null;
                if (i > 9)
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\background\\0_000" + i.ToString() + ".png"));
                else
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\background\\0_0000" + i.ToString() + ".png"));

                backgroundList.Add(bmImg);
            }
        }

        public void InitCircleImageList()
        {
            circleList = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < 19; i++)
            {
                BitmapImage bmImg = null;
                if (i > 9)
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\circle\\1_000" + i.ToString() + ".png"));
                else
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\circle\\1_0000" + i.ToString() + ".png"));

                circleList.Add(bmImg);
            }
        }



    }

}
