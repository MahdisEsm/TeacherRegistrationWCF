using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class Religion:ObjectModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Person> Religion_Person_List { get; set; }

    }
    public class ReligionConfiguration : EntityTypeConfiguration<Religion>
    {
        public ReligionConfiguration()
        {
            ToTable("Religion", "Basic");
            HasMany(m => m.Religion_Person_List)
                .WithRequired(m => m.Person_Religion)
                .HasForeignKey(m => m.ReligionID)
                .WillCascadeOnDelete(false);
        }
    }
}
