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
using System.Windows.Navigation;
using System.Windows.Shapes;
using xstrat.MVVM.View;

namespace xstrat.Ui
{
    /// <summary>
    /// Interaction logic for ScrimFinderControl.xaml
    /// </summary>
    public partial class ScrimFinderControl : UserControl
    {
        public bool mobtn { get; set; } = false;
        public bool tubtn { get; set; } = false;
        public bool webtn { get; set; } = false;
        public bool thbtn { get; set; } = false;
        public bool frbtn { get; set; } = false;
        public bool sabtn { get; set; } = false;
        public bool subtn { get; set; } = false;

        private Brush disabledBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#202020"));
        private Brush enabledBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#336cb5"));

        public ScrimFinderControl()
        {
            InitializeComponent();
        }

        private void MoBtn_Click(object sender, RoutedEventArgs e)
        {
            mobtn = !mobtn;
            UpdateButtonColors();
        }

        private void TuBtn_Click(object sender, RoutedEventArgs e)
        {
            tubtn = !tubtn;
            UpdateButtonColors();
        }

        private void WeBtn_Click(object sender, RoutedEventArgs e)
        {
            webtn = !webtn;
            UpdateButtonColors();
        }

        private void ThBtn_Click(object sender, RoutedEventArgs e)
        {
            thbtn = !thbtn;
            UpdateButtonColors();
        }

        private void FrBtn_Click(object sender, RoutedEventArgs e)
        {
            frbtn = !frbtn;
            UpdateButtonColors();
        }

        private void SaBtn_Click(object sender, RoutedEventArgs e)
        {
            sabtn = !sabtn;
            UpdateButtonColors();
        }

        private void SuBtn_Click(object sender, RoutedEventArgs e)
        {
            subtn = !subtn;
            UpdateButtonColors();
        }
        private void UpdateButtonColors()
        {
            if (mobtn)
            {
                MoBtn.Background = enabledBrush;
            }
            else
            {
                MoBtn.Background = disabledBrush;
            }

            if (tubtn)
            {
                TuBtn.Background = enabledBrush;
            }
            else
            {
                TuBtn.Background = disabledBrush;
            }

            if (webtn)
            {
                WeBtn.Background = enabledBrush;
            }
            else
            {
                WeBtn.Background = disabledBrush;
            }

            if (thbtn)
            {
                ThBtn.Background = enabledBrush;
            }
            else
            {
                ThBtn.Background = disabledBrush;
            }

            if (frbtn)
            {
                FrBtn.Background = enabledBrush;
            }
            else
            {
                FrBtn.Background = disabledBrush;
            }

            if (sabtn)
            {
                SaBtn.Background = enabledBrush;
            }
            else
            {
                SaBtn.Background = disabledBrush;
            }

            if (subtn)
            {
                SuBtn.Background = enabledBrush;
            }
            else
            {
                SuBtn.Background = disabledBrush;
            }
        }

        
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject ucParent = this.Parent;
            if (ucParent != null)
            {
                while (!(ucParent is UserControl))
                {
                    ucParent = LogicalTreeHelper.GetParent(ucParent);
                }
                var sv = ucParent as ScrimView;
                sv.SearchButtonClicked();
            }
        }

        

    }
}
