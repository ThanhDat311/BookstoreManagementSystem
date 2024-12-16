using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementSystem
{
    internal class Book
    {
        private int id;
        string name;
        double price;
        int quantity;
        public Book(int id, string name, double price,int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
       
    }
}
