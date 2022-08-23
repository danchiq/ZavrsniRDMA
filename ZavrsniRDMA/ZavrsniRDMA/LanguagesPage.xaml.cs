using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZavrsniRDMA.Model;


namespace ZavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagesPage : ContentPage
    {
        public static string[] Languages = new[]{
            "Croatian",
            "Slovenian",
            "English",
            "French",
            "German"
            };
        public LanguagesPage()
        {
            InitializeComponent();
        }


    }
}