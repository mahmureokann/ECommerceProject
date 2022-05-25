using Core.Map;
using DataAccess.Entity;

namespace DataAccess.Map
{
    public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.SubCategoryName).IsRequired().HasMaxLength(255);
            Property(x => x.Description).IsOptional().HasMaxLength(255);
        }
    }
}
