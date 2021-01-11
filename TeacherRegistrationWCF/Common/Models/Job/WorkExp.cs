using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Job
{
    public class WorkExp : ObjectModel<long>
    {
        public long PersonID { get; set; }
        public virtual Person WorkExp_Person { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "CompanyName", ResourceType = typeof(SrtingResources.TextResources))]
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "CompanyAddress", ResourceType = typeof(SrtingResources.TextResources))]
        public string CompanyAddress { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "CompanyPhone", ResourceType = typeof(SrtingResources.TextResources))]
        public string CompanyPhone { get; set; }
        public string Manager { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Position", ResourceType = typeof(SrtingResources.TextResources))]
        public string Position { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Duties", ResourceType = typeof(SrtingResources.TextResources))]
        public string Duties { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "FromDate", ResourceType = typeof(SrtingResources.TextResources))]
        public string FromDate { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "ToDate", ResourceType = typeof(SrtingResources.TextResources))]
        public string ToDate { get; set; }
        public bool IsFinalized { get; set; }
        public WorkExp()
        {
            IsFinalized = false;
        }


    }
    public class WorkExpConfiguration : EntityTypeConfiguration<WorkExp>
    {
        public WorkExpConfiguration()
        {
            ToTable("WorkExp", "Job");

            HasRequired(m => m.WorkExp_Person)
                .WithMany(m => m.Person_WorkExp_List)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

        }
    }
}
