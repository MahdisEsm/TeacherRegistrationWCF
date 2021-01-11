using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EDU
{
    public class Field:ObjectModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Degree> Field_Degree_List { get; set; }
        public virtual ICollection<SubField> Field_SubField_List { get; set; }

    }
    public class FieldConfiguration : EntityTypeConfiguration<Field>
    {
        public FieldConfiguration()
        {
            ToTable("Field", "EDU");
          
        }
    }
}
