using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services.Exceptions;

namespace SalesWeb.Services
{
    public class DepartamentService
    {
        private readonly SalesDbContext _dbContext;

        public DepartamentService(SalesDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _dbContext.Departaments.OrderBy(x => x.Name).ToListAsync();
        }

        public void Isert(Departament obj)
        {
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
        }

        public async Task<Departament> FindiByIdAsync(int id)
        {
            return await  _dbContext.Departaments.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _dbContext.Departaments.Find(id);
            _dbContext.Departaments.Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Update(Departament obj)
        {
            if (!_dbContext.Departaments.Any(x => x.Id == obj.Id))
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