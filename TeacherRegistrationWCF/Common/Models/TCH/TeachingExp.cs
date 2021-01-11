using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.TCH
{
    public class TeachingExp:ObjectModel<long>
    {
        public long PersonID { get; set; }
        public virtual Person TeachingExp_Person { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Institude", ResourceType = typeof(SrtingResources.TextResources))]
        public string Institude { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Hours", ResourceType = typeof(SrtingResources.TextResources))]
        public int Hours { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "FromDate", ResourceType = typeof(SrtingResources.TextResources))]
        public string FromDate { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "ToDate", ResourceType = typeof(SrtingResources.TextResources))]
        public string ToDate { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "CourseNames", ResourceType = typeof(SrtingResources.TextResources))]
        public string CourseNames { get; set; }
        public bool IsFinalized { get; set; }
        public TeachingExp()
        {
            IsFinalized = false;
        }
    }
    public class TeachingExpConfiguration : EntityTypeConfiguration<TeachingExp>
    {
        public TeachingExpConfiguration()
        {
            ToTable("TeachingExp", "TCH");

            HasRequired(m => m.TeachingExp_Person)
                .WithMany(m => m.Person_TeachingExp_List)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

        }
    }
}
