
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NetStock.Repositories;

namespace NetStock.Controllers
{
    [ApiController]
    [Route("Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository categoriesRepository;
        public CategoriesController(CategoriesRepository _categoriesRepository)
        {
            categoriesRepository = _categoriesRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await this.categoriesRepository.GetByIdAsync(id);

            return Ok(category);


        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await this.categoriesRepository.GetAllAsync();

            return Ok(categories);


        }


    }
}