using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Review2_NET.Models;

namespace Review2_NET.Models.Repositories
{
    public interface IReviewRepo
    {
        IQueryable<Review> Reviews { get; }
        Review Save(Review review);
        Review Edit(Review review);
        void Remove(Review review);
    }
}
