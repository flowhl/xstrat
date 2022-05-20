using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using xstrat.Core;
using xstrat.Json;

namespace xstrat.MVVM.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            SkinSwitcherPathDisplay.Text = SettingsHandler.SkinSwitcherPath;
            RememberMeSettings.setStatus(SettingsHandler.StayLoggedin);
            RetrieveDiscordIDAsync();
            if(SettingsHandler.APIURL != null)
            {
                APIText.Text = SettingsHandler.APIURL;
            }
            if (!Globals.AdminUser)
            {
                WebhookView.Visibility = Visibility.Collapsed;
            }
            else
            {
                WebhookView.Visibility = Visibility.Visible;
                RetrieveDiscordWebhookAsync();
            }
        }


        private void SkinSwitcherPickPathBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\savegames";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var path = dialog.FileName;
                SettingsHandler.SkinSwitcherPath = path;
                SkinSwitcherPathDisplay.Text = path;
                SettingsHandler.Save();
            }
        }

        private void Save_BtnClick(object sender, RoutedEventArgs e)
        {
            SettingsHandler.StayLoggedin = RememberMeSettings.getStatus();
            SettingsHandler.APIURL = APIText.Text;
            SettingsHandler.Save();
            SaveDiscordIDAsync();
            if (Globals.AdminUser)
            {
                SaveDiscordWebhookAsync();
            }
        }

        private async Task RetrieveDiscordIDAsync()
        {
            var result = await ApiHandler.GetDiscordId();
            if (result.Item1)
            {
                JObject json = JObject.Parse(result.Item2);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    try
                    {
                        DiscordID discord = JsonConvert.DeserializeObject<List<DiscordID>>(data).First();
                        if(discord.discord != null && discord.discord != string.Empty)
                        {
                            DCId.Text = discord.discord;
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify.sendError( "No discord found!");
                        Logger.Log("No discord found! " + ex.Message);
                    }
                }
            }
            else
            {
                Notify.sendError(result.Item2);
            }
        }
        private async Task SaveDiscordIDAsync()
        {
            if(DCId.Text != null && DCId.Text != string.Empty && IsDigitsOnly(DCId.Text))
            {
                var result = await ApiHandler.SetDiscordId(DCId.Text);
                if (result.Item1)
                {
                    Notify.sendSuccess("Changed discord successfully");
                }
                else
                {
                    Notify.sendError(result.Item2);
                }
            }
            else
            {
                Notify.sendWarn("Discord ID cannot be empty and has to be digits only");
            }
        }

        private async Task RetrieveDiscordWebhookAsync()
        {
            var result = await ApiHandler.GetDiscordWebhook();
            if (result.Item1)
            {
                JObject json = JObject.Parse(result.Item2);
                var data = json.SelectToken("data").ToString();
                if (data != null && data != "")
                {
                    try
                    {
                        Webhook webhook = JsonConvert.DeserializeObject<List<Webhook>>(data).First();
                        if (webhook.webhook != null && webhook.webhook != string.Empty)
                        {
                            DCWebhook.Text = webhook.webhook;
                        }
                    }
                    catch (Exception ex)
                    {
                        Notify.sendError("No Discord Webhook found!");
                        Logger.Log("No Discord Webhook found! " + ex.Message);
                    }
                }
            }
            else
            {
                Notify.sendError(result.Item2);
            }
        }
        private async Task SaveDiscordWebhookAsync()
        {
            if (DCWebhook.Text != null && DCWebhook.Text != string.Empty)
            {
                var result = await ApiHandler.SetDiscordWebhook(DCWebhook.Text);
                if (result.Item1)
                {
                    Notify.sendSuccess("Changed Discord Webhook successfully");
                }
                else
                {
                    Notify.sendError(result.Item2);
                }
            }
            else
            {
                Notify.sendWarn("Discord Webhook cannot be empty");
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
