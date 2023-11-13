using Application;
using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ISportTypeRepository _sportTypeRepository;

        public UnitOfWork(AppDbContext appDbContext, ISportTypeRepository sportTypeRepository)
        {
            _appDbContext = appDbContext;   
            _sportTypeRepository = sportTypeRepository;
        }

        public ISportTypeRepository SportTypeRepository => _sportTypeRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
