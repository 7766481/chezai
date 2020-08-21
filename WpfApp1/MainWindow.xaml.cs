using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Modules;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("急停");
        }

        private void imgMin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void imgClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Environment.Exit(0);
            //Application.Current.Shutdown();
        }

        //根据委托创建方法
        public void Receiver(string sKey)
        {
            //this.MainFormLabel.Content = Counter;
            // 创建内容面板
            BaseModuleView moduleView = this.CreateContentView(sKey);
            this.GdContent.Children.Clear();
            this.GdContent.Children.Add(moduleView);
        }

        //CreateContentView
        public BaseModuleView CreateContentView(string sKey)
        {
            BaseModuleView baseModuleView = null;
            switch (sKey)
            {
                case "Home"://主页
                    baseModuleView = new HomeModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "CarIn"://车内监控
                    baseModuleView = new CarInModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "CarOut"://车外监控
                    baseModuleView = new CarOutModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;
                case "SupportingLegs"://支撑腿 SupportingLegsModuleView
                    baseModuleView = new SupportingLegsModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "LodgingMechanism"://倒伏机构 LodgingMechanismModuleView
                    baseModuleView = new LodgingMechanismModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "Skylight"://天窗 SkylightModuleView
                    baseModuleView = new SkylightModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "LiftingPlatform"://升降台 LiftingPlatformModuleView
                    baseModuleView = new LiftingPlatformModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "ElectromagneticAttraction"://电磁吸合 ElectromagneticAttractionModuleView
                    baseModuleView = new ElectromagneticAttractionModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "LevelingPlatform"://调平平台 LevelingPlatformModuleView
                    baseModuleView = new LevelingPlatformModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "Radar"://雷达 RadarModuleView
                    baseModuleView = new RadarModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "Photoelectricity": //光电 PhotoelectricityModuleView
                    baseModuleView = new PhotoelectricityModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "JammingGun": //干扰炮 JammingGunModuleView
                    baseModuleView = new JammingGunModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                case "CheckAndFight": //查打一体 CheckAndFightModuleView
                    baseModuleView = new CheckAndFightModuleView();
                    baseModuleView.messageSender = this.Receiver;
                    break;

                default:
                    baseModuleView = new HomeModuleView();
                    break;
            }
            return baseModuleView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Receiver("Home");
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            AsynchUtils.Dispose();
        }
    }

}
