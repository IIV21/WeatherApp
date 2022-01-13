using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MainPageViewModel();
        }

      /*  private void CLButton_Clicked(object sender, EventArgs e)
        {
            CurrentLocationLabel.IsVisible = true;
        }

        private void RLButton_Clicked(object sender, EventArgs e)
        {
            CurrentLocationLabel.IsVisible = false;
        }

        private void GBWButton_Clicked(object sender, EventArgs e)
        {
            CurrentLocationLabel.Text = "Bucharest Weather:";
            CurrentLocationLabel.IsVisible = true;
        }*/
    }
}
