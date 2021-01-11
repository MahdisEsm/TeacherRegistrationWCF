using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.TCH
{
    public class SematecCourse:ObjectModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<FavoriteCourse> SematecCourse_FavoriteCourse_List { get; set; }
    }
    public class SematecCourseConfiguration : EntityTypeConfiguration<SematecCourse>
    {
        public SematecCourseConfiguration()
        {
            ToTable("SematecCourse", "TCH");
            
        }
    }
}
