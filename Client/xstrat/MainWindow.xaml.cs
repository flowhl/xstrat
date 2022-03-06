using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using xstrat.MVVM.View;
using xstrat.Core;
using xstrat.MVVM.ViewModel;
using System;

namespace xstrat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mv;
        public MainWindow()
        {
            InitializeComponent();
            mv = (MainViewModel)DataContext;
            SettingsHandler.Initialize();
            ApiHandler.Initialize();
            Task loginTask = LoginWindowAsync();
        }

        /// <summary>
        /// drag window around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// minimize button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// show login window
        /// </summary>
        /// <returns></returns>
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
            mv.CurrentView = new LoginView();
            //mv.showLogin();
        }

        /// <summary>
        /// show register window
        /// </summary>
        public void Register()
        {
            mv.CurrentView = new RegisterView();
        }

        public void LoginComplete(string token)
        {
            if (SettingsHandler.StayLoggedin)
            {
                SettingsHandler.token = token;
                SettingsHandler.Save();
            }
            ApiHandler.AddBearer(token);
            mv.CurrentView = new HomeView();
        }
        public void RegisterComplete()
        {
            mv.CurrentView = new LoginView();
        }
        
    }
}
