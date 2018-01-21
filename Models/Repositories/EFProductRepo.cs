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

        public IQueryable<Product> Products => throw new NotImplementedException();

        public Product Edit(Product product)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
