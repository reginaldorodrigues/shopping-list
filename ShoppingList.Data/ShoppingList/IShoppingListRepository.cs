using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Data.ShoppingList.Model;

namespace ShoppingList.Data.ShoppingList
{
    public interface IShoppingListRepository
    {
        void Add(string drinkName, int quantity);

        int UpdateItemQuantity(string drink, int quantity);

        int Delete(string drink);

        ShoppingItem GetByDrink(string drink);

        List<ShoppingItem> Get();
    }
}
