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
    public partial class Logowanie : ContentPage
    {
        FirebaseHelper SystemOD = new FirebaseHelper();
        public Logowanie()
        {
            InitializeComponent();
        }

        private void logo(object sender, EventArgs e) => popup2.IsVisible = true;
        void Wy1(object sender, EventArgs e)
        {
            popup2.IsVisible = false;
        }

        async void rej(object sender, EventArgs e)
        {
            popup.IsVisible = true;
        }
        async void wy(object sender, EventArgs e)
        {
            popup.IsVisible = false;
        }
        async void rejestracja(object sender, EventArgs e)
        {
            var b = new logowanie { email = email.Text, hasło = hasło.Text, Ulica = Ulica.Text, Nrdomu = Nrdomu.Text, Kod = Kod.Text, Poczta = Poczta.Text};

            var baz = await SystemOD.GetPlace1();

            var k = baz.Where(z => z.email == b.email);


            foreach (var p in k)
            {
                if (b.email == p.email)
                {
                    autoryzac.Text = "Sprawdź poprawność danych";
                    return;
                }

                else if (b.email != p.email)

                {
                    await SystemOD.Addlogo(b.email, b.hasło);
                    await DisplayAlert("", "Rejestracja przebiegła pomyślnie", "OK");
                }
            }


            var c = gdypopr(b);
            if (c)
            {
                await SystemOD.Addlogo(b.email, b.hasło);
                await DisplayAlert("", "Rejestracja przebiegła pomyślnie", "OK");
            }
            else
            {
                autoryzac.Text = "BŁĄD REJESTRACJI";
            }

            

        }


        async void log(object sender, EventArgs e)
        {


            var a = new logowanie { email = Email.Text, hasło = Hasło.Text };

            var baz = await SystemOD.GetPlace1();

            var k = baz.Where(z => z.email == a.email);



            foreach (var p in k)
            {
                if (a.email == p.email && a.hasło == p.hasło)
                {
                    await Navigation.PushAsync(new MainPage());

                    return;
                }

                else
                {



                }
            }
        }

            bool gdypopr(logowanie b)
        {
            return !string.IsNullOrWhiteSpace(b.email) && b.email.Contains("@") && !string.IsNullOrWhiteSpace(b.hasło);
        }


    }
}