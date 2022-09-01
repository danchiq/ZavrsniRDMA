using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZavrsniRDMA.Model;

namespace ZavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        bool Id = false;
        bool Email = false;
        bool Time = false;

        List<UserModel> modelList = new List<UserModel>();

        public UsersPage()
        {
            InitializeComponent();

            GetJsonAsync();
        }

        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");

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
                    UserModel u = new UserModel();

                    u.id_user = userObject["id_user"].ToString();
                    u.email = userObject["email"].ToString();
                    u.create_time = userObject["create_time"].ToString();

                    modelList.Add(u);
                }
            }

            users.ItemsSource = modelList;
        }
        private void SortId(object sender, EventArgs e)
        {
            List<UserModel> sList = new List<UserModel>();
            if (Id)
                sList = modelList.OrderBy(o => o.id_user).ToList();
            else
                sList = modelList.OrderByDescending(o => o.id_user).ToList();

            Id = !Id;
            users.ItemsSource = null;
            users.ItemsSource = sList;

        }
        private void CreateTimeSort(object sender, EventArgs e)
        {
            List<UserModel> sList = new List<UserModel>();
            if (Time)
                sList = modelList.OrderBy(o => o.create_time).ToList();
            else
                sList = modelList.OrderByDescending(o => o.create_time).ToList();

            Time= !Time;
            users.ItemsSource = null;
            users.ItemsSource = sList;
        }
        private void EmailSort(object sender, EventArgs e)
        {
            List<UserModel> sList = new List<UserModel>();
            if (Email)
                sList = modelList.OrderBy(o => o.email).ToList();

            Email= !Email;
            users.ItemsSource = null;
            users.ItemsSource = sList;
        }
    }
}