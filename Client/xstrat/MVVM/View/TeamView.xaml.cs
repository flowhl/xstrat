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
using xstrat.Core;
using xstrat.Json;
using xstrat.Theme;

namespace xstrat.MVVM.View
{
    /// <summary>
    /// Interaction logic for TeamView.xaml
    /// </summary>
    public partial class TeamView : UserControl
    {
        public TeamView()
        {
            InitializeComponent();
            TeamDashboard.Visibility = Visibility.Visible;
            TDashboard.Loaded += TDashboard_Loaded;
            JoinCreatePanel.Visibility = Visibility.Collapsed;
        }

        private void TDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            WaitForAPIAsync();
        }

        public async Task WaitForAPIAsync()
        {
            await Task.Delay(500);
            if (TDashboard.TeamInfo != null && TDashboard.TeamInfo.team_name != null && TDashboard.TeamInfo.team_name != "" && TDashboard.TeamInfo.team_name != "Create or join a team")
            {
                JoinCreatePanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                JoinCreatePanel.Visibility = Visibility.Visible;
            }
        }

        private async void JoinBtn_ClickAsync()
        {
            string id = team_id.Text;
            string pw = password.Text;
            (bool, string) result = await ApiHandler.JoinTeam(id, pw);
            if (result.Item1)
            {
                Notify.sendSuccess("Success", "Joint successfully");
                TDashboard.Retrieve();
                WaitForAPIAsync();
            }
            else
            {
                Notify.sendError("Error", result.Item2);
            }
        }

        private async void CreateBtn_ClickAsync()
        {
            string name = team_name.Text.ToString();
            if(GameSelector.selectedGame != null)
            {
                int game_id = GameSelector.selectedGame.id;

                var result = await ApiHandler.NewTeam(name, game_id);
                if (result.Item1)
                {
                    Notify.sendSuccess("Success", "Created successfully");
                    TDashboard.Retrieve();
                    await WaitForAPIAsync();
                }
                else
                {
                    Notify.sendError("Error", result.Item2);
                }
            }
            else
            {
                Notify.sendWarn("Warning" , "Select a game first");
            }

        }

        private void JoinBtn_Click(object sender, RoutedEventArgs e)
        {
            JoinBtn_ClickAsync();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateBtn_ClickAsync();
        }

        private void NewOffDay_Click(object sender, RoutedEventArgs e)
        {
            var od = new OffdayControl();
            od.Width = 700;
            od.LoadOffDay(new OffDay(0,0,"2022-01-01",1,"Offday Flo","2022-04-14 12:35:00", "2022-04-14 19:23:00"));
            OffDaysList.Children.Add(od);
        }
    }
}
