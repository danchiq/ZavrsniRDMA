using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZavrsniRDMA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        bool Percent = false;
        bool Score = false;
        bool IdUser = false;
        bool IdExercise = false;
        bool Skill = false;
        bool MaxV = false;

       // bool Email=false;
      //  bool Language=false;
       // bool CreateTime=false;

        List<ResultModel> modelList = new List<ResultModel>();
        public ResultsPage()
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
                    ResultModel m = new ResultModel();

                    m.id_user = userObject["id_user"].ToString();
                    m.id_exercise = userObject["id_exercise"].ToString();
                    m.skill = userObject["skill"].ToString();
                    m.result_percent = userObject["result_percent"].ToString();
                    m.result_score = userObject["result_score"].ToString();
                    m.result_max = userObject["result_max"].ToString();
                    //m.email = userObject["email"].ToString();
                    //m.language = userObject["language"].ToString();
                    //m.create_time = userObject["create"].ToString();
                    modelList.Add(m);
                }
            }
            results.ItemsSource = modelList;
            
        }
        //private void DeleteUser(object sender, EventArgs e)
        //{
        //    modelList.Clear();
        //    results.ItemsSource = null;
        //    results.ItemsSource = modelList;
        //}
        private void SortId(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (IdUser)
                sList = modelList.OrderBy(o => o.id_user).ToList();
            else
                sList = modelList.OrderByDescending(o => o.id_user).ToList();

            IdUser = !IdUser;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void SortIdExercise(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (IdExercise)
                sList = modelList.OrderBy(o => o.id_exercise).ToList();
            else
                sList = modelList.OrderByDescending(o => o.id_exercise).ToList();

            IdExercise = !IdExercise;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void SkillSort(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (Skill)
                sList = modelList.OrderBy(o => o.skill).ToList();
            else
                sList = modelList.OrderByDescending(o => o.skill).ToList();

            Skill = !Skill;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void PercentSort(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (Percent)
                sList = modelList.OrderBy(o => o.result_percent).ToList();
            else
                sList = modelList.OrderByDescending(o => o.result_percent).ToList();

            Percent = !Percent;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void ScoreSort(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (Score)
                sList = modelList.OrderBy(o => o.result_score).ToList();
            else
                sList = modelList.OrderByDescending(o => o.result_score).ToList();

            Score = !Score;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void MaxSort(object sender, EventArgs e)
        {
            List<ResultModel> sList = new List<ResultModel>();
            if (MaxV)
                sList = modelList.OrderBy(o => o.result_max).ToList();
            else
                sList = modelList.OrderByDescending(o => o.result_max).ToList();


            MaxV = !MaxV;
            results.ItemsSource = null;
            results.ItemsSource = sList;
        }
        private void FilterButton_Clicked(object sender, EventArgs e)
        {
            List<ResultModel> fList = new List<ResultModel>();

            var fromValue = From.Text;
            var toValue = To.Text;

            if (fromValue == null) fromValue = "0";
            if (toValue == null) toValue = "100";

            float fV = float.Parse(fromValue);
            float tV = float.Parse(toValue);

            fList = modelList.Where(o => float.Parse(o.result_percent) >= fV && float.Parse(o.result_percent) <= tV).ToList();
            results.ItemsSource = null;
            results.ItemsSource = fList;
        }
        //private void EmailSort(object sender, EventArgs e)
        //{
        //    List<ResultModel> sList = new List<ResultModel>();
        //    if (Email)
        //        sList = modelList.OrderBy(o => o.email).ToList();

        //    Email= !Email;
        //    results.ItemsSource = null;
        //    results.ItemsSource = sList;
        //}
        //private void LangSort(object sender, EventArgs e)
        //{
        //    List<ResultModel> sList = new List<ResultModel>();
        //    if (Language)
        //        sList = modelList.OrderBy(o => o.language).ToList();

        //    Language= !Language;
        //    results.ItemsSource = null;
        //    results.ItemsSource = sList;
        //}
        //private void CreateTimeSort(object sender, EventArgs e)
        //{
        //    List<ResultModel> sList = new List<ResultModel>();
        //    if (CreateTime)
        //        sList = modelList.OrderBy(o => o.create_time).ToList();
        //    else
        //        sList = modelList.OrderByDescending(o => o.create_time).ToList();

        //    CreateTime= !CreateTime;
        //    results.ItemsSource = null;
        //    results.ItemsSource = sList;
        //}
    }
}