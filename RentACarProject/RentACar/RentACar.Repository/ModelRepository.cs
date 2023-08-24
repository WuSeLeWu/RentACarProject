using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class ModelRepository : RepositoryBase<Model.Model>
    {
        public ModelRepository(RepositoryContext context) : base(context)
        {

        }


    }
}
