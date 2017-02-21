using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Item could not be found.")
        {

        }

        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
