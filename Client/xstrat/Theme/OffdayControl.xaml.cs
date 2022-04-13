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
using xstrat.Json;

namespace xstrat.Theme
{
    /// <summary>
    /// Interaction logic for OffdayControl.xaml
    /// </summary>
    public partial class OffdayControl : UserControl
    {
        public OffdayControl()
        {
            InitializeComponent();
            TypeSelector.CBox.SelectionChanged += CBox_SelectionChanged;
        }

        private void CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeSelector.selectedOffDayType.id == 1)
            {
                TimeControl.Visibility = Visibility.Hidden;
            }
            else
            {
                TimeControl.Visibility = Visibility.Visible;
            }
        }

        public void LoadOffDay(OffDay offDay)
        {
            //YYYY-MM-DD hh:mm:ss
            TitleText.Text = offDay.title;

            CreationDate.Content = offDay.creation_date;
            
            FromDatePicker.Text = offDay.start.Split(' ').First();
            
            FromHour.Value = int.Parse(offDay.start.Split(' ')[1].Split(':').First());
            FromMinute.Value = int.Parse(offDay.start.Split(' ')[1].Split(':')[1]);
            
            ToHour.Value = int.Parse(offDay.end.Split(' ')[1].Split(':').First());
            ToMinute.Value = int.Parse(offDay.end.Split(' ')[1].Split(':')[1]);
            
            TypeSelector.SelectIndex(offDay.typ);
            if(offDay.typ == 1)
            {
                TimeControl.Visibility = Visibility.Hidden;
            }

        }
        public OffDay GetOffDay()
        {
            string start = FromDatePicker.Text + " " + FromHour.Value + ":" + FromMinute.Value + ":00";
            string end = FromDatePicker.Text + " " + ToHour.Value + ":" + ToMinute.Value + ":00";
            OffDay offDay = new OffDay(0, 0, null, TypeSelector.selectedOffDayType.id, TitleText.Text, start, end);
            return offDay;
        }
    }
}
