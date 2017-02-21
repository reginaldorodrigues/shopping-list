using System.Web.Http;
using ShoppingList.Api.Filters;
using ShoppingList.ApiServices.ShoppingList;
using ShoppingList.ApiServices.ShoppingList.Model;
using ShoppingList.Common.Exceptions;

namespace ShoppingList.Api.Controllers
{
    [AuthenticationFilter]
    public class ShoppingListController : ApiController
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpPost]
        [Route("api/shoppingList")]
        public IHttpActionResult Add([FromBody] ShoppingItemDto item)
        {
            _shoppingListService.Add(item);

            return Ok();
        }

        [HttpPut]
        [Route("api/shoppingList")]
        public IHttpActionResult UpdateItemQuantity([FromBody] ShoppingItemDto item)
        {
            _shoppingListService.UpdateItemQuantity(item);

            return Ok();
        }

        [HttpDelete]
        [Route("api/shoppingList/{drink}")]
        public IHttpActionResult Delete([FromUri] string drink)
        {
            _shoppingListService.Delete(drink);

            return Ok();
        }

        [HttpGet]
        [Route("api/shoppingList/{drink}")]
        public IHttpActionResult Get([FromUri] string drink)
        {
            return Ok(_shoppingListService.GetByDrink(drink));
        }

        [HttpGet]
        [Route("api/shoppingList")]
        public IHttpActionResult Get()
        {
            return Ok(_shoppingListService.Get());
        }
    }
}