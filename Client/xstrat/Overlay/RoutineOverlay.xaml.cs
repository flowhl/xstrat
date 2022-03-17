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
using System.Windows.Shapes;

namespace xstrat.Overlay
{
    /// <summary>
    /// Interaction logic for RoutineOverlay.xaml
    /// </summary>
    public partial class RoutineOverlay : Window
    {
        OverlayStep currentStep;
        List<OverlayStep> steps;
        bool isFinished = false;
        public RoutineOverlay(string titleText)
        {
            InitializeComponent();
            Extender.IsExpanded = true;
            var topLeftCornerOfMainWindow = new System.Drawing.Point((int)System.Windows.Application.Current.MainWindow.Left, (int)System.Windows.Application.Current.MainWindow.Top);
            var currentScreen = System.Windows.Forms.Screen.FromPoint(topLeftCornerOfMainWindow);

            this.Top = currentScreen.WorkingArea.Top;
            this.Left = currentScreen.WorkingArea.Left;
            TitleText.Content = titleText;
        }

        public void Initialize(List<OverlayStep> overlaySteps)
        {
            Sp.Children.Clear();
            steps = overlaySteps;
            foreach (var item in overlaySteps)
            {
                Sp.Children.Add(item);
            }
            UpdateLoop();
        }

        private async void UpdateLoop()
        {
            while (!isFinished)
            {
                foreach (var step in steps)
                {
                    if (step.IsSelected)
                    {
                        if (step.isFinished)
                        {
                            int i = steps.IndexOf(step) + 1;
                            if (i < steps.Count - 1)
                            {
                                steps[i].IsSelected = true;
                                step.IsSelected = false;
                            }
                            else if (i == steps.Count - 1)
                            {
                                isFinished = true;
                            }
                        }
                        step.Update();
                    }
                }
                await Task.Delay(100);
            }            
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
