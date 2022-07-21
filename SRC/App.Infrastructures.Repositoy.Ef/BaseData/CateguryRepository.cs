using App.Domain.Core.BaseData.Contacts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entity;
using App.Infrastructures.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Repositoy.Ef.BaseData
{
    public class CateguryRepository : ICateguryRepository
    {
        private readonly AppDbContext _DbContext;

        public CateguryRepository(AppDbContext DbContext)
        {
           _DbContext = DbContext;
        }
        public async Task Add(CategoryDto CategoryDto)
        {
            Category Category = new Category
            {
                Id = CategoryDto.Id,
                Title = CategoryDto.Title,
            };
            _DbContext.Categories.Add(Category);
            await _DbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var record = await _DbContext.Categories.Where(p=>p.Id==Id).SingleOrDefaultAsync();
            _DbContext.Categories.Remove(record);
            _DbContext.SaveChangesAsync();
        }

        public async Task<CategoryDto> Get(int id)
        {
            return await _DbContext.Categories.Where(p => p.Id == id).Select(p => new CategoryDto()
            {
                Id = p.Id,
                Title = p.Title,
            }).SingleAsync();
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return await _DbContext.Categories.Select(p => new CategoryDto()
            {
             Id=p.Id,
             Title=p.Title,
            }).ToListAsync();
        }

        public async Task Update(CategoryDto CategoryDto)
        {
            var record = await _DbContext.Categories.Where(p => p.Id == CategoryDto.Id).SingleOrDefaultAsync();
            record.Title=CategoryDto.Title;
            _DbContext.SaveChangesAsync();
        }
    }
}
