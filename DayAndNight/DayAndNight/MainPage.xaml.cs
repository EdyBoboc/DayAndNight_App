using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace DayAndNight
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
            for(int i = 1; i <= 5; i++)
            {
                PancakeView pancake = new PancakeView();
                pancake.CornerRadius = 10;

                Grid camera = new Grid{ BackgroundColor = Color.Aqua, HeightRequest = 100, WidthRequest = 140 };
                camera.Children.Add(new Image {
                    Source = i < 4 ? $"Zona{i}" : $"Zona{i - 2}",
                    Aspect = Aspect.AspectFill });

                Frame chenar_textCamera = new Frame {
                    BackgroundColor = Color.FromHex("#ffa418"),
                    HasShadow = false,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = 2,
                    Padding = new Thickness(8, 2),
                    CornerRadius = 10
                };

                chenar_textCamera.Content = new Label { Text = "Zona " + i, TextColor = Color.White };

                camera.Children.Add(chenar_textCamera);
                pancake.Content = camera;
                carusel.Children.Add(pancake);
            }
        }
    }
}
