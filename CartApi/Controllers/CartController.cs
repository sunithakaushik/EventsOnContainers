using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CartApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Module 22 - Adding controller for cart api
namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        // using ICartRepo which uses Redis cache
        private readonly ICartRepository _repository;
        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            // We need to call the repository and pass the id that gives the basket
            // controller is a pass through
            var basket = await _repository.GetCartAsync(id);
            return Ok(basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]Cart value)
        {
            var basket = await _repository.UpdateCartAsync(value);
            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _repository.DeleteCartAsync(id);
        }
    }
}