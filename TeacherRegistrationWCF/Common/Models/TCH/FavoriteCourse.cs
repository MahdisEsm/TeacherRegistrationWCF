using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.TCH
{
    public class FavoriteCourse:ObjectModel<int>
    {
        [Index("IX_Person_SematecCourse", 1, IsUnique = true)]
        public long PersonID { get; set; }
        public virtual Person FavoriteCourse_Person { get; set; }
        [Index("IX_Person_SematecCourse", 2, IsUnique = true)]
        public int SematecCourseID { get; set; }
        public virtual SematecCourse FavoriteCourse_SematecCourse { get; set; }
        public bool IsFinalized { get; set; }
        public FavoriteCourse()
        {
            IsFinalized = false;
        }

    }
    public class FavoriteCourseConfiguration : EntityTypeConfiguration<FavoriteCourse>
    {
        public FavoriteCourseConfiguration()
        {
            ToTable("FavoriteCourse", "TCH");

            HasRequired(m => m.FavoriteCourse_Person)
                .WithMany(m => m.Person_FavoriteCourse_List)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.FavoriteCourse_SematecCourse)
               .WithMany(m => m.SematecCourse_FavoriteCourse_List)
               .HasForeignKey(m => m.SematecCourseID)
               .WillCascadeOnDelete(false);
      

        }
    }
}
