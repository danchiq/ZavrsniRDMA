using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZavrsniRDMA
{
    public partial class LoginPage : ContentPage
    {
        AuthHelper authHelper;
        public LoginPage()
        {
            InitializeComponent();
            authHelper = DependencyService.Get<AuthHelper>();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string token = await authHelper.LoginWithEmailAndPassword(userEntry.Text, passEntry.Text);
            if (token != string.Empty)
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("ERROR", "Auth Failed", "OK");
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
