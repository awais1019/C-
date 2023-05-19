using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_with_classes
{
    class Stack
    {
        public string Name;
        public float Price;
        public int Quantity;
        public Stack(string Name, float Price, int Quantity)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;

        }
        public Stack()
        {

        }
    }
}
