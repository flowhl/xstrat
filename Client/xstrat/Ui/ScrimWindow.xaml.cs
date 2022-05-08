using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using xstrat.Core;
using xstrat.Json;

namespace xstrat.Ui
{
    /// <summary>
    /// Interaction logic for ScrimWindow.xaml
    /// </summary>
    public partial class ScrimWindow : System.Windows.Window
    {
        /// <summary>
        /// type
        /// 0 - new scrim
        /// 1 - edit scrim
        /// </summary>
        public int type { get; set; }
        public ScrimWindow(xstrat.Core.Window window)
        {
            type = 0;
            InitializeComponent();
        }
        public ScrimWindow(Scrim scrim)
        {
            type = 1;
            InitializeComponent();
        }
    }
}
