﻿using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models;
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
            return Ok(_clientService.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientPost client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            _clientService.Insert(client.ToBLL());
            return CreatedAtAction(nameof(Get), client);
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

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return NoContent();
        }
    }
}