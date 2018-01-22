using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review2_NET.Models;

namespace Review2_NET.Models.Repositories
{
    public class EFProductRepo : IProductRepo
    {
        private MyContext db = new MyContext();

        public IQueryable<Product> Products { get { return db.Products; } }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }
    }
}
