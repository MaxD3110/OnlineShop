using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Infrastructure
{
    public interface ISpecificationManager
    {
        Task AddSpecification(Specification specification);
        Task UpdateSpecificationRange(List<Specification> specificationList);
        Task<int> DeleteSpecification(int id);
        Specification GetSpecWithProduct(int specId);
    }
}
