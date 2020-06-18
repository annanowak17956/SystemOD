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
    public partial class klient : ContentPage
    {
        FirebaseHelper SystemOD = new FirebaseHelper();
        string h;
        string f;
        public klient()
        {
            InitializeComponent();
            picker();
            

            picc.SelectedIndexChanged += (sender, args) => {
                h = picc.Items[picc.SelectedIndex];

            };

           

        }
        async void ce(object sender, EventArgs e)
        {
            var lista = new List<pobieranie>();
            popup3.IsVisible = true;
            var c = await SystemOD.GetPlace();
            foreach (var n in c)
            {
                lista.Add(n);
            }


            ListViewResult2.ItemsSource = lista;


        }
        async void dz(object sender, EventArgs e)
        {
            popup.IsVisible = true;
            

        }
        async void wyj(object sender, EventArgs e)
        {
            popup.IsVisible = false;


        }
        async void strona(object sender, EventArgs e)
        {
            popup2.IsVisible = false;


        }
        async void hz(object sender, EventArgs e)
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
        async void zat2(object sender, EventArgs e)
        {
            var b = new pobieranie2 { Ilosc = il.Text };
            await SystemOD.Addzam2( h, b.Ilosc); 
            await DisplayAlert("", "Czy na pewno chcesz kupić ten produkt?", "TAK");
            await DisplayAlert("", "Zamówienie zostało złożone", "OK");
        }

        public klient(FirebaseHelper systemOD, string h, string f, ContentView popup, Picker picc, Entry il, ContentView popup2, ListView listViewResult, ContentView popup3, ListView listViewResult2)
        {
            SystemOD = systemOD;
            this.h = h;
            this.f = f;
            this.popup = popup;
            this.picc = picc;
            this.il = il;
            this.popup2 = popup2;
            ListViewResult = listViewResult;
            this.popup3 = popup3;
            ListViewResult2 = listViewResult2;
        }

        async void sk(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new klient());
        }
        async void picker()
        {
            
            var c = await SystemOD.GetPlace( );
            var w = c.Where(z => z.Nazwa == z.Nazwa);
            foreach (var n in c)
            {
                picc.Items.Add(n.Nazwa);


            }

        }

       
    }
}