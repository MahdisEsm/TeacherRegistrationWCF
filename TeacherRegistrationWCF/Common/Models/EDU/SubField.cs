using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EDU
{
    public class SubField:ObjectModel<int>
    {
        public string Name { get; set; }
        public int FieldID { get; set; }
        public virtual Field SubField_Field { get; set; }
        public virtual ICollection<Degree> SubField_Degree_List { get; set; }
    }
    public class SubFieldConfiguration : EntityTypeConfiguration<SubField>
    {
        public SubFieldConfiguration()
        {
            ToTable("SubField", "EDU");

            HasRequired(m => m.SubField_Field)
               .WithMany(m => m.Field_SubField_List)
               .HasForeignKey(m => m.FieldID)
               .WillCascadeOnDelete(false);

        }
    }
}
