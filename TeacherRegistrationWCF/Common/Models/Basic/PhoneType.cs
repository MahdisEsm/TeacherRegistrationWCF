using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class PhoneType : ObjectModel<short>
    {
        public string Name { get; set; }
        public virtual ICollection<Phone> PhoneType_Phone_List { get; set; }

    }
    public class PhoneTypeConfiguration : EntityTypeConfiguration<PhoneType>
    {
        public PhoneTypeConfiguration()
        {
            ToTable("PhoneType", "Basic");
            HasMany(m => m.PhoneType_Phone_List)
                .WithRequired(m => m.Phone_PhoneType)
                .HasForeignKey(m => m.PhoneTypeID)
                .WillCascadeOnDelete(false);
        }
    }
}
