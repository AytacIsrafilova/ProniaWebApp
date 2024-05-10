using Pronia.Core.RepositoryAbstracts;
using ProniaWebApp.DAL;
using ProniaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Data.RepositoryConcrates
{
    public class CategoryRepository : GenericRepository<Category>, IGenericRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
