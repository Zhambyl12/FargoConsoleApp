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
    class Program
    {
        public static string TOKEN = "";
        public static HttpClient CLIENT = new HttpClient();
        public static string URL = "https://prodapi.shipox.com/api/v1/customer/authenticate";
        static async Task Main(string[] args)
        {
            var countries = new List<Country>();
            var cities = new List<City>();
            var city = new City();
            var services = new List<List>(); 
            await GetToken(); 
            if (TOKEN.Length > 5)
            {
                //countries = Countries.GetCountries(TOKEN);
                //cities= Cities.GetCities(TOKEN);
                // city = Cities.GetCityByName(TOKEN,"Almaty");
                //services = Service.GetServiceTypes(TOKEN);
                var res = PriceFor.GetPrice(TOKEN);
            }
            //foreach (var item in countries)
            //    Console.WriteLine(item.name+"\t"+item.bank_account_type);
            //foreach (var item in cities.OrderBy(p=>p.name))
            //    Console.WriteLine(item.id + "\t" + item.name);
            //Console.WriteLine("Count: " + cities.Count);
            //foreach (var item in services.OrderBy(p => p.sorder))
            //    Console.WriteLine(item.id + " " + item.name+" "+ item.sorder);
            //foreach (var item in res.OrderBy(p => p.sorder))
            //    Console.WriteLine(item.id + " " + item.name+" "+ item.sorder);
        }
        public static async Task GetToken()
        {
            CLIENT.BaseAddress = new Uri(URL);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            Auth auth = new Auth
            {
                username = "zhambylbeisenaly@gmail.com",
                password = "geekJ5244",
                remember_me = "true"
            };
            var json = JsonConvert.SerializeObject(auth);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await CLIENT.PostAsync(URL, data);
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                AuthResponse AuthResponse = JsonConvert.DeserializeObject<AuthResponse>(result);
                TOKEN = AuthResponse.data.id_token;
            }
            //CLIENT.Dispose();
        }
    }

    public class Auth
    {
        public string username { get; set; }
        public string password { get; set; }
        public string remember_me { get; set; }
    }
    public class AuthResponse
    {
        public data data { get; set; }
        public string status { get; set; }

    }
    public class data
    {
        public string id_token { get; set; }
        public user user { get; set; }
    }
    public class user
    {
        public string version { get; set; }
        public string login { get; set; }
        public string user_id { get; set; }
        public string marketplace_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string activated { get; set; }
        public string languages { get; set; }
        public string phone { get; set; }
        public string full_name { get; set; }
        public string valid_phone { get; set; }
    }
}
