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
    class PriceFor
    {
        public static HttpClient CLIENT = new HttpClient();
        // prodapi.shipox.com
        // stagingapi.shipox.com

        public static string URL = "https://prodapi.shipox.com/api/v2/customer/packages/prices/starting_from?";
        public static string TOKEN = "";
        public static List<Country> CONTRIES = null;
        public static List<City> CITIES = null;
        public static List<List> GetPrice(string token)
        {
            TOKEN = token;
            CONTRIES = Countries.GetCountries(TOKEN);
            CITIES = Cities.GetCities(TOKEN);

            string CountryFrom = "Kazakhstan";
            string CityFrom = "Almaty";
            string CountryTo = "Uzbekistan";
            string CityTo = "Tashkent";

            var country_from = CONTRIES.Where(p=>p.name== CountryFrom).FirstOrDefault();
            var city_from = CITIES.Where(p=>p.name==CityFrom).FirstOrDefault();

            Console.WriteLine(country_from.code);
            Console.WriteLine(city_from.name);

            var country_to = CONTRIES.Where(p => p.name == CountryTo).FirstOrDefault();
            var city_to = CITIES.Where(p => p.name == CityTo).FirstOrDefault();

            Console.WriteLine(country_to.code);
            Console.WriteLine(city_to.name);

            var root = new Root();
            var prices = new List<List>();
            
            CLIENT.BaseAddress = new Uri(URL);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN));

            string from_latitude = city_from.latitude;
            string from_longitude = city_from.longitude;

            string to_latitude = city_to.latitude;
            string to_longitude = city_to.longitude;

            int page = 0, size = 20;
            double length = 2, weight = 2, width = 2;
            string unit = "METRIC";

            string to_country_id = country_to.id.ToString();
            string from_country_id =country_from.id.ToString();

            string testUrl = "from_latitude="+from_latitude+"&from_longitude="+from_longitude+"&to_latitude="+to_latitude+"&to_longitude="+to_longitude+
                "&dimensions.length="+length+"&dimensions.weight="+weight+"&dimensions.width="+width+"&dimensions.unit="+unit+"&to_country_id="+
                to_country_id+"&from_country_id="+from_country_id+"&page="+page+"&size="+size;

            var response = CLIENT.GetAsync(URL+testUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result+"\n\n\n");
                root = JsonConvert.DeserializeObject<Root>(result);
                prices = root.data.list; 

            }
            CLIENT.Dispose();
            foreach(var item in prices)
            {
                Console.WriteLine(item.id+" "+item.name);
                var price = item.price;
                Console.WriteLine("Total: " + price.total + "\n" + "VATtotal: " + price.vat_total + "\n" + "RTOtotal: " + price.rto_total + "\n");  
            }
            return prices;
        }

    }



    public class CourierType
    {
        public string type { get; set; }
        public string icon { get; set; }
        public int sort_order { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Price
    {
        public int id { get; set; }
        public double distance { get; set; }
        public int duration { get; set; }
        public double @base { get; set; }
        public object reverse_base { get; set; }
        public double per_weight { get; set; }
        public double per_distance { get; set; }
        public double distance_included { get; set; }
        public double total { get; set; }
        public double old_total { get; set; }
        public double rto_total { get; set; }
        public object margin_total { get; set; }
        public object vat_total { get; set; }
        public double chargeable_weight { get; set; }
        public string unit { get; set; }
        public Currency currency { get; set; }
    }

    public class List
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public CourierType courier_type { get; set; }
        public object vehicle_type { get; set; }
        public bool has_supplier { get; set; }
        public Price price { get; set; }
    }

    public class Data
    {
        public int total { get; set; }
        public List<List> list { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        public string status { get; set; }
    }
}



