using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

namespace UWFoodMenu
{
    public sealed partial class Shell : Page
    {
        public WeeklyFoodMenu menu;

        public Shell()
        {
            this.InitializeComponent();
        }

        public Shell(Frame frame, WeeklyFoodMenu menu)
        {
            this.InitializeComponent();
            this.menu = menu;
            this.SplitViewMain.Content = frame;
            (SplitViewMain.Content as Frame).Navigate(typeof(MainPage), AllLocationsRadioButton);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = !SplitViewMain.IsPaneOpen;
        }

        private void menuButtonLocations_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = false;
            if (SplitViewMain.Content != null)
            {
                (SplitViewMain.Content as Frame).Navigate(typeof(MainPage), AllLocationsRadioButton);
            }
        }

        private void menuButtonFestivalFare_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = false;
            (SplitViewMain.Content as Frame).Navigate(typeof(FestivalFarePage), FestivalFareRadioButton);
        }

        private void menuButtonMudies_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = false;
            (SplitViewMain.Content as Frame).Navigate(typeof(MudiesPage), MudiesRadioButton);
        }

        private void menuButtonPastryPlus_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = false;
            (SplitViewMain.Content as Frame).Navigate(typeof(PastryPlusPage), PastryPlusRadioButton);
        }

        private void menuButtonRevelation_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMain.IsPaneOpen = false;
            (SplitViewMain.Content as Frame).Navigate(typeof(RevelationPage), RevelationRadioButton);
        }
    }
}
