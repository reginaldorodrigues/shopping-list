using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.ApiServices.Models;

namespace ShoppingList.ApiServices.ShoppingList.Model
{
    public class ShoppingItemDto
    {
        [Required]
        public Drink Drink { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity has to be a valid number and greater than zero.")]
        public int Quantity { get; set; }
    }
}
