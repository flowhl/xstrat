using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using xstrat.Core;

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
            if(SettingsHandler.APIURL != null)
            {
                APIText.Text = SettingsHandler.APIURL;
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
        }
    }
}
