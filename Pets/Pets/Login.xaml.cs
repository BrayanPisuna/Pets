using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        string url;
        string secret;

        public Login(string url , string secret)
        {
            InitializeComponent();
            this.url = url;
            this.secret = secret;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {



            try
            {
                WebClient cliente = new WebClient();
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                Usuario user = new Usuario(lblUser.Text, lblPass.Text);

                string json = JsonConvert.SerializeObject(user);

                App.TOKEN = cliente.UploadString(this.url + "login", "POST", json);

                var mensaje = "Dato ingresado con exito";
                var validacion = Encoding.ASCII.GetBytes(secret);

                var handler = new JwtSecurityTokenHandler();

                var parametros = new TokenValidationParameters();

                

                DisplayAlert("ALERTA",parametros.ToString() , "OK");

                //DependencyService.Get<Mensaje>().longAlert(mensaje);

                Navigation.PushAsync(new Validacion());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ok", ex.Message, "OK");
                //DependencyService.Get<Mensaje>().longAlert(ex.Message);
            }



        }
    }
}