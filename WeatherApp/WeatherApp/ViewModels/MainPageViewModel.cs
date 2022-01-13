using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        public Models.WeatherModel WeatherModel { get; set; }

        public string APIKey = "fc9788da7dff0e5c092a430488493567";

        public Models.Weather Weather { get; set; }
        public Models.Sys Sys { get; set; }
        
        public Models.Main Main { get; set; }

        public new ICommand RandomLocation { get; set; }

        public new ICommand CurrentLocation { get; set; }

        public new ICommand BucharestLocation { get; set; }

        public string Name { get; set; }

        public bool isVisible { get; set; }

        Random r = new Random();
        
     
        public MainPageViewModel()
        {
           
            Task.Run(async () =>
            {
                WeatherModel = await Services.APIComunication.GetWeatherAsync($"lat=35&lon=139&appid={APIKey}");
                Weather = WeatherModel.Weather[0];
                Sys = WeatherModel.Sys;
                Main = WeatherModel.Main;
                Name = WeatherModel.Name;

            }).Wait();

            RandomLocation = new Command(async () =>
            {
                isVisible = false;
                WeatherModel = await Services.APIComunication.GetWeatherAsync($"lat={r.Next(-90,90)}&lon={r.Next(-180,180)}&appid={APIKey}");
                Weather = WeatherModel.Weather[0];
                Sys = WeatherModel.Sys;
                Main = WeatherModel.Main;
                Name = WeatherModel.Name;
                OnPropertyChanged(nameof(WeatherModel));
                OnPropertyChanged(nameof(Weather));
                OnPropertyChanged(nameof(Sys));
                OnPropertyChanged(nameof(Main));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(isVisible));

            });
            BucharestLocation = new Command(async () =>
            {
                isVisible = false;
                WeatherModel = await Services.APIComunication.GetWeatherAsync($"lat={44}&lon={26}&appid={APIKey}");
                Weather = WeatherModel.Weather[0];
                Sys = WeatherModel.Sys;
                Main = WeatherModel.Main;
                Name = WeatherModel.Name;
                OnPropertyChanged(nameof(WeatherModel));
                OnPropertyChanged(nameof(Weather));
                OnPropertyChanged(nameof(Sys));
                OnPropertyChanged(nameof(Main));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(isVisible));

            });
            CurrentLocation = new Command(async () =>
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        isVisible = true;
                        WeatherModel = await Services.APIComunication.GetWeatherAsync($"lat={Convert.ToInt32(location.Latitude)}&lon={Convert.ToInt32(location.Longitude)}&appid={APIKey}");
                        Weather = WeatherModel.Weather[0];
                        Sys = WeatherModel.Sys;
                        Main = WeatherModel.Main;
                        Name = WeatherModel.Name;
                        OnPropertyChanged(nameof(WeatherModel));
                        OnPropertyChanged(nameof(Weather));
                        OnPropertyChanged(nameof(Sys));
                        OnPropertyChanged(nameof(Main));
                        OnPropertyChanged(nameof(Name));
                        OnPropertyChanged(nameof(isVisible));
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            });

        }
    }
}
