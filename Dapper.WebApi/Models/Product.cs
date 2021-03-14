using System;

namespace Dapper.WebApi.Models
{
    public class Product
    {
        public int Request_id { get; set; }
        public int Client_id { get; set; }
        public string Department_address { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}