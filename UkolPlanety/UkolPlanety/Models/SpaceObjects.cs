using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using UkolPlanety.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace UkolPlanety.Models

{
   public class SpaceObjects
    {
        public ObservableCollection<ASpaceObject> AllSpaceObjects { get; set; }

        public SpaceObjects()
        {
            AllSpaceObjects = new ObservableCollection<ASpaceObject>();
            AllSpaceObjects.Add(new ASpaceObject { IsHazerdious = false, Name = "Test", Size = 232, Speed = 11 });

            RefreshAPI();
            AllSpaceObjects.Add(new ASpaceObject { IsHazerdious = false, Name = "Negr", Size = 44444, Speed = 8 });
        }
        public async Task RefreshAPI()
        {
            HttpClient myclient = new HttpClient();
            DateTime dateTime = DateTime.Now;
            DateTime dateTime1 = dateTime.AddDays(-1);
            //string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + dateTime1.ToString("yyyy-MM-dd") + "&end_date=" + dateTime1.ToString("yyyy-MM-dd") + "_key=hkxsVmmgRja7xcnPNXiTirSSszjd59aJEqEXVCg9";
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2021-01-04&end_date=2021-01-05&api_key=hkxsVmmgRja7xcnPNXiTirSSszjd59aJEqEXVCg9";
            try
            {
                HttpResponseMessage responseMessage = await myclient.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                string result = await responseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(result);
                for (int i = 0; i < 13; i++)
                {
                    ASpaceObject testSpaceO = new ASpaceObject();
                    testSpaceO.Name = Convert.ToString(jsonObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["name"]);
                    testSpaceO.Size = Convert.ToDouble(jsonObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["estimated_diameter"]["kilometers"]["estimated_diameter_max"]);
                    testSpaceO.Speed = Convert.ToDouble(jsonObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["close_approach_data"][0]["relative_velocity"]["kilometers_per_hour"]);
                    testSpaceO.IsHazerdious = Convert.ToBoolean(jsonObject["near_earth_objects"][dateTime1.ToString("yyyy-MM-dd")][i]["is_potentially_hazardous_asteroid"]);
                    AllSpaceObjects.Add(testSpaceO);
                }
            }
            catch (HttpRequestException )
            {
                throw;
            }
        }
    }

}
