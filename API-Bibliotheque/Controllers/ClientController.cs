using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Auth;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("adminRequired")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clientService.Get().Select(c => c.ToAPI()));
        }

        [Authorize("userRequired")]
        [HttpGet("/profile")]
        public IActionResult GetUserInfo()
        {
            try
            {
                return Ok(_clientService.Get(HttpContext.GetId()).ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClientPost client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            
            _clientService.Update(HttpContext.GetId(), client.ToBLL());
            return NoContent();
        }
    }
}
