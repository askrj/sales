using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;

namespace SalesWeb.Services
{
    public class SellerService
    {
        private readonly SalesDbContext _dbContext;

        public SellerService(SalesDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _dbContext.Sellers.Include(x => x.Departament).ToListAsync();
        }

        public void Isert(Seller obj)
        {
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
        }

        
        public async Task<Seller> FindiByIdAsync(int id)
        {
            return await _dbContext.Sellers.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _dbContext.Sellers.Find(id);
            _dbContext.Sellers.Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_dbContext.Sellers.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundExceptoion("Id not found.");
            }
            try
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbUpdateConcurrencyException(e.Message);
            }
            
        }
    }
}