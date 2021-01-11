using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class Phone:ObjectModel<long>
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(SrtingResources.TextResources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        public string Number { get; set; }
        public short PhoneTypeID { get; set; }
        public long PersonID { get; set; }
        public virtual PhoneType Phone_PhoneType { get; set; }
        public virtual Person Phone_Person { get; set; }
        public bool IsFinalized { get; set; }
        public Phone()
        {
            IsFinalized = false;
        }
    }
    public class PhoneConfiguration : EntityTypeConfiguration<Phone>
    {
        public PhoneConfiguration()
        {
            ToTable("Phone", "Basic");



            HasIndex(m => m.Number)
                .IsUnique()
                .HasName("UK_Phone_Number");


        }
    }
}
