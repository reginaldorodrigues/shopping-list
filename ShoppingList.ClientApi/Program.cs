using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;

namespace ShoppingList.ClientApi
{
    public class Program
    {
        private const string DrinkSample = "Coca-cola";

        static void Main(string[] args)
        {
            CreateItem();
            CreateItem();
            UpdateItem();
            GetItem();
            Get();
            DeleteItem();
            UpdateItem();
            Get();
            GetItem();

            Console.ReadKey();
        }

        #region .: Api Method Helpers :.

        private static void CreateItem()
        {
            var apiClient = new APIClient();

            var apiResponse = apiClient.ShoppingListService.CreateItem(GetShoppingItemCreate());
        }

        private static void UpdateItem()
        {
            var apiClient = new APIClient();

            var apiResponse = apiClient.ShoppingListService.UpdateItem(GetShoppingItemUpdate());
        }

        private static void DeleteItem()
        {
            var apiClient = new APIClient();

            var apiResponse = apiClient.ShoppingListService.DeleteItem(DrinkSample);
        }

        private static void GetItem()
        {
            var apiClient = new APIClient();

            var apiResponse = apiClient.ShoppingListService.GetItem(DrinkSample);
        }

        private static void Get()
        {
            var apiClient = new APIClient();

            var apiResponse = apiClient.ShoppingListService.GetShoppingList();
        }

        #endregion .: Api Method Helpers :.

        #region .: GetRequestModel Helpers :.

        private static ShoppingItemCreate GetShoppingItemCreate()
        {
            return new ShoppingItemCreate()
            {
                Drink = new Drink()
                {
                    Name = "Coca-cola"
                },
                Quantity = 1
            };
        }

        private static ShoppingItemUpdate GetShoppingItemUpdate()
        {
            return new ShoppingItemUpdate()
            {
                Drink = new Drink()
                {
                    Name = "Coca-cola"
                },
                Quantity = 5
            };
        }

        #endregion .: GetRequestModel Helpers :.
    }
}
