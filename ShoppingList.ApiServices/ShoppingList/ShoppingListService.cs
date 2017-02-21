using ShoppingList.ApiServices.ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ShoppingList.ApiServices.Models;
using ShoppingList.Common.Exceptions;
using ShoppingList.Common.Infrastructure;
using ShoppingList.Data.ShoppingList;
using ShoppingList.Data.ShoppingList.Model;

namespace ShoppingList.ApiServices.ShoppingList
{
    public class ShoppingListService : ServiceBase, IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public void Add(ShoppingItemDto item)
        {
            ValidateModel(item);

            if (IsDrinkAlreadyAdded(item.Drink.Name))
                throw new BusinessException("The selected drink was already added to the shopping list.");

            _shoppingListRepository.Add(item.Drink.Name, item.Quantity);
        }

        public void UpdateItemQuantity(ShoppingItemDto item)
        {
            ValidateModel(item);

            var result = _shoppingListRepository.UpdateItemQuantity(item.Drink.Name, item.Quantity);

            if (result <= 0) throw new EntityNotFoundException();
        }

        public void Delete(string drink)
        {
            var result = _shoppingListRepository.Delete(drink);

            if (result <= 0) throw new EntityNotFoundException();
        }

        public ShoppingItemDto GetByDrink(string drink)
        {
            var result = _mapper.Map<ShoppingItem, ShoppingItemDto>(_shoppingListRepository.GetByDrink(drink));

            if (result == null) throw new EntityNotFoundException();

            return result;
        }

        public Model.ShoppingList Get()
        {
            var result = new Model.ShoppingList()
            {
                Data = _mapper.Map<List<ShoppingItem>, List<ShoppingItemDto>>(_shoppingListRepository.Get())
            };

            if (!result.Data.Any()) throw new EntityNotFoundException("The shopping list is empty.");

            return result;
        }

        private bool IsDrinkAlreadyAdded(string drink)
        {
            var result = _shoppingListRepository.GetByDrink(drink);

            return result != null;
        }
    }
}