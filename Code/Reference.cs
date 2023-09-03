using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using WebsiteUpdater.Views;

namespace WebsiteUpdater.Code {
    internal static class Reference {

        internal static string? WebsiteDirectory { get; set; }

        internal const string MainTemplate = "template.html";
        internal const string HeadPart = "head.html";
        internal const string NavigationPart = "navigation.html";
        internal const string FooterPart = "footer.html";
        internal const string ScriptsPart = "scripts.html";
        
    }
}
