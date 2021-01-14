using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FargoParcelServiceTest1
{ 
    class Cities
    {
        public static HttpClient CLIENT = new HttpClient();
        public static string URL = "https://prodapi.shipox.com/api/v1/"; 
        public static string TOKEN = ""; 
        public static List<City> GetCities(string token)
        {
            string podUrl = "cities";
            var cities= new List<City>();
            TOKEN = token;
            CLIENT.BaseAddress = new Uri(URL+podUrl);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN));
            var response = CLIENT.GetAsync(URL+ podUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result; 
                var cityList = JsonConvert.DeserializeObject<CityList>(result);
                cities = cityList.data.OrderBy(p => p.id).ToList();
            } 
            return cities;
        }
        public static City GetCityByName(string token,string cityName)
        {
            string podUrl = "city_by_name/?city_name="+cityName;
            var city = new City(); 
            TOKEN = token;
            CLIENT.BaseAddress = new Uri(URL + podUrl);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN));
            var response = CLIENT.GetAsync(URL + podUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result; 
                city = JsonConvert.DeserializeObject<CityByName>(result).data;
                Console.WriteLine(city.id + " " + city.name + "\n" + city.latitude + " " + city.longitude);
            } 
            return city;
        }

    }
    public class City
    { 
        public int id { get; set; }
        public string name { get; set; } 
        public string latitude { get; set; }
        public string longitude { get; set; } 
    }
    public class CityList
    {
        public List<City> data { get; set; }
    }
    public class CityByName
    {
        public City data { get; set; }
    }
}
