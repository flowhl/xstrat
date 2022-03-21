using System;
using System.Collections.Generic;
using System.IO;
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
using xstrat.Core;

namespace xstrat.MVVM.View
{
    /// <summary>
    /// Interaction logic for StratMakerView.xaml
    /// </summary>
    public partial class StratMakerView : UserControl
    {
        public StratMakerView()
        {
            InitializeComponent();
            StratHandler.Initialize();
            var list = StratHandler.GetMapNames();
            foreach (var name in list)
            {
                var comboitem = new ComboBoxItem();
                comboitem.Content = name;
                MapSelector.Items.Add(comboitem);
            }
        }


        private void MapSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageStack.Children.Clear();
            var index = MapSelector.SelectedIndex;
            var images = StratHandler.getFloorsByListPos(index);
            foreach (var image in images)
            {
                byte[] binaryData = Convert.FromBase64String(image.Item2);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image img = new Image();
                img.Source = bi;
                img.Height = 1080;
                img.Width = 1920;
                ImageStack.Children.Add(img);
            }
        }
    }
}
