using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class Email:Common.Models.ObjectModel<long>
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Email", ResourceType = typeof(SrtingResources.TextResources))]
        [MaxLength(200, ErrorMessageResourceName = "MaxErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        public string Name { get; set; }
        public long PersonID { get; set; }
        public virtual Person Email_Person { get; set; }
        public short EmailTypeID { get; set; }
        public virtual EmailType Email_EmailType { get; set; }
        public bool IsFinalized { get; set; }
        public Email()
        {
            IsFinalized = false;
        }

    }
    public class EmailConfiguration : EntityTypeConfiguration<Email>
    {
        public EmailConfiguration()
        {
            ToTable("Email", "Basic");
                
            HasRequired(m => m.Email_Person)
                .WithMany(m => m.Person_Email_List)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

            HasIndex(m => m.Name)
                .IsUnique()
                .HasName("UK_Email_Name");
        }
    }
}
