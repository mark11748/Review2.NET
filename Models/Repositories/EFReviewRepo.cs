using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review2_NET.Models;

namespace Review2_NET.Models.Repositories
{
    public class EFReviewRepo : IReviewRepo
    {
        private MyContext db = new MyContext();

        public IQueryable<Review> Reviews => throw new System.NotImplementedException();

        public Review Edit(Review review)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Review review)
        {
            throw new System.NotImplementedException();
        }

        public Review Save(Review review)
        {
            throw new System.NotImplementedException();
        }
    }
}
