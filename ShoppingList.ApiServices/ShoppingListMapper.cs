using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingList.ApiServices.Models;
using ShoppingList.ApiServices.ShoppingList.Model;
using ShoppingList.Data.ShoppingList.Model;

namespace ShoppingList.ApiServices
{
    public static class ShoppingListMapper
    {
        public static void Configure(IMapperConfiguration cfg)
        {
            cfg.CreateMap<ShoppingItem, ShoppingItemDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Drink, opt => opt.MapFrom(src => new Drink() { Name = src.Drink}));
            //.AfterMap((item, itemDto) => itemDto.Drink = new Drink { Name = item.Drink });
        }
    }
}
