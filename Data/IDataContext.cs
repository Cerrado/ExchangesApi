using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExchangeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Data
{
    public interface IDataContext
    {
        DbSet<Exchange> Exchanges { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}