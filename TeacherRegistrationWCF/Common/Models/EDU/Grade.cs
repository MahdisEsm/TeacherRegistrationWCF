using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EDU
{
    public class Grade:ObjectModel<short>
    {
        public string Name { get; set; }
        public virtual ICollection<Degree> Grade_Degree_List { get; set; }
    }
    public class GradeConfiguration:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Grade>
    {
        public GradeConfiguration()
        {
            ToTable("Grade", "EDU");
        }
   
    }
        
}
