using System;

namespace ExchangeApi.Models
{
    public class Exchange
    {
        public int ExchangeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}