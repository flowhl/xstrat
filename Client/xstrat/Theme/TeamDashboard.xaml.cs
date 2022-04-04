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
using System.Windows.Navigation;
using System.Windows.Shapes;
using xstrat.Core;
using xstrat.Json;

namespace xstrat.Theme
{
    /// <summary>
    /// Interaction logic for TeamDashboard.xaml
    /// </summary>
    public partial class TeamDashboard : UserControl
    {
        public List<User> teammates { get; set; } = new List<User>();
        public teamInfo TeamInfo { get; set; }
        public TeamDashboard()
        {
            InitializeComponent();
            RetrieveTeamMates();
            RetrieveTeamInfoAsync();
        }

        private void LeaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void JoinPWAdminBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RenameAdminBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAdminBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void RetrieveTeamMates()
        {
            var result = await ApiHandler.TeamMembers();
            if (result.Item1)
            {
                string response = result.Item2;
                //convert to json instance
                JObject json = JObject.Parse(response);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    List<xstrat.Json.User> rList = JsonConvert.DeserializeObject<List<Json.User>>(data);
                    teammates.Clear();
                    teammates = rList;
                }
                else
                {
                    Notify.sendError("Error", "Teammates could not be loaded");
                    throw new Exception("Teammates could not be loaded");
                }
                MemberSP.Children.Clear();
                foreach (var user in teammates)
                {
                    var newItem = new Teammate(user.name, user.id, user.color);
                    newItem.Height = 30;
                    newItem.Width = 250;
                    MemberSP.Children.Add(newItem);
                }
            }
            else
            {
                Notify.sendError("Error", "Teammates could not be loaded");
                throw new Exception("Teammates could not be loaded");

            }
        }
        private async Task RetrieveTeamInfoAsync()
        {
            var result = await ApiHandler.TeamInfo();
            if (result.Item1)
            {
                string response = result.Item2;
                //convert to json instance
                JObject json = JObject.Parse(response);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    TeamInfo = JsonConvert.DeserializeObject<List<teamInfo>>(data).First();
                }
                else
                {
                    Notify.sendError("Error", "Teammates could not be loaded");
                    throw new Exception("Teammates could not be loaded");
                }
                if (TeamInfo != null)
                {
                    TeamName.Content = TeamInfo.team_name;
                    AdminName.Content = "Admin: " +TeamInfo.admin_name;
                    GameName.Content = "Game: "+TeamInfo.game_name;
                }
            }
            else
            {
                Notify.sendError("Error", "Teammates could not be loaded");
                throw new Exception("Teammates could not be loaded");
            }
        }

    }
}
