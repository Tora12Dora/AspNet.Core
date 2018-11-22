using System.Collections.Generic;
using System.Linq;
using blog.Models;
 
namespace ViewComponentsApp.Components
{
    public class BestPhoneViewComponent
    {
        List<Clothes> phones;
        public BestPhoneViewComponent()
        {
            phones = new List<Clothes>
            {
                new Clothes {Name="Брюки", Price=56000},
                new Clothes {Name="Пальто", Price=26000 },
                new Clothes {Name="Пиджак", Price=55000 },
                new Clothes {Name="Шорты", Price=23000 }
            };
        }
        public string Invoke()
        {
            var item = phones.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
 
            return $"Самый дорогой продукт: {item.Name}  Цена: {item.Price}";
        }
    }
}