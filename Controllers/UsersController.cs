using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Fooder.API.Data;
using Fooder.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fooder.API.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IFoodorRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IFoodorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForDetailDto userForUpdate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _repo.GetUser(id);

            if(userFromRepo == null)
                return NotFound($"Could not find user with an ID of {id}");

            if(currentUserId != userFromRepo.Id)
                return Unauthorized();

            _mapper.Map(userForUpdate, userFromRepo);

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }
    }
}