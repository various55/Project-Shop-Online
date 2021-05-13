using Constants;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helpers
{
    public class ShoppingCart
    {
        ShopContext dbContext = new ShopContext();
        public ShoppingCart()
        {
        }

        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session[SessionConst.CART] as ShoppingCart;
                // Nếu chưa có giỏ hàng trong session thì tạo mới
                if(cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session[SessionConst.CART] = cart;
                }
                return cart;
            }
        }
        public List<OrderDetail> Items = new List<OrderDetail>();
        public int discount { get; set; }

        public bool Add(int id,int quantity)
        {
            if (id > 0)
            {
                // Tìm xem có sản phẩm đó k, nếu k thì return false luôn
                var product = dbContext.ProductDetails.Include("Product").Include("Size").Include("Color").FirstOrDefault(x=>x.ID == id);
                if(product!= null)
                {
                    var item = Items.SingleOrDefault(i => i.ProductDetaiID == id);
                    // Nếu chưa tồn tại trong giỏ thì add
                    if (item == null)
                    {

                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ProductDetail = product;
                        orderDetail.Discount = product.Product.Discount;
                        orderDetail.Price = product.Product.ExportPrice;
                        orderDetail.ProductDetaiID = product.ID;
                        orderDetail.Quantity = quantity;
                        Items.Add(orderDetail);
                    }
                    else
                    {
                        item.Quantity+=quantity;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool Remove(int id)
        {
            var item = Items.Single(i => i.ProductDetaiID == id);
            return Items.Remove(item);
        }
        public bool Update(int id,int quantity)
        {
            var item = Items.Single(i => i.ProductDetaiID == id);
            if (item == null) return false;
            item.Quantity = quantity;
            return true;
        }
        public void Clear()
        {
            Items.Clear();
        }
        public int Count()
        {
            return Items.Count;
        }
        public float Total()
        {
            var sum = (double) Items.Sum(i => i.Quantity * i.Price * (1 - i.Discount / 100));
            return (float)sum;
        }
    }
}
