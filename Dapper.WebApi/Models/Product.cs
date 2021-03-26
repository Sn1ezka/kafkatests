using System;

namespace Dapper.WebApi.Models
{
    public class Product
    {
        public int RequestId { get; set; }
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}