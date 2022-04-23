using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
using xstrat.Calendar;
using xstrat.Core;
using xstrat.Json;
using xstrat.Ui;

namespace xstrat.MVVM.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl, INotifyPropertyChanged
    {
        private List<OffDay> offDays = new List<OffDay>();
        public List<ICalendarEvent> _events;
        public List<ICalendarEvent> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged(() => Events);

                    // redraw days with events when Events property changes
                    if(CalendarMonthUI != null)
                    {
                        CalendarMonthUI.DrawDays();
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarView()
        {
            InitializeComponent();
            // set date of first example event to +- middle of month
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            // add example events
            Events = new List<ICalendarEvent>();
            //Events.Add(new CalendarEntry() { DateFrom = DateTime.Now.AddDays(6), DateTo = DateTime.Now.AddDays(6).AddHours(1), Label = "Scrim", typ = 0 });
            RetrieveOffDays();
            // draw days with events calendar
            CalendarMonthUI.DrawDays();

            // subscribe to double cliked event
            CalendarMonthUI.CalendarEventDoubleClickedEvent += Calendar_CalendarEventDoubleClickedEvent;
        }

        private void Calendar_CalendarEventDoubleClickedEvent(object sender, CalendarEventView e)
        {
            if (e.DataContext is ICalendarEvent calendarEvent)
            {
                MessageBox.Show($"{calendarEvent.Label} | {calendarEvent.DateFrom} - {calendarEvent.DateTo}");
                
            }
        }

        public void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            var memberExpression = (MemberExpression)exp.Body;
            var propertyName = memberExpression.Member.Name;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void RetrieveOffDays()
        {
            try
            {
                (bool, string) result = await ApiHandler.GetTeamOffDays();
                if (result.Item1)
                {
                    string response = result.Item2;
                    //convert to json instance
                    JObject json = JObject.Parse(response);
                    var data = json.SelectToken("data").ToString();
                    if (data != null && data != "")
                    {
                        List<xstrat.Json.OffDay> odList = JsonConvert.DeserializeObject<List<Json.OffDay>>(data);
                        offDays.Clear();
                        foreach (var od in odList)
                        {
                            offDays.Add(od);
                        }
                    }
                    else
                    {
                        Notify.sendError("Error", "Routines could not be created");
                        throw new Exception("Routines could not be created");
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Notify.sendError("Error", ex.Message);
            }
            
            foreach (var od in offDays)
            {
                MakeCalendarEntry(od);
            }
            CalendarMonthUI.DrawDays();

        }

        #region Helper Methods
        private void MakeCalendarEntry(OffDay od)
        {
            try
            {
                DateTime? from = null;
                DateTime? to = null;
                if(od.typ == 0) // exact
                {
                    from = DateTime.ParseExact(od.start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    to = DateTime.ParseExact(od.end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    if (from != null && to != null)
                    {
                        Events.Add(new CalendarEntry() { DateFrom = from, DateTo = to, Label = GetLabel(od), typ = 1 });
                    }
                }
                else if(od.typ == 1) //entire day
                {
                    string sfrom = od.start.Split(' ').First() + " 00:00:00";
                    string sto = od.end.Split(' ').First() + " 23:59:59";
                    from = DateTime.ParseExact(od.start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    to = DateTime.ParseExact(od.end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    if (from != null && to != null)
                    {
                        Events.Add(new CalendarEntry() { DateFrom = from, DateTo = to, Label = GetLabel(od), typ = 1 });
                    }
                }
                else if (od.typ == 2) //weekly
                {
                    for (int i = 0; i < 24; i++)
                    {
                        from = DateTime.ParseExact(od.start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddDays(7*i);
                        to = DateTime.ParseExact(od.end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddDays(7 * i);
                        if (from != null && to != null)
                        {
                            Events.Add(new CalendarEntry() { DateFrom = from, DateTo = to, Label = GetLabel(od), typ = 1 });
                        }
                    }
                }
                else if (od.typ == 3) // every second week
                {
                    for (int i = 0; i < 12; i++)
                    {
                        from = DateTime.ParseExact(od.start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddDays(14 * i);
                        to = DateTime.ParseExact(od.end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddDays(14 * i);
                        if (from != null && to != null)
                        {
                            Events.Add(new CalendarEntry() { DateFrom = from, DateTo = to, Label = GetLabel(od), typ = 1 });
                        }
                    }
                }
                else if (od.typ == 4) // monthly
                {
                    for (int i = 0; i < 6; i++)
                    {
                        from = DateTime.ParseExact(od.start, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddMonths(i);
                        to = DateTime.ParseExact(od.end, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).AddMonths(i);
                        if (from != null && to != null)
                        {
                            Events.Add(new CalendarEntry() { DateFrom = from, DateTo = to, Label = GetLabel(od), typ = 1 });
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {
                Notify.sendError("Error", ex.Message);
            }

        }

        private string GetLabel(OffDay od)
        {
            return Globals.UserIdToName(od.user_id.GetValueOrDefault()) + ": " + od.title;
        }
        #endregion
    }
}
