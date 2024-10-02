using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISaleRepository<BLL.Sale> _saleRepository;
        public SaleController(ISaleRepository<BLL.Sale> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_saleRepository.Get().Select(s => s.ToAPI()));
        }

        [HttpGet("/{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_saleRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] SalePost sale)
        {
            _saleRepository.Insert(sale.ToBLL());
            return CreatedAtAction(nameof(Get), sale);
        }
    }
}
