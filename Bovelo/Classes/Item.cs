using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bovelo
{
    class Item //: Bike should maybe put it that way because of composition
    {
        public int quantity ;
        public Bike bike;
        public int price;
        public Item(Bike bike, int quantity)
        {
            this.quantity = quantity;
            this.bike = bike;
            this.price = getPrice();
        }

        public void increment()
        {
            quantity++;
            price = getPrice();
        }
        public void decrement()
        {
            quantity--;
            price = getPrice();
        }
        public int getPrice()
        {
            return quantity * bike.Price;
        }
    }
}