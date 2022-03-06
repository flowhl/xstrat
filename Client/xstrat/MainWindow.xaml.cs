using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using xstrat.MVVM.View;
using xstrat.Core;
using System;

namespace xstrat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object oldview;
        public MainWindow()
        {
            InitializeComponent();
            SettingsHandler.Initialize();
            ApiHandler.Initialize();
            await LoginWindowAsync();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async Task LoginWindowAsync()
        {
            if(SettingsHandler.StayLoggedin == true && SettingsHandler.token != null && SettingsHandler.token != "")
            {
                bool verified = await ApiHandler.VerifyToken(SettingsHandler.token);
                if(verified)
                {
                    return;
                }
            }
            oldview = contentControl.Content;
            contentControl.Content = new LoginView();
        }

        public void Register()
        {
            contentControl.Content = new RegisterView();
        }

        public void LoginComplete(string token)
        {
            if (SettingsHandler.StayLoggedin)
            {
                SettingsHandler.token = token;
                SettingsHandler.Save();
            }
            ApiHandler.AddBearer(token);
            contentControl.Content = oldview;
        }
        public void RegisterComplete()
        {
            contentControl.Content = new LoginView();
        }
        
    }
}
