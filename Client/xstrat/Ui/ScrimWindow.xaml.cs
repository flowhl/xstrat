using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public Scrim scrim { get; set; }
        public Core.Window window { get; set; }

        public ScrimWindow(xstrat.Core.Window window)
        {
            this.window = window;
            type = 0;
            InitializeComponent();
            UpdateUI();

        }
        public ScrimWindow(Scrim scrim)
        {
            this.scrim = scrim;
            type = 1;
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            if(type == 0)
            {
                TypeLabel.Content = "Create Scrim";
                TitleBox.Text = "Title";
                CommentBox.Text = "Description";
                FromHour.Value = window.StartDateTime.Hour;
                FromMinute.Value = window.StartDateTime.Minute;
                ToHour.Value = window.EndDateTime.Hour;
                ToMinute.Value = window.EndDateTime.Minute;
                CreatorLabel.Content = "";
                CreationDateLabel.Content = "";
                CalendarDatePicker.SelectedDate = window.StartDateTime.Date;

            }
            else if(type == 1)
            {
                DateTime start = DateTime.ParseExact(scrim.time_start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact(scrim.time_end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                TypeLabel.Content = "Edit Scrim";
                TitleBox.Text = scrim.title;
                CommentBox.Text = scrim.comment;
                CalendarDatePicker.SelectedDate = start.Date;
                FromHour.Value = start.Hour;
                FromMinute.Value = start.Minute;
                ToHour.Value = end.Hour;
                ToMinute.Value = end.Minute;
                MapSelector1.SelectIndex(Globals.Maps.IndexOf(Globals.Maps.Where(x => x.id == scrim.map_1_id).FirstOrDefault()));
                MapSelector2.SelectIndex(Globals.Maps.IndexOf(Globals.Maps.Where(x => x.id == scrim.map_2_id).FirstOrDefault()));
                MapSelector3.SelectIndex(Globals.Maps.IndexOf(Globals.Maps.Where(x => x.id == scrim.map_3_id).FirstOrDefault()));
                CreatorLabel.Content = "";
                CreationDateLabel.Content = "";
            }
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(type == 1)
            {
                string start = CalendarDatePicker.SelectedDate.ToString() + " " + FromHour.Value + ":" + FromMinute.Value + ":00";
                string end = CalendarDatePicker.SelectedDate.ToString() + " " + ToHour.Value + ":" + ToMinute.Value + ":00";
                var result = await ApiHandler.SaveScrim(scrim.id, TitleBox.Text, CommentBox.Text, start, end, OpponentNameBox.Text, MapSelector1.selectedMap.id, MapSelector2.selectedMap.id, MapSelector3.selectedMap.id, ScrimModeSelector.selectedOffDayType.id);
                if (result.Item1)
                {
                    Notify.sendSuccess("Success", "Saved successfully");

                }
                else
                {
                    Notify.sendError("Error", result.Item2);
                }
            }
            else if(type == 0)
            {
                string start = CalendarDatePicker.SelectedDate.ToString() + " " + FromHour.Value + ":" + FromMinute.Value + ":00";
                string end = CalendarDatePicker.SelectedDate.ToString() + " " + ToHour.Value + ":" + ToMinute.Value + ":00";
                int? scrim_id = null;
                var result = await ApiHandler.NewScrim(ScrimModeSelector.selectedScrimMode.id, TitleBox.Text, start, end);
                if (result.Item1)
                {
                    string response = result.Item2;
                    //convert to json instance
                    JObject json = JObject.Parse(response);
                    var data = json.SelectToken("data").ToString();
                    if (data != null && data != "")
                    {
                        xstrat.Json.Data dresult = JsonConvert.DeserializeObject<Json.Data>(data);
                        scrim_id = dresult.insertId;
                    }
                    else
                    {
                        Notify.sendError("Error", "insertId could not be loaded");
                        throw new Exception("insertId could not be loaded");
                    }
                    if(scrim_id != null)
                    {
                        int map1 = -1;
                        if(MapSelector1.selectedMap != null)
                        {
                            map1 = MapSelector1.selectedMap.id;
                        }
                        int map2 = -1;
                        if (MapSelector2.selectedMap != null)
                        {
                            map2 = MapSelector2.selectedMap.id;
                        }
                        int map3 = -1;
                        if (MapSelector3.selectedMap != null)
                        {
                            map3 = MapSelector3.selectedMap.id;
                        }
                        var result2 = await ApiHandler.SaveScrim(scrim_id.GetValueOrDefault(), TitleBox.Text, CommentBox.Text, start, end, OpponentNameBox.Text, map1, map2, map3, ScrimModeSelector.selectedScrimMode.id);
                        if (result2.Item1)
                        {
                            Notify.sendSuccess("Success", "Saved successfully");
                        }
                        else
                        {
                            Notify.sendError("Error when modifying scrim data", result2.Item2);
                        }
                    }
                    else
                    {
                        Notify.sendError("Error", "insertId could not be loaded");
                        throw new Exception("insertId could not be loaded");
                    }
                   
                }
                else
                {
                    Notify.sendError("Error", result.Item2);
                }

            }
            
        }
    }
}
