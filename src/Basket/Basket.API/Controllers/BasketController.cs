using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCard>> GetBasket(string username)
        {
            var basket = await _repository.GetBasket(username);
            return Ok(basket ?? new ShoppingCard(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCard>> UpdateBasket([FromBody] ShoppingCard basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{username}", Name = "DeleteBasket")]
        public async Task<ActionResult> DeleteBasket(string username)
        {
            await _repository.DeleteBasket(username);
            return Ok();
        }
    }
}
