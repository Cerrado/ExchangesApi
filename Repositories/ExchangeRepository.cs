using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApi.Data;
using ExchangeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly IDataContext _context;
        public ExchangeRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Exchange exchange)
        {
            _context.Exchanges.Add(exchange);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exchangeToDelete = await _context.Exchanges.FindAsync(id);
            if (exchangeToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Exchanges.Remove(exchangeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Exchange> Get(int id)
        {
            return await _context.Exchanges.FindAsync(id);
        }

        public async Task<IEnumerable<Exchange>> GetAll()
        {
            return await _context.Exchanges.ToListAsync();
        }

        public async Task Update(Exchange exchange)
        {
            var exchangeToUpdate = await _context.Exchanges.FindAsync(exchange.ExchangeId);
            if(exchangeToUpdate == null)
                throw new NullReferenceException();
            
            exchangeToUpdate.Name = exchange.Name;
            exchangeToUpdate.Url = exchange.Url;
            await _context.SaveChangesAsync();
        }
    }
}