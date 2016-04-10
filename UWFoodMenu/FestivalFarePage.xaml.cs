using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWFoodMenu
{
    public sealed partial class FestivalFarePage : Page
    {
        public FestivalFarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateMap();
            if (e.Parameter != null)
            {
                (e.Parameter as RadioButton).IsChecked = true;
            }
        }

        private void CreateMap()
        {
            MapControlFestivalFare.MapServiceToken = App.BingMapsApiKey;
            MapControlFestivalFare.Center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = 43.469222,
                    Longitude = -80.54036
                });

            MapIcon MapIconFestivalFare = new MapIcon();
            MapIconFestivalFare.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 43.469222,
                Longitude = -80.54036
            });
            MapIconFestivalFare.NormalizedAnchorPoint = new Point(0.5, 1.0);
            MapIconFestivalFare.Title = "Festival Fare";
            MapControlFestivalFare.MapElements.Add(MapIconFestivalFare);
        }
    }
}
