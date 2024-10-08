using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientRepository<BLL.Client> _clientService;

        public ClientController(IClientRepository<BLL.Client> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientService.Get().Select(c => c.ToAPI()));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var client = _clientService.Get(id);
                return Ok(client.ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientPost client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest();
                }
                _clientService.Insert(client.ToBLL());
                return CreatedAtAction(nameof(Get), client);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ClientPost client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            _clientService.Update(id, client.ToBLL());
            return NoContent();
        }
    }
}
