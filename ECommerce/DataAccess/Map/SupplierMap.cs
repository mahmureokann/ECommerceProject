using Core.Map;
using DataAccess.Entity;

namespace DataAccess.Map
{
    public class SupplierMap:CoreMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("dbo.Suppliers");
            Property(x => x.CompanyName).IsRequired().HasMaxLength(255);
            Property(x => x.Address).IsOptional().HasMaxLength(500);
           
        }
    }
}
