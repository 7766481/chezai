using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1.Modules
{
    /// <summary>
    /// CarouselModuleView.xaml 的交互逻辑
    /// </summary>
    public partial class CarouselModuleView : BaseModuleView
    {
        //private List<string> FileItems;
        //private void LoadImgList()
        //{
        //    this.FileItems = new List<string>();
        //    string sPath = AppDomain.CurrentDomain.BaseDirectory + "Imgs";
        //    DirectoryInfo dir = new DirectoryInfo(sPath);
        //    FileInfo[] fis = dir.GetFiles();
        //    if (fis.Length > 0)
        //    {
        //        for (int j = 0; j < fis.Length; j++)
        //            this.FileItems.Add(fis[j].FullName);
        //    }
        //}
        //List<System.Drawing.Point> list = new List<System.Drawing.Point>();
        //Bitmap bmpSrc = new Bitmap(@"back3.bmp");
        //List<int> listx = new List<int>();
        //public void LoadPointList()
        //{
        //    list.Clear();
        //    for (int y = 0; y < bmpSrc.Height; y++)
        //    {
        //        for (int x = 0; x < bmpSrc.Width; x++)
        //        {
        //            System.Drawing.Color color = bmpSrc.GetPixel(x, y);
        //            if (color.R < 255)//if (color.R < 255 && color.G < 255 && color.B != 255)
        //            {
        //                if (!listx.Contains(x))
        //                {
        //                    Graphics g = Graphics.FromImage(bmpSrc);
        //                    //g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Red, 1), x, y, bmpSrc.Width, bmpSrc.Height);
        //                    if (y > 400)
        //                        g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Red, 1), x, y, 1, 1);
        //                    if (y > 400)
        //                    {
        //                        System.Drawing.Point p = new System.Drawing.Point();
        //                        p.X = x;
        //                        p.Y = y;
        //                        list.Add(p);
        //                        listx.Add(x);
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    imgViewer2.Source = ChangeBitmapToImageSource(bmpSrc);
            //for (int i = 0; i < 10110; i++)
            //{
            //    int r = new Random().Next(300,1620);
            //    Label l = new Label();
            //    l.Content = "1.";
            //    l.Background = new SolidColorBrush(Colors.Red);
            //    CvMain.Children.Add(l);
            //    Canvas.SetTop(l, CovertY(r, 0));
            //    Canvas.SetLeft(l, r);
            //}
        //}
 

        public CarouselModuleView()
        {
            InitializeComponent();
            //this.LoadImgList();
            //this.LoadPointList();
            this.Loaded += CarouselModuleView_Loaded;
            this.Unloaded += CarouselModuleView_Unloaded;
        }

        private void UpdateTextRight()
        {
            while (true)
            {
                TimeSpan ts = DateTime.Now.Subtract(dtUp);
                if (ts.Seconds > 10)
                {
                    for (int i = 0; i < this.ElementList.Count; i++)
                    {
                        AnimImage oItem = this.ElementList[i];
                        oItem.Degree += 0.1;
                    }
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                      (ThreadStart)delegate ()
                      {
                          this.UpdateLocation();
                      }
                      );
                    Thread.Sleep(20);
                }
            }
        }

        private void CarouselModuleView_Unloaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering -= new EventHandler(CompositionTarget_Rendering);
        }

        private void CarouselModuleView_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= CarouselModuleView_Loaded;

            this.CreateElements();

            this.GdRoot.MouseLeftButtonDown += GdRoot_MouseLeftButtonDown;
            this.MouseMove += Carousel2DView_MouseMove;
            this.MouseUp += Carousel2DView_MouseUp;

            //新建线程
            Thread thread = new Thread(UpdateTextRight);
            thread.Start();
        }

        #region Create Elements

        private double Radius = 700d;
        private double VisualCount = 10d;
        private List<AnimImage> ElementList;
        private double CenterDegree = 180d;
        private double TotalDegree = 0;
        private double ElementWidth = 200;
        private double ElementHeight = 221;
        private DateTime dtUp = DateTime.Now;
        private double GetScaledSize(double degrees)
        {
            return GetCoefficient(degrees);
        }

        private double GetCoefficient(double degrees)
        {
            return 1.0 - Math.Cos(ConvertToRads(degrees)) / 2.0 - 0.5;
        }

        private double ConvertToRads(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        private int GetZValue(double degrees)
        {
            return (int)((360 * GetCoefficient(degrees)) * 1000);
        }

        private void CreateElements()
        {
            string[] myArrayCnName = { "支撑腿", "倒伏机构", "天窗", "升降台", "电磁吸合", "调平平台", "雷达", "光电", "干扰炮", "查打一体" };
            string[] myArrayEnName = { "SupportingLegs", "LodgingMechanism", "Skylight", "LiftingPlatform", "ElectromagneticAttraction", "LevelingPlatform", "Radar", "Photoelectricity", "JammingGun", "CheckAndFight" };


            double dAverageDegree = 360d / VisualCount;
            this.TotalDegree = 10 * dAverageDegree;

            this.ElementList = new List<AnimImage>();
            for (int i = 0; i < myArrayCnName.Length; i++)
            {
                AnimImage oItem = new AnimImage(myArrayCnName[i], myArrayEnName[i]);
                oItem.MouseLeftButtonDown += OItem_MouseLeftButtonDown;
                oItem.MouseLeftButtonUp += OItem_MouseLeftButtonUp;
                oItem.Width = this.ElementWidth;
                oItem.Height = this.ElementHeight;
                oItem.Y = 0d;
                oItem.Degree = i * dAverageDegree;
                this.ElementList.Add(oItem);
            }

            this.UpdateLocation();
        }

        private AnimImage CurNavItem;

        private void OItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.IsMouseDown && CurNavItem == sender && this.TotalMoveDegree < 50)
            {
                this.InertiaDegree = CenterDegree - this.CurNavItem.Degree;
                //this.CurNavItem = null;
                this.IsMouseDown = false;
                if (this.InertiaDegree != 0)
                    CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
                e.Handled = true;
            }
            else
            {
                this.CurNavItem = null;
            }
        }

        private void OItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurNavItem = sender as AnimImage;
        }

        private void UpdateLocation()
        {
            for (int i = 0; i < this.ElementList.Count; i++)
            {
                AnimImage oItem = this.ElementList[i];

                if (oItem.Degree - this.CenterDegree >= this.TotalDegree / 2d)
                    oItem.Degree -= this.TotalDegree;
                else if (this.CenterDegree - oItem.Degree > this.TotalDegree / 2d)
                    oItem.Degree += this.TotalDegree;

                if (oItem.Degree >= 60d && oItem.Degree < 300d) // Degree 在90-270之间的显示  if (oItem.Degree >= 0d && oItem.Degree < 360d) // Degree 在90-270之间的显示
                    this.SetElementVisiable(oItem);
                else
                    this.SetElementInvisiable(oItem);
            }
        }

        private void SetElementVisiable(AnimImage oItem)
        {
            if (oItem == null)
                return;

            if (!oItem.IsVisible)
            {
                if (!this.CvMain.Children.Contains(oItem))
                {
                    oItem.IsVisible = true;
                    this.CvMain.Children.Add(oItem);
                }
            }

            this.DoUpdateElementLocation(oItem);
        }

        private void SetElementInvisiable(AnimImage oItem)
        {
            if (oItem.IsVisible)
            {
                if (this.CvMain.Children.Contains(oItem))
                {
                    this.CvMain.Children.Remove(oItem);
                    oItem.IsVisible = false;
                }
            }
        }

        public void DoUpdateElementLocation(AnimImage oItem)
        {
            //1579  994
            double CenterX = this.GdRoot.ActualWidth / 2.0;
            double CenterY = this.GdRoot.ActualHeight / 2.0;

            //CenterX = 1580 / 2.0;
            //CenterY = 994 / 2.0;
            Radius = 1580 / 2;

            double dX = -Radius * Math.Sin(ConvertToRads(oItem.Degree));
            oItem.X = (dX + CenterX - this.ElementWidth / 2d);
            //oItem.Y = (dY + CenterY - this.ElementHeight / 2d);
            //oItem.Y = CovertY(oItem.X, oItem.Degree);
            //var res = list.FirstOrDefault(m => m.X == Convert.ToInt32(oItem.X));
            //if (res != null) {
            //    oItem.Y = Convert.ToInt32(res.Y);
            //} else
            //{
            //    oItem.Y = 0;
            //}
            Radius = 800 / 2;
            double dY = -Radius * Math.Cos(ConvertToRads(oItem.Degree));
            oItem.Y = dY + CenterY - this.ElementWidth / 2d;
            //oItem.X = 300 * Math.Cos(oItem.Degree);

            double dScale = GetScaledSize(oItem.Degree);

            //oItem.Y = CovertY(oItem.X, oItem.Degree) - (oItem.Height * dScale);
            //oItem.Y = CovertY(oItem.X, oItem.Degree) - (oItem.Height * dScale);
            oItem.ScaleX = dScale;
            oItem.ScaleY = dScale;
            int nZIndex = GetZValue(oItem.Degree);
            Canvas.SetZIndex(oItem, nZIndex);

            //oItem.TbkTitle.Text = Convert.ToString(oItem.X + ":" + oItem.Y);
            //for (int i = 0; i < 100; i++)
            //{
            //    Label l = new Label();
            //    l.Content = ".";
            //    CvMain.Children.Add(l);
            //    Canvas.SetTop(l, oItem.Y);
            //    Canvas.SetLeft(l, oItem.X);
            //}
            //Graphics g = Graphics.FromImage(bmpSrc);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black, 1), list[i].X, list[i].Y, 1, 1);
            //}
            //imgViewer2.Source = ChangeBitmapToImageSource(bmpSrc);
        }

        #endregion

        #region Drag And Move

        private bool IsMouseDown = false;
        private double PreviousX = 0;
        private double CurrentX = 0;
        private double IntervalDegree = 0;
        private double InertiaDegree = 0;
        private double TotalMoveDegree = 0;


        private void GdRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dtUp = DateTime.Now;
            this.IsMouseDown = true;
            this.IntervalDegree = 0;
            this.PreviousX = e.GetPosition(this).X;
            this.TotalMoveDegree = 0;
            CompositionTarget.Rendering -= new EventHandler(CompositionTarget_Rendering);
        }

        private void Carousel2DView_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                this.CurrentX = e.GetPosition(this).X;
                this.IntervalDegree = this.CurrentX - this.PreviousX;
                this.TotalMoveDegree += Math.Abs(this.IntervalDegree * 0.5d);
                //this.InertiaDegree = this.IntervalDegree * 5d;
                this.InertiaDegree = this.IntervalDegree * 2d;
                for (int i = 0; i < this.ElementList.Count; i++)
                {
                    AnimImage oItem = this.ElementList[i];
                    oItem.Degree += this.IntervalDegree;
                }
                this.UpdateLocation();
                this.PreviousX = this.CurrentX;
            }
        }

        private void Carousel2DView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.IsMouseDown)
            {
                this.IsMouseDown = false;
                this.CurNavItem = null;
                if (this.InertiaDegree != 0)
                {
                    CompositionTarget.Rendering -= new EventHandler(CompositionTarget_Rendering);
                    CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
                }
                dtUp = DateTime.Now;
            }
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            double dIntervalDegree = this.InertiaDegree * 0.1;
            for (int i = 0; i < this.ElementList.Count; i++)
            {
                AnimImage oItem = this.ElementList[i];
                oItem.Degree += dIntervalDegree;
            }
            this.UpdateLocation();
            this.InertiaDegree -= dIntervalDegree;
            if (Math.Abs(this.InertiaDegree) < 0.1)
            {
                CompositionTarget.Rendering -= new EventHandler(CompositionTarget_Rendering);

                if (this.CurNavItem != null)
                {
                    if (messageSender != null)
                    {
                        messageSender(CurNavItem.TbkTitle.Name);
                    }
                    this.CurNavItem = null;
                }
            }
        }

        #endregion


    }
}
