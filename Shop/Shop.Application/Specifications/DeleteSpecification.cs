using Shop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Specifications
{
    [Service]
    public class DeleteSpecification
    {
        private ISpecificationManager _specificationManager;

        public DeleteSpecification(ISpecificationManager specificationManager)
        {
            _specificationManager = specificationManager;
        }
        public Task<int> Do(int id)
        {
            return _specificationManager.DeleteSpecification(id);
        }
    }
}
