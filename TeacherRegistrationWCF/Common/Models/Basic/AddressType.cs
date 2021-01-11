using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class AddressType:Common.Models.ObjectModel<short>
    {
        public string Name { get; set; }
        public virtual ICollection<Address> AddressType_Address_list { get; set; }
    }
    public class AddressTypeConfiguration : EntityTypeConfiguration<AddressType>
    {
        public AddressTypeConfiguration()
        {
            ToTable("AddressType", "Basic");
            HasMany(m => m.AddressType_Address_list)
                .WithRequired(m => m.Address_AddressType)
                .HasForeignKey(m => m.AddressTypeID)
                .WillCascadeOnDelete(false);
        }
    }
}
