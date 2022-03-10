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

namespace xstrat.Theme
{
    /// <summary>
    /// Interaction logic for Routine.xaml
    /// </summary>
    public partial class Routine : UserControl
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }

        public Routine()
        {
            InitializeComponent();

        }

        private void Count_Minus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Count > 0)
            {
                Count--;
            }
            else if(Count < 0)
            {
                Count = 0;
            }
            UpdateUi();
        }

        private void Count_Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Count >= 0)
            {
                Count++;
            }
            else if (Count < 0)
            {
                Count = 0;
            }
            UpdateUi();
        }

        private void Duration_Minus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Duration > 0)
            {
                Duration--;
            }
            else if (Count < 0)
            {
                Duration = 0;
            }
            UpdateUi();
        }

        private void Duration_Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Duration >= 0 && Duration <= 599)
            {
                Duration++;
            }
            else if (Count < 0)
            {
                Duration = 0;
            }
            UpdateUi();
        }

        private void UpdateUi()
        {
            Count_Value.Content = Count.ToString();
            Duration_Value.Content = DurationConverter(Duration);
            Body_Textbox.Text = Body;
            Header_Textbox.Text = Header;
        }

        private string DurationConverter(int value)
        {
            int minutes = (int)(value / 60);
            int seconds = value % 60;
            return minutes + ":" + seconds.ToString().PadLeft(2 - seconds.ToString().Length, '0');
        }

        private void Header_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Header = Header_Textbox.Text;
        }

        private void Body_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Body = Body_Textbox.Text;
        }
    }
}
