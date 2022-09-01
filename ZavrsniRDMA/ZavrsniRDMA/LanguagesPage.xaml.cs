using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZavrsniRDMA.Model;

namespace ZavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagesPage : ContentPage
    {
        bool Language = false;
        List<LanguageModel> modelList = new List<LanguageModel>();
        public LanguagesPage()
        {
            InitializeComponent();
            GetJsonAsync();
        }
        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=results");

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var msg = jsonObject["msg"];
                var data = jsonObject["data"];

                var jsonArray = JArray.Parse(data.ToString());

                foreach (var userObject in jsonArray)
                {
                    LanguageModel m = new LanguageModel();m.language = userObject["language"].ToString();
                    modelList.Add(m);
                }
            }
            list.ItemsSource = modelList;

        }
      


    }
}

     