using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApi.Models;

namespace ExchangeApi.Repositories
{
    public interface IExchangeRepository
    {
        Task<Exchange> Get(int id);
        Task<IEnumerable<Exchange>> GetAll();
        Task Add(Exchange exchange);
        Task Delete(int id);
        Task Update(Exchange exchange);
    }
}