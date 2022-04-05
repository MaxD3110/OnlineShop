using Microsoft.EntityFrameworkCore;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class SpecificationManager : ISpecificationManager
    {
        private ApplicationDbContext _ctx;

        public SpecificationManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Task AddSpecification(Specification specification)
        {
            _ctx.Specifications.Add(specification);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteSpecification(int id)
        {
            var specification = _ctx.Specifications.FirstOrDefault(x => x.Id == id);

            _ctx.Specifications.Remove(specification);

            return _ctx.SaveChangesAsync();
        }

        public Specification GetSpecWithProduct(int specId)
        {
            return _ctx.Specifications.Include(x => x.Products).FirstOrDefault(x => x.Id == specId);
        }

        public Task UpdateSpecificationRange(List<Specification> specificationList)
        {
            _ctx.Specifications.UpdateRange(specificationList);
            return _ctx.SaveChangesAsync();
        }

    }
}
