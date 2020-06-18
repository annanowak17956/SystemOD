using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOD

{
    public partial class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://systemod-an17956-f643c.firebaseio.com/");

        public async Task<List<pobieranie>> GetPlace()
        {
            return (await firebase
              .Child("zamow")
              .OnceAsync<pobieranie>()).Select(item => new pobieranie
              {
                  Nazwa = item.Object.Nazwa,
                  Cena = item.Object.Cena,
              }).ToList();
        }

        public async Task<List<pobieranie2>> GetPlace2()
        {
            return (await firebase
              .Child("zamow2")
              .OnceAsync<pobieranie2>()).Select(item => new pobieranie2
              {
                  Nazwa = item.Object.Nazwa,
                  Ilosc = item.Object.Ilosc,
              }).ToList();
        }
        public async Task<List<logowanie>> GetPlace1()
        {
            return (await firebase
              .Child("logowanie")
              .OnceAsync<logowanie>()).Select(item => new logowanie
              {
                  email = item.Object.email,
                  hasło = item.Object.hasło,
                  
                  
                 
              }).ToList();
        }

        public async Task Addlogo(string email , string hasło)
        {

            await firebase
              .Child("logowanie")
              .PostAsync(new logowanie()
              {
                  email = email,
                  hasło = hasło,

              });
        }
        public async Task Addzam(string nazwa, string cena)
        {

            await firebase
              .Child("zamow")
              .PostAsync(new pobieranie()
              {
                  Nazwa = nazwa,
                  Cena = cena,

              });
        }

        public async Task Addzam2(string nazwa, string ilosc)
        {

            await firebase
              .Child("zamow2")
              .PostAsync(new pobieranie2()
              {
                  Nazwa = nazwa,
                  Ilosc = ilosc,

              });
        }


        public async Task DeleteDziennik()
        {
            await firebase
                .Child("zamow")
                .DeleteAsync();
        }
    }








}
