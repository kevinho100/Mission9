using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Books cate, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Books.BookId == cate.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = cate,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Books books)
        {
            Items.RemoveAll(x => x.Books.BookId == books.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }


        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);

            return sum;
        }
    }


    public class BasketLineItem
        {
            public int LineID { get; set; }

            public Books Books { get; set; }

            public int Quantity { get; set; }
        }
    
}
