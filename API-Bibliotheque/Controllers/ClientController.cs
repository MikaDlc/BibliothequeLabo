using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;
using Crypt = BCrypt.Net.BCrypt;

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
        [HttpGet("profile")]
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

        [Authorize("userRequired")]
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

        [Authorize("userRequired")]
        [HttpPut("email")]
        public IActionResult PutEmail([FromBody] EmailPost email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            _clientService.EmailUpdate(HttpContext.GetId(), email.Email);
            return NoContent();
        }

        [Authorize("userRequired")]
        [HttpPut("password")]
        public IActionResult PutPassword([FromBody] PasswdPost passwd)
        {
            if (passwd == null)
            {
                return BadRequest();
            }

            _clientService.PasswordUpdate(HttpContext.GetId(), Crypt.HashPassword(passwd.Passwd));
            return NoContent();
        }

        [Authorize("userRequired")]
        [HttpPost("equal")]
        public IActionResult PostEqual([FromBody] PasswdPost passwd)
        {
            if (passwd == null)
            {
                return BadRequest();
            }

            return Ok(Crypt.Verify(passwd.Passwd, _clientService.Get(HttpContext.GetId()).Passwd));
        }
    }
}
