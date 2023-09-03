using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WebsiteUpdater {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        internal static readonly IntPtr HWND = new WindowInteropHelper(Current.MainWindow ?? throw new InvalidOperationException()).Handle;
        
    }
}
