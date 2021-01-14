using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FargoParcelServiceTest1
{
    class Countries
    {
        public static HttpClient CLIENT = new HttpClient();
        public static string URL = "https://prodapi.shipox.com/api/v1/country/list";
        public static string TOKEN = ""; 
        public static List<Country> GetCountries(string token)
        { 
            var countries = new List<Country>();
            var countryList = new CountryList();
            TOKEN = token;
            CLIENT.BaseAddress = new Uri(URL); 
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN)); 
            var response = CLIENT.GetAsync(URL).Result; 
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                countryList = JsonConvert.DeserializeObject<CountryList>(result);
                countries = countryList.data.OrderBy(p=>p.id).ToList(); 
            }  
            return countries;
        }
        public static Country GetCountryByName(string token,string Name)
        {
            Country country = null;
            var countryList = new CountryList();
            TOKEN = token;
            CLIENT.BaseAddress = new Uri(URL);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN));
            var response = CLIENT.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                countryList = JsonConvert.DeserializeObject<CountryList>(result);
                country = countryList.data.Where(p=>p.name==Name).FirstOrDefault();
            } 
            return country;
        }
    }
    public class Country
    {
        public int marketplace_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string currency { get; set; }
        public string bank_account_type { get; set; }
        public string sort_name { get; set; }
        public string sort_order { get; set; }
    }
    public class CountryList
    {
        public List<Country> data { get; set; } 
    } 
}
