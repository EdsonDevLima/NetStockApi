using Microsoft.EntityFrameworkCore;
using NetStock.config;
using NetStock.Entities;

namespace NetStock.Repositories
{

    public class CategoriesRepository : ICategory
    {

        private readonly ContextNetStockDb context;
        public CategoriesRepository(ContextNetStockDb _context)
        {

            this.context = _context;
        }

        public async Task<IEnumerable<Categories>> GetAllAsync() =>

             await this.context.Categories.ToListAsync();


        public async Task AddAsync(Categories category)
        {
            await this.context.Categories.AddAsync(category);
        }


        public async Task<Categories> GetByIdAsync(int id) =>
            await this.context.Categories.FindAsync(id);




        public async Task UpdateAsync(Categories Categories)
        {
            this.context.Categories.Update(Categories);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Categories = this.context.Categories.Find(id);
            if (Categories is null)
                return;


            this.context.Categories.Remove(Categories);
            await this.context.SaveChangesAsync();

        }



    }
}