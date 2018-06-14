using System;
using System.Threading.Tasks;
using AutoMapper;
using Fooder.API.Data;
using Fooder.API.DTOs;
using Fooder.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fooder.API.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {
        private readonly IFoodorRepository _repo;
        private readonly IMapper _mapper;
        public RestaurantsController(IFoodorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantForRegisterDto restaurantForRegister)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantForRegister);

            _repo.Add(restaurant);

            var restaurantToReturn = _mapper.Map<RestaurantForReturnDto>(restaurant);

            if(await _repo.SaveAll())
                return CreatedAtRoute("GetRestaurant", new {id = restaurant.Id}, restaurantToReturn);

            throw new Exception("Fail to created restaurant");
        }

        [HttpGet ("{id}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restaurantFromRepo = await _repo.GetRestaurant(id);

            var restaurantForReturn = _mapper.Map<RestaurantForReturnDto>(restaurantFromRepo);
            if(restaurantFromRepo == null)
                return NotFound();

            return Ok(restaurantForReturn);
        }
    }
}