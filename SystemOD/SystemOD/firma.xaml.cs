using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SystemOD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class firma : ContentPage
    {
        FirebaseHelper SystemOD = new FirebaseHelper();
        public firma()
        {
            InitializeComponent();
        }
        void Dpi(object sender, EventArgs e)
        {
            popup.IsVisible = true;


        }
        void Wyj2(object sender, EventArgs e)
        {
            popup.IsVisible = false;


        }
        async void wz(object sender, EventArgs e)
        {
            var lista = new List<pobieranie2>();
            popup2.IsVisible = true;
            var c = await SystemOD.GetPlace2();
            foreach (var n in c)
            {
                lista.Add(n);
            }

            ListViewResult.ItemsSource = lista;

        }

        

        async void zat(object sender, EventArgs e)
        {
            var b = new pobieranie { Nazwa = Naz.Text , Cena = Cen.Text };
            await SystemOD.Addzam(b.Nazwa , b.Cena);
            await DisplayAlert("", "produkt dodany", "OK");
        }

        async void sf(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new firma());
        }
    }
}