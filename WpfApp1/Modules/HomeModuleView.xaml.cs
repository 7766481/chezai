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
using static WpfApp1.MainWindow;

namespace WpfApp1.Modules
{
    /// <summary>
    /// HomeModuleView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeModuleView : BaseModuleView
    {
        ObservableCollection<BitmapImage> bmList;
        int index = 0;  //记录索引
        bool isRendering = false;

        public HomeModuleView()
        {
            InitializeComponent();
            InitList();

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                isRendering = true;
                System.Threading.Thread.Sleep(40); //停1秒
            }
        }

        public void InitList()
        {
            bmList = new ObservableCollection<BitmapImage>();
            for (int i = 0; i < 90; i++)
            {
                BitmapImage bmImg = null;
                if (i > 9)
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\3D\\1_00" + i.ToString() + ".png"));
                else
                    bmImg = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "\\images\\3D\\1_000" + i.ToString() + ".png"));

                bmList.Add(bmImg);
            }
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (isRendering)
            {
                if (index < bmList.Count)
                {
                    this.imgViewer.Source = bmList[index];
                    //this.imgViewer.Width = this.imgViewer.Source.Width  * 0.8;
                    //this.imgViewer.Height = this.imgViewer.Source.Height * 0.8;
                    //this.imgViewer.Width = this.imgViewer.Source.Width  * 1;
                    //this.imgViewer.Height = this.imgViewer.Source.Height * 1;
                    index++;
                }
                else
                {
                    index = 0;
                }
                isRendering = false;
            }
        }

        //车内
        private void gridCarIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (messageSender != null)
            {
                messageSender("CarIn");
            }
        }
        //车外
        private void gridCarOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (messageSender != null)
            {
                messageSender("CarOut");
            }
        }

        public void Receiver(string sKey)
        {
            messageSender(sKey);
        }

        private void BaseModuleView_Loaded(object sender, RoutedEventArgs e)
        {
            //< local:CarouselModuleView HorizontalAlignment = "Stretch" VerticalAlignment = "Stretch" />
            CarouselModuleView CarouselModuleView = new CarouselModuleView();
            CarouselModuleView.messageSender = this.Receiver;
            GdRoot.Children.Insert(1, CarouselModuleView);
        }
    }
}
