using DayAndNight.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
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
            AdaugareDispozitiv,
            AdaugareCamera,
            SchimbareNightMode
        }; readonly Actiuni_PozaProfil actiune;

        //Programatic
        int nrDispozitive = 1, nrCamere = 1;
        bool nightmode = false;
        BackgroundWorker bw = new BackgroundWorker();
        BackgroundWorker bwAdaugareCamera = new BackgroundWorker();

        public MainPage()
        {
            InitializeComponent();

            //Setare actiune pe poza de profil
            //actiune = Actiuni_PozaProfil.AdaugareDispozitiv;

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

                chenar_textCamera.Content = new Label { Text = "Zona " + nrDispozitive, TextColor = Color.White };

                camera.Children.Add(chenar_textCamera);
                pancake.Content = camera;
                carusel.Children.Add(pancake);

                lblListaDispozitive.Text = "Dispozitive";
                nrDispozitive++;
            };


            bwAdaugareCamera.DoWork += delegate { Thread.Sleep(1300); };
            bwAdaugareCamera.RunWorkerCompleted += delegate
            {

                StackLayout camera = new StackLayout{ Orientation = StackOrientation.Vertical };

                BoxView linie = new BoxView
                {
                    BackgroundColor = Color.White,
                    HeightRequest = 2,
                    WidthRequest = 130
                };

                Label lblDenumireCamera = new Label
                {
                    Margin = new Thickness(10, 0, 0, 0),
                    TextColor = Color.White,
                    FontSize = 18,
                    FontFamily = "TextSemiBold",
                    Text = "Camera " + nrCamere
                };

                Label lblNrDispozitiveCamera = new Label
                {
                    Margin = new Thickness(10, -10, 0, 0),
                    TextColor = Color.FromHex("#95a8b6"),
                    FontSize = 12,
                    FontFamily = "TextLight",
                    Text = $"{new Random().Next(2, 6)} dispozitive"
                };

                camera.Children.Add(linie);
                camera.Children.Add(lblDenumireCamera);
                camera.Children.Add(lblNrDispozitiveCamera);

                chenarCamere.Children.Add(camera);

                lblListaCamere.Text = "Camere";
                nrCamere++;
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

        private void AdaugareCamera(object sender, EventArgs e)
        {
            if(nrCamere <= 10)
            {
                lblListaCamere.Text = "Adăugare cameră...";
                if(!bwAdaugareCamera.IsBusy)
                    bwAdaugareCamera.RunWorkerAsync();
            }
        }

        private void AdaugareDispozitiv(object sender, EventArgs e)
        {
            if(nrDispozitive <= 10)
            {
                lblListaDispozitive.Text = "Încărcare dispozitiv...";
                if(!bw.IsBusy)
                    bw.RunWorkerAsync();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(!nightmode)
            {
                lblListaDispozitive.TextColor = Color.Red;
                nightmode = true;
            }
            else
            {
                lblListaDispozitive.TextColor = Color.FromHex("#213654");
                nightmode = false;
            }

            /*switch(actiune)
            {
                case Actiuni_PozaProfil.Nimic:
                    break;

                *//* Adaugare dispozitive *//*
                case Actiuni_PozaProfil.AdaugareDispozitiv:
                    *//*if(nrDispozitive <= 10)
                    {
                        lblListaDispozitive.Text = "Încărcare dispozitiv...";
                        if(!bw.IsBusy)
                            bw.RunWorkerAsync();
                    }*//* break;

                *//* Adaugare camera *//*
                case Actiuni_PozaProfil.AdaugareCamera:
                    *//*if(nrCamere <= 10)
                    {
                        lblListaCamere.Text = "Adăugare cameră...";
                        if(!bwAdaugareCamera.IsBusy)
                            bwAdaugareCamera.RunWorkerAsync();
                    }*//* break;

                *//* Interschimbare interfata *//*
                case Actiuni_PozaProfil.SchimbareNightMode:
                    if(!nightmode)
                    {
                        lblListaDispozitive.TextColor = Color.Red;
                        nightmode = true;
                    }
                    else
                    {
                        lblListaDispozitive.TextColor = Color.FromHex("#213654");
                        nightmode = false;
                    } break;
                default:
                    break;
            }*/
        }
    }
}
