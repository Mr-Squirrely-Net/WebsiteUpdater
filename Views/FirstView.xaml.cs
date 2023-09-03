using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.Storage;
using Windows.Storage.Pickers;
using HandyControl.Controls;
using WinRT.Interop;

using WebsiteUpdater.Code;

namespace WebsiteUpdater.Views {
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class FirstView : Page {
        
        public FirstView() {
            InitializeComponent();
        }

        internal HandyControl.Controls.Window ParentWindow { get; set; }

        private async void BrowseButton_OnClick(object sender, RoutedEventArgs e) {
            FolderPicker picker = new() {
                SuggestedStartLocation = PickerLocationId.Desktop,
                FileTypeFilter = { "*" }
            };

            InitializeWithWindow.Initialize(picker, App.HWND);

            StorageFolder folder = await picker.PickSingleFolderAsync();
            if (folder != null) {
                DirectoryBox.Text = folder.Path;
                Reference.WebsiteDirectory = folder.Path;
            }

            if (OpenButton.Visibility != Visibility.Hidden) return;
            OpenButton.Visibility = Visibility.Visible;
            OpenButton.IsEnabled = true;
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e) {
            try {
                ParentWindow.Close();
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }
        }
    }
}
