﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFAdvThemeing.Models;
using XFAdvThemeing.Themes;

namespace XFAdvThemeing.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSelectionPage : ContentPage
    {
        public ThemeSelectionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries.Count > 0)
            {
                var currentTheme = mergedDictionaries.First().GetType();

                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(LightTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 0;
                    statusLabel.Text = $"{Theme.Light.ToString()} theme loaded. Close this page.";
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(DarkTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 1;
                    statusLabel.Text = $"{Theme.Dark.ToString()} theme loaded. Close this page.";
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(PinkTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 2;
                    statusLabel.Text = $"{Theme.Pink.ToString()} theme loaded. Close this page.";
                }
                else
                if (currentTheme.FullName != null && currentTheme.FullName.Equals(typeof(GoldTheme).FullName))
                {
                    ThemePicker.SelectedIndex = 3;
                    statusLabel.Text = $"{Theme.Gold.ToString()} theme loaded. Close this page.";
                }
            }
        }

        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            Theme selectedTheme = (Theme)picker.SelectedItem;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (selectedTheme)
                {
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;

                    case Theme.Light:
                        mergedDictionaries.Add(new LightTheme());
                        break;

                    case Theme.Pink:
                        mergedDictionaries.Add(new PinkTheme());
                        break;

                    case Theme.Gold:
                        mergedDictionaries.Add(new GoldTheme());
                        break;

                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
                statusLabel.Text = $"{selectedTheme.ToString()} theme loaded. Close this page.";
            }
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}