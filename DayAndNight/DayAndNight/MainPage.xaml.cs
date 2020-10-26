using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DayAndNight
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            int i = 1;
            bool deschis = false;
            btnClick.Clicked += async delegate
            {
                if(!deschis)
                {
                    await Flashlight.TurnOnAsync();
                    deschis = true;
                }
                else
                {
                    await Flashlight.TurnOffAsync();
                    deschis = false;
                }
                lblLink.Text = $"Buton apăsat de: {i} ori";
                i++;
            };
        }
    }
}
