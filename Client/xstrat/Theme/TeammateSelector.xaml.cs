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
    /// Interaction logic for TeammateSelector.xaml
    /// </summary>
    public partial class TeammateSelector : UserControl
    {
        public List<User> teammates { get; set; } = new List<User>();
        public User selectedUser { get; set; } = null;
        public TeammateSelector()
        {
            InitializeComponent();
            RetrieveTeamMates();
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

        private void UpdateUI()
        {
            CBox.Items.Clear();
            foreach (var item in teammates)
            {
                CBox.Items.Add(item.name);
            }
        }


        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = teammates[CBox.SelectedIndex];
        }
    }
}
