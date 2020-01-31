﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_LayoutXF {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.LightBlue };
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
