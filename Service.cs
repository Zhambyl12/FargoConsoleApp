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
    class Service
    {
        public static HttpClient CLIENT = new HttpClient();
        public static string URL = "https://stagingapi.shipox.com/api/v1/service_types";
        public static string TOKEN = "";
        public static List<List> GetServiceTypes(string token)
        {
            var root = new Root(); 
            var services = new List<List>(); 
            TOKEN = token;
            CLIENT.BaseAddress = new Uri(URL);
            CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CLIENT.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", TOKEN));
            var response = CLIENT.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                root = JsonConvert.DeserializeObject<Root>(result);
                services = root.data.list;  
            } 
            return services;
        }
    }
}

public class List
{
    public int marketplace_id { get; set; }
    public List<int> marketplace_ids { get; set; }
    public int id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public int sorder { get; set; }
    public string image { get; set; }
    public string description { get; set; }
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
