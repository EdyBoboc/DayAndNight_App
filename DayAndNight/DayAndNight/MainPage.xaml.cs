using DayAndNight.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace DayAndNight
{
    public partial class MainPage : ContentPage
    {
        //Cazuri la apasarea pozei de profil
        enum Actiuni_PozaProfil
        {
            Nimic,
            AdaugareCamere,
            SchimbareNightMode
        }; readonly Actiuni_PozaProfil actiune;

        //Programatic
        int apasat = 1;
        bool nightmode = false;
        BackgroundWorker bw = new BackgroundWorker();

        public MainPage()
        {
            InitializeComponent();

            //Setare actiune pe poza de profil
            actiune = Actiuni_PozaProfil.AdaugareCamere;

            //Programatic
            bw.DoWork += delegate { Thread.Sleep(1300); };
            bw.RunWorkerCompleted += delegate
            {
                PancakeView pancake = new PancakeView();
                pancake.CornerRadius = 10;

                Grid camera = new Grid{ BackgroundColor = Color.Aqua, HeightRequest = 100, WidthRequest = 140 };
                camera.Children.Add(new Image
                {
                    Source = $"Zona{new Random().Next(1, 4)}", //apasat < 4 ? $"Zona{apasat}" : $"Zona{apasat - 2}",
                    Aspect = Aspect.AspectFill
                });

                Frame chenar_textCamera = new Frame
                {
                    BackgroundColor = Color.FromHex("#ffa418"),
                    HasShadow = false,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = 2,
                    Padding = new Thickness(8, 2),
                    CornerRadius = 10
                };

                chenar_textCamera.Content = new Label { Text = "Zona " + apasat, TextColor = Color.White };

                camera.Children.Add(chenar_textCamera);
                pancake.Content = camera;
                carusel.Children.Add(pancake);

                lblCamere.Text = "Camere";
                apasat++;
            };

            //nimic
            /*for(int i = 1; i <= 5; i++)
            {
                *//*PancakeView pancake = new PancakeView();
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
                carusel.Children.Add(pancake);*//*
            }*/
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            switch(actiune)
            {
                case Actiuni_PozaProfil.Nimic:
                    break;
                case Actiuni_PozaProfil.AdaugareCamere:
                    if(apasat <= 10)
                    {
                        lblCamere.Text = "Încărcare cameră...";
                        if(!bw.IsBusy)
                            bw.RunWorkerAsync();
                    }
                    break;
                case Actiuni_PozaProfil.SchimbareNightMode:
                    if(!nightmode)
                    { 
                        lblCamere.TextColor = Color.Red;
                        nightmode = true;
                    }
                    else
                    {
                        lblCamere.TextColor = Color.FromHex("#213654");
                        nightmode = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
