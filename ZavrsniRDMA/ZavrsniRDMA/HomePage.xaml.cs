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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void NavigateToUsersPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersPage());
        }
        private void NavigateToResultsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultsPage());
        }
        private void NavigateToLanguagesPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LanguagesPage());
        }
        private void OnProfile_Tap(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
        private void LogoutTap(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }

}