using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.ApiServices.Models
{
    public class BaseProduct
    {
        [Required]
        public string Name { get; set; }
    }
}
