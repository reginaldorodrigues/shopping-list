using ShoppingList.ApiServices.ShoppingList.Model;
using System.Collections.Generic;

namespace ShoppingList.ApiServices.ShoppingList
{
    public interface IShoppingListService
    {
        void Add(ShoppingItemDto item);

        void UpdateItemQuantity(ShoppingItemDto item);

        void Delete(string drink);

        ShoppingItemDto GetByDrink(string drink);

        Model.ShoppingList Get();
    }
}