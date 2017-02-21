using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.Serialization;
using ShoppingList.Data.ShoppingList.Model;

namespace ShoppingList.Data.ShoppingList
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly string _filePath;

        public ShoppingListRepository()
        {
            _filePath = HostingEnvironment.MapPath("~/App_Data/ShoppingList.xml");
        }

        public void Add(string drinkName, int quantity)
        {
            var xdoc = XDocument.Load(_filePath);

            xdoc.Element("ShoppingList").Add(
                new XElement("ShoppingItem",
                    new XElement("Drink", drinkName),
                    new XElement("Quantity", quantity)
                ));

            xdoc.Save(_filePath);
        }

        public int UpdateItemQuantity(string drink, int quantity)
        {
            var xdoc = XDocument.Load(_filePath);

            var item =
                xdoc.Root.Elements().FirstOrDefault(x => x.Element("Drink").Value.ToLower().Equals(drink.ToLower()));

            if (item != null)
            {
                item.SetElementValue("Quantity", quantity);
                xdoc.Save(_filePath);

                return 1;
            }

            return 0;
        }

        public int Delete(string drink)
        {
            var xdoc = XDocument.Load(_filePath);

            var item =
                xdoc.Root.Elements().FirstOrDefault(x => x.Element("Drink").Value.ToLower().Equals(drink.ToLower()));

            if (item != null)
            {
                item.Remove();
                xdoc.Save(_filePath);

                return 1;
            }

            return 0;
        }

        public ShoppingItem GetByDrink(string drink)
        {
            var xdoc = XDocument.Load(_filePath);

            var item =
                xdoc.Root.Elements().FirstOrDefault(x => x.Element("Drink").Value.ToLower().Equals(drink.ToLower()));

            if (item == null) return null;

            var serializer = new XmlSerializer(typeof(ShoppingItem));
            var shoppingItem = (ShoppingItem) serializer.Deserialize(item.CreateReader());

            return shoppingItem;
        }

        public List<ShoppingItem> Get()
        {
            var shoppingList = new List<ShoppingItem>();

            using (var reader = new StreamReader(_filePath))
            {
                var deserializer = new XmlSerializer(typeof(List<ShoppingItem>),
                    new XmlRootAttribute("ShoppingList"));

                shoppingList = (List<ShoppingItem>) deserializer.Deserialize(reader);
            }

            return shoppingList;
        }
    }
}