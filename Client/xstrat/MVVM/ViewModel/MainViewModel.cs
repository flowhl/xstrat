using xstrat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xstrat.MVVM.View;

namespace xstrat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        MainWindow wnd = (MainWindow)Application.Current.MainWindow;
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; }
        public RelayCommand RegisterViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand SkinSwitcherViewCommand { get; set; }
        public RelayCommand RoutinesViewCommand { get; set; }
        public RelayCommand StratMakerViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public AboutViewModel AboutVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        public LoginViewModel LoginVM { get; set; }
        public SkinSwitcherViewModel SkinSwitcherVM { get; set; }
        public RoutinesViewModel RoutinesVM { get; set; }
        public StratMakerViewModel StratMakerVM { get; set; }
        public object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set {
                if (wnd.IsLoggedIn || value.GetType() == typeof(LoginView) || value.GetType() == typeof(RegisterView))
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SettingsVM = new SettingsViewModel();
            AboutVM = new AboutViewModel();
            LoginVM = new LoginViewModel();
            RegisterVM = new RegisterViewModel();
            SkinSwitcherVM = new SkinSwitcherViewModel();
            RoutinesVM = new RoutinesViewModel();
            StratMakerVM = new StratMakerViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {CurrentView = HomeVM;});
            SettingsViewCommand = new RelayCommand(o => { CurrentView = SettingsVM; });
            AboutViewCommand = new RelayCommand(o => { CurrentView = AboutVM; });
            RegisterViewCommand = new RelayCommand(o => { CurrentView = RegisterVM; });
            LoginViewCommand = new RelayCommand(o => { CurrentView = LoginVM; });
            SkinSwitcherViewCommand = new RelayCommand(o => { CurrentView = SkinSwitcherVM; });
            RoutinesViewCommand = new RelayCommand(o => { CurrentView = RoutinesVM; });
            StratMakerViewCommand = new RelayCommand(o => { CurrentView = StratMakerVM; });
        }
    }
}
