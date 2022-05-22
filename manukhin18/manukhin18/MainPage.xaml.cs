using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace manukhin18
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            //string url = "http://www.boredapi.com/api/activity/";

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"https://www.boredapi.com/api/activity");
                HttpContent responseContent = response.Content;
                string json = await responseContent.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(json);

                lable.TextColor = Color.Black;
                lable.Text = "Деятельность: " + root.activity + "\r\n" +
                             "Тип: " + root.type + "\r\n" +
                             "Участники: " + root.participants + "\r\n" +
                             "Цена: " + root.price + "\r\n" +
                             "Ссылка: " + root.link + "\r\n" +
                             "Ключ: " + root.key + "\r\n" +
                             "Доступность: " + root.accessibility;

            }
            catch (Exception ex)
            {
                lable.TextColor = Color.Red;
                lable.Text = ex.ToString();
            }

        }
    }
}

