using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IUnitOfWork _UOW;

        public CategoryController(IUnitOfWork uOW)
        {
            _UOW = uOW;
        }
        [HttpPost()]
        public IActionResult PostCategores(Category cat)
        {
            _UOW.category.Create(cat);
            _UOW.save();
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryWithVahCount(int id)
        {
            return Ok(_UOW.category.GetCategoryWithVehCount(id));
        }
    }
}
