﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilMedia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Movil.Page1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
