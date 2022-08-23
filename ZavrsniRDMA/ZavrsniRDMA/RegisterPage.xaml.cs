using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        AuthHelper authHelper;
        public RegisterPage()
        {
            InitializeComponent();
            authHelper = DependencyService.Get<AuthHelper>();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var user = authHelper.SignUpWithEmailAndPassword(inputEmail.Text, inputPass.Text);

            if (user != null)
            {
                await DisplayAlert("Success", "New User Created", "OK");

                var signOut = authHelper.SignOut();
                if (signOut)
                {
                    Application.Current.MainPage = new NavigationPage(new HomePage());
                }

            }
            else
            {
                await DisplayAlert("Error", "Something went wrong", "OK");
            }

        }
    }
}