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
    public partial class ProfilePage : ContentPage
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        

        public ProfilePage()
        {
            BindingContext = this;
            Email = ProfilePageExtensions.email;
            Name = ProfilePageExtensions.name;
            InitializeComponent();

        }
    }
    public static class ProfilePageExtensions
        {
            public static string email { get; private set; }
            public static string name { get; private set; }
        }
}