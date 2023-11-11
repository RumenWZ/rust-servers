using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly DataContext dc;
        private readonly IMapper mapper;

        public ServerController
            (
            DataContext dc,
            IMapper mapper
            )
        {
            this.dc = dc;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetServers()
        {
            var properties = await dc.RustServers.ToListAsync();
            var propertiesDTO = mapper.Map<IEnumerable<ServerDTO>>(properties);
            
            return Ok(propertiesDTO);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddServer(AddServerDTO server)
        {
            if (await dc.RustServers.FirstOrDefaultAsync(s => s.Name == server.Name) != null)
            {
                return BadRequest("Server already added");
            }
            var newServer = mapper.Map<RustServer>(server);
            dc.RustServers.Add(newServer);
            await dc.SaveChangesAsync();
            return Ok(201);
        }


    }
}
