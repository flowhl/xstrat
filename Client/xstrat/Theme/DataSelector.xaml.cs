using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TeammateSelector.xaml
    /// </summary>
    public partial class DataSelector : UserControl
    {  
        public List<User> teammates { get; set; } = new List<User>();
        public User selectedUser { get; set; } = null;
        public List<Game> games { get; set; } = new List<Game>();
        public Game selectedGame { get; set; } = null;
        public List<OffDayType> OffDayTypes = new List<OffDayType>();
        public OffDayType selectedOffDayType = null; 
        public int type { get; set; } = 0;



        /// <summary>
        /// type:
        /// 1 - teammates
        /// 2 - game
        /// 3 - offdaytype
        /// </summary>
        /// <param name="type"></param>
        public DataSelector()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                if (type == 1)
                {
                    RetrieveTeamMates();
                }
                else if (type == 2)
                {
                    RetrieveGames();
                }
                else if (type == 3)
                {
                    RetrieveOffDayTypes();
                }
                UpdateUI();
            };

        }
        private async void RetrieveTeamMates()
        {
            var result = await ApiHandler.TeamMembers();
            if (result.Item1)
            {
                string resultJson = result.Item2;
                string response = result.Item2;
                //convert to json instance
                JObject json = JObject.Parse(response);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    List<xstrat.Json.User> rList = JsonConvert.DeserializeObject<List<Json.User>>(data);
                    selectedUser = null;
                    teammates.Clear();
                    teammates = rList;
                }
                else
                {
                    Notify.sendError("Error", "Teammates could not be loaded");
                    throw new Exception("Teammates could not be loaded");
                }
                UpdateUI();
            }
            else
            {
                Notify.sendError("Error", "Teammates could not be loaded");
                throw new Exception("Teammates could not be loaded");
            }
        }

        private async void RetrieveGames()
        {
            var result = await ApiHandler.Games();
            if (result.Item1)
            {
                string resultJson = result.Item2;
                string response = result.Item2;
                //convert to json instance
                JObject json = JObject.Parse(response);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    List<xstrat.Json.Game> rList = JsonConvert.DeserializeObject<List<Json.Game>>(data);
                    selectedGame = null;
                    games.Clear();
                    games = rList;
                }
                else
                {
                    Notify.sendError("Error", "Games could not be loaded");
                    throw new Exception("Games could not be loaded");
                }
                UpdateUI();
            }
            else
            {
                Notify.sendError("Error", "Games could not be loaded");
                throw new Exception("Games could not be loaded");
            }
        }

        private void RetrieveOffDayTypes()
        {
            OffDayTypes.Add(new OffDayType(0, "exactly"));
            OffDayTypes.Add(new OffDayType(1, "entire day"));
            OffDayTypes.Add(new OffDayType(2, "weekly"));
            OffDayTypes.Add(new OffDayType(3, "every second week"));
            OffDayTypes.Add(new OffDayType(4, "monthly"));
        }

        private void UpdateUI()
        {
            if(type == 1)
            {
                CBox.Items.Clear();
                foreach (var item in teammates)
                {
                    CBox.Items.Add(item.name);
                }
            }
            else if (type == 2)
            {
                CBox.Items.Clear();
                foreach (var item in games)
                {
                    CBox.Items.Add(item.name);
                }
            }
            else if(type == 3)
            {
                CBox.Items.Clear();
                foreach (var item in OffDayTypes)
                {
                    CBox.Items.Add(item.name);
                }

            }
        }


        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(type == 1)
            {
                selectedUser = teammates[CBox.SelectedIndex];
            }
            else if(type == 2)
            {
                selectedGame = games[CBox.SelectedIndex];
            }
            else if(type == 3)
            {
                selectedOffDayType = OffDayTypes[CBox.SelectedIndex];
            }
        }
    }
}
