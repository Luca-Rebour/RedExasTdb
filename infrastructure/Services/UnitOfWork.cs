using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        private IDbContextTransaction? _tx;

        public UnitOfWork(AppDbContext ctx) => _ctx = ctx;

        public async Task BeginTransactionAsync()
            => _tx = await _ctx.Database.BeginTransactionAsync();

        public Task<int> SaveChangesAsync()
            => _ctx.SaveChangesAsync();

        public async Task CommitAsync()
        {
            if (_tx != null) await _tx.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_tx != null) await _tx.RollbackAsync();
        }
    }

}
