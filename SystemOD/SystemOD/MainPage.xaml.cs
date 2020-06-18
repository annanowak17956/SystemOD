using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SystemOD
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        FirebaseHelper SystemOD = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }



        async void sk(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new klient());
        }

        async void sf(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new firma());
        }
    }
}
