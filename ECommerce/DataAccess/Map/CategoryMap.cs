using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Map;
using DataAccess.Entity;

namespace DataAccess.Map
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.CategoryName).HasMaxLength(255).IsRequired();
            Property(x => x.Description).HasMaxLength(255).IsOptional();

        }
    }
}
