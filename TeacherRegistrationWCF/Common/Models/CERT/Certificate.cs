using Common.Models.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.CERT
{
    public class Certificate:ObjectModel<long>
    {
        public long PersonID { get; set; }
        public virtual Person Certificate_Person { get; set; }
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "CertificateName", ResourceType = typeof(SrtingResources.TextResources))]
        public string Name { get; set; }
        public string Date { get; set; }
        public string Institude { get; set; }
        public bool IsAvailable { get; set; }
        public string OnlineLink { get; set; }
        public int CountryID { get; set; }
        public virtual Country Certificate_Country { get; set; }
        public byte[] CertPic { get; set; }
        public bool HasPaper { get; set; }
        public bool IsFinalized { get; set; }
        public Certificate()
        {
            IsFinalized = false;
        }
    }

    public class CertificateConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Certificate>
    {
        public CertificateConfiguration()
        {
            ToTable("Certificate", "CERT");

            HasRequired(m => m.Certificate_Person)
                .WithMany(m => m.Person_Certificate_List)
                .HasForeignKey(m => m.PersonID)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.Certificate_Country)
                .WithMany(m => m.Country_Certificate_List)
                .HasForeignKey(m => m.CountryID)
                .WillCascadeOnDelete(false);

        }

    }
}
