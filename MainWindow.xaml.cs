using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using HandyControl.Controls;
using HandyControl.Tools;
using HtmlAgilityPack;

using WebsiteUpdater.Code;
using WebsiteUpdater.Views;
using Window = HandyControl.Controls.Window;

namespace WebsiteUpdater {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow  {

        private readonly Window _browseWindow = new() {
            Title = "Browse",
            ResizeMode = ResizeMode.NoResize,
            ShowInTaskbar = false,
            ShowMaxButton = false,
            ShowMinButton = false,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Width = 400,
            Height = 200
        };

        public MainWindow() {
            SystemBackdropType = OSVersionHelper.IsWindows11_OrGreater ? BackdropType.Mica : BackdropType.Acrylic;
            InitializeComponent();
            //Todo: add a way to remember last chosen website directory
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            _browseWindow.Content = new FirstView() { ParentWindow = _browseWindow };
            _browseWindow.Owner = this;
            _browseWindow.ShowDialog();
            
            Content = new MainView();
            Generator.Load();
            Generator.Generate();

            const string customParagraph = "<p>This is a custom paragraph</p>";
            Generator.Generate(Generator.Document, "customparagraph", customParagraph);
        }
        
    }
}
