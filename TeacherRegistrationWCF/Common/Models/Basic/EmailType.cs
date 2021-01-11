using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class EmailType:Common.Models.ObjectModel<short>
    {
        public string Name { get; set; }
        public virtual ICollection<Email> EmailType_Email_List { get; set; }
    }
    public class EmailTypeConfiguration : EntityTypeConfiguration<EmailType>
    {
        public EmailTypeConfiguration()
        {
            ToTable("EmailType", "Basic");
            HasMany(m => m.EmailType_Email_List)
                .WithRequired(m => m.Email_EmailType)
                .HasForeignKey(m => m.EmailTypeID)
                .WillCascadeOnDelete(false);


        }
    }
}
