using KpopZtation.Factory;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class CartRepo
    {
        DatabaseEntities7 db = Database.getDb();
        public int AddServiceToCart(int serviceId, int qty, int customerId)
        {
            Cart cart = FindCustomerSameProductCart(serviceId, customerId);
            if(cart == null)
            {
                cart = CartFactory.createCart(serviceId, qty, customerId);
                db.Carts.Add(cart);
            }
            else
            {
                cart.Qty += qty;
            }
            
            return db.SaveChanges();
        }

        public Cart FindCustomerSameProductCart(int serviceId, int customerId)
        {
            Cart cart = (from c in db.Carts where c.ServiceID.Equals(serviceId) && c.CustomerID.Equals(customerId) select c).ToList().FirstOrDefault();
            if(cart == null)
            {
                return null;
            }
            return cart;
        }

        public List<Cart> GetCustomerCart(int customerId)
        {
            return (from c in db.Carts where c.CustomerID.Equals(customerId) select c).ToList();
        }

        public Cart GetCustomerServiceItemCart(int serviceId)
        {
            return (from c in db.Carts where c.ServiceID.Equals(serviceId) select c).ToList().FirstOrDefault();
        }

        public int DeleteCartItem(int id)
        {
            Cart cart = GetCustomerServiceItemCart(id);
            db.Carts.Remove(cart);
            return db.SaveChanges();
        }

        public int RemoveAllCartItem(List<Cart> cartList)
        {
            db.Carts.RemoveRange(cartList);
            return db.SaveChanges();
        }
    }
}