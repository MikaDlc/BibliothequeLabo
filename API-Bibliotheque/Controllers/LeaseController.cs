using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseController : ControllerBase
    {
        private ILeaseRepository<BLL.Lease> _leaseService;
        public LeaseController(ILeaseRepository<BLL.Lease> leaseService)
        {
            _leaseService = leaseService;
        }

        [Authorize("adminRequired")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_leaseService.Get().Select(l => l.ToAPI()));
        }

        [Authorize("adminRequired")]
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var lease = _leaseService.Get(id);
                return Ok(lease.ToAPIDetails());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize("userRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] LeasePost lease)
        {
            try
            {
                if (lease == null)
                {
                    return BadRequest();
                }
                var NewLease = lease.ToBLL();
                NewLease.ClientID = HttpContext.GetId();
                _leaseService.Insert(NewLease);
                return CreatedAtAction(nameof(Get), lease);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize("adminRequired")]
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id)
        {
            _leaseService.Update(id, new BLL.Lease { ReturnDate = DateTime.Now});
            return NoContent();
        }
    }
}
