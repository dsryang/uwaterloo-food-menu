﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
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
    public sealed partial class RevelationPage : Page
    {
        public int REVELATION_ID = 7;

        public RevelationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            WeeklyFoodMenu menu = App.menu;
            CreateMap();
            if (menu.data != null)
            {
                CreateLunchMenu(menu);
                CreateDinnerMenu(menu);
            }
            if (e.Parameter != null)
            {
                (e.Parameter as RadioButton).IsChecked = true;
            }
        }

        private void CreateMap()
        {
            MapControlRevelation.MapServiceToken = App.BingMapsApiKey;
            MapControlRevelation.Center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = 43.470296,
                    Longitude = -80.554306
                });

            MapIcon MapIconRevelation = new MapIcon();
            MapIconRevelation.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 43.470296,
                Longitude = -80.554306
            });
            MapIconRevelation.NormalizedAnchorPoint = new Point(0.5, 1.0);
            MapIconRevelation.Title = "REVelation";
            MapControlRevelation.MapElements.Add(MapIconRevelation);
        }

        private void CreateLunchMenu(WeeklyFoodMenu menu)
        {
            List<Product> products = null;

            foreach (var outlet in menu.data.outlets)
            {
                if (outlet.outlet_id.Equals(REVELATION_ID))
                {
                    foreach (var outletMenu in outlet.menu)
                    {
                        if (outletMenu.day.Equals(DateTime.Now.ToString("dddd")))
                        {
                            products = outletMenu.meals.lunch;
                            for (int i = 0; i < products.Count; i++)
                            {
                                TextBlock productName = new TextBlock();
                                productName.FontSize = 16;
                                productName.FontWeight = FontWeights.Bold;
                                productName.TextWrapping = TextWrapping.WrapWholeWords;
                                productName.Margin = new Thickness(0, 10, 0, 0);
                                productName.Text = products[i].product_name;

                                TextBlock productDetails = new TextBlock();
                                productDetails.FontSize = 14;
                                productDetails.TextWrapping = TextWrapping.WrapWholeWords;
                                productDetails.Margin = new Thickness(5, 0, 0, 0);
                                if (products[i].diet_type != null)
                                {
                                    productDetails.Text = products[i].diet_type;
                                }
                                else
                                {
                                    productDetails.Visibility = Visibility.Collapsed;
                                }

                                StackPanelLunchProducts.Children.Add(productName);
                                StackPanelLunchProducts.Children.Add(productDetails);
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            if (products == null)
            {
                StackPanelLunchProducts.Visibility = Visibility.Collapsed;
                StackPanelLunchEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                StackPanelLunchProducts.Visibility = Visibility.Visible;
                StackPanelLunchEmpty.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateDinnerMenu(WeeklyFoodMenu menu)
        {
            List<Product> products = null;

            foreach (var outlet in menu.data.outlets)
            {
                if (outlet.outlet_id.Equals(REVELATION_ID))
                {
                    foreach (var outletMenu in outlet.menu)
                    {
                        if (outletMenu.day.Equals(DateTime.Now.ToString("dddd")))
                        {
                            products = outletMenu.meals.dinner;
                            for (int i = 0; i < products.Count; i++)
                            {
                                TextBlock productName = new TextBlock();
                                productName.FontSize = 16;
                                productName.FontWeight = FontWeights.Bold;
                                productName.TextWrapping = TextWrapping.WrapWholeWords;
                                productName.Margin = new Thickness(0, 10, 0, 0);
                                productName.Text = products[i].product_name;

                                TextBlock productDetails = new TextBlock();
                                productDetails.FontSize = 14;
                                productDetails.TextWrapping = TextWrapping.WrapWholeWords;
                                productDetails.Margin = new Thickness(5, 0, 0, 0);
                                if (products[i].diet_type != null)
                                {
                                    productDetails.Text = products[i].diet_type;
                                }
                                else
                                {
                                    productDetails.Visibility = Visibility.Collapsed;
                                }

                                StackPanelDinnerProducts.Children.Add(productName);
                                StackPanelDinnerProducts.Children.Add(productDetails);
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            if (products == null)
            {
                StackPanelDinnerProducts.Visibility = Visibility.Collapsed;
                StackPanelDinnerEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                StackPanelDinnerProducts.Visibility = Visibility.Visible;
                StackPanelDinnerEmpty.Visibility = Visibility.Collapsed;
            }
        }
    }
}
