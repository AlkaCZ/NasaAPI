using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using UkolPlanety.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using  System.Net.Http;

namespace UkolPlanety.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpaceObjectsPage : ContentPage
    {
        public SpaceObjectsPage()
        {

            InitializeComponent();
            SpaceObjects spaceObjects = new SpaceObjects();
            BindingContext = spaceObjects;
        }

        async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Page p = new ASpaceObjectPage(((((ListView)sender).SelectedItem) as Models.ASpaceObject), (BindingContext as SpaceObjects).AllSpaceObjects);
            NavigationPage np = new NavigationPage(p);
            await Application.Current.MainPage.Navigation.PushAsync(np);

            if ((sender as ListView) != null)
                (sender as ListView).SelectedItem = null;

        }

       async void Straight_Button_Clicked(object sender, EventArgs e)
        {
            RefreshAPI();
        }
        public async Task RefreshAPI()
        {
            HttpClient myclient = new HttpClient();
            DateTime dateTime = DateTime.Now;
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2015-09-07&end_date=2015-09-08&api_key=hkxsVmmgRja7xcnPNXiTirSSszjd59aJEqEXVCg9";
            try
            {
                HttpResponseMessage responseMessage = await myclient.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                string result = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(result);
                for (int i = 0; i < 13; i++)
                {
                    ASpaceObject testSpaceO = new ASpaceObject();
                    testSpaceO.Name = Convert.ToString(jsonObject["near_earth_objects"][dateTime.ToString("yyyy-MM-dd")][i]["name"]);
                    testSpaceO.Size = Convert.ToDouble(jsonObject["near_earth_objects"][dateTime.ToString("yyyy-MM-dd")][i]["estimated_diameter"]["kilometers"]["estimated_diameter_max"]);
                    testSpaceO.Speed = Convert.ToDouble(jsonObject["near_earth_objects"][dateTime.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]);
                    testSpaceO.IsHazerdious = Convert.ToBoolean(jsonObject["near_earth_objects"][dateTime.ToString("yyyy-MM-dd")][i]["is_potentially_hazardous_asteroid"]);
                }
                
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
