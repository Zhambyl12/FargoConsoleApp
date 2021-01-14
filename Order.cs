//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FargoParcelServiceTest1
//{
//    class Order
//    {
//    }
//    public partial class City
//    {
//        public string code { get; set; }
//    } 

//    public class Neighborhood
//    {
//        public int id { get; set; }
//        public string name { get; set; }
//    }

//    public class SenderData
//    {
//        public string address_type { get; set; }
//        public string name { get; set; }
//        public string email { get; set; }
//        public string apartment { get; set; }
//        public string building { get; set; }
//        public string street { get; set; }
//        public City city { get; set; }
//        public Country country { get; set; }
//        public Neighborhood neighborhood { get; set; }
//        public string phone { get; set; }
//    }

//    public class City2
//    {
//        public int id { get; set; }
//    }

//    public class Neighborhood2
//    {
//        public int id { get; set; }
//        public string name { get; set; }
//    }

//    public class RecipientData
//    {
//        public string address_type { get; set; }
//        public string name { get; set; }
//        public string apartment { get; set; }
//        public string building { get; set; }
//        public string street { get; set; }
//        public City2 city { get; set; }
//        public Neighborhood2 neighborhood { get; set; }
//        public string phone { get; set; }
//        public string landmark { get; set; }
//    }

//    public class Dimensions
//    {
//        public int weight { get; set; }
//        public int width { get; set; }
//        public int length { get; set; }
//        public int height { get; set; }
//        public string unit { get; set; }
//        public bool domestic { get; set; }
//    }

//    public class PackageType
//    {
//        public string courier_type { get; set; }
//    }

//    public class ChargeItem
//    {
//        public bool paid { get; set; }
//        public int charge { get; set; }
//        public string charge_type { get; set; }
//    }

//    public class Root
//    {
//        public SenderData sender_data { get; set; }
//        public RecipientData recipient_data { get; set; }
//        public Dimensions dimensions { get; set; }
//        public PackageType package_type { get; set; }
//        public List<ChargeItem> charge_items { get; set; }
//        public string recipient_not_available { get; set; }
//        public string payment_type { get; set; }
//        public string payer { get; set; }
//        public int parcel_value { get; set; }
//        public bool fragile { get; set; }
//        public string note { get; set; }
//        public int piece_count { get; set; }
//        public bool force_create { get; set; }
//    }

//}
