using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {        
        private readonly DataContext _context;
        public ClientController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _context.Clients.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if(client == null)            
                return BadRequest("Client not found.");
           
            return Ok(client);
        }
        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(Client updateclient)
        {
            var sclient = await _context.Clients.FindAsync(updateclient.Id);

            if (sclient == null)
            {
                return BadRequest("Client not found.");
            }
            else
            {
                sclient.Name = updateclient.Name;
                sclient.Address = updateclient.Address;
                sclient.JoinedDate = updateclient.JoinedDate;

                await _context.SaveChangesAsync();

                return Ok(await _context.Clients.ToListAsync());
            }
                
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult<List<Client>>> DeleteClient(int id)
        {
            var dbclient = await _context.Clients.FindAsync(id);
            if (dbclient == null)
            {
                return BadRequest("Client not found.");
            }
             else
            {
                _context.Clients.Remove(dbclient);
                await _context.SaveChangesAsync();

                return Ok(await _context.Clients.ToListAsync());
            }            
        }
    }
}
