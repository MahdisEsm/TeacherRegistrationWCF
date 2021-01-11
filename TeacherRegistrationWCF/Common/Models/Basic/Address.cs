using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Basic
{
    public class Address:ObjectModel<long>
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SrtingResources.TextResources))]
        [Display(Name = "Location", ResourceType = typeof(SrtingResources.TextResources))]
        public string Location { get; set; }
        public long PersonID { get; set; }
        public virtual Person Address_Person { get; set; }
        public long CityID { get; set; }
        public virtual City Address_City { get; set; }
        public short AddressTypeID { get; set; }
        public virtual AddressType Address_AddressType { get; set; }
        public bool IsFinalized { get; set; }
        public Address()
        {
            IsFinalized = false;
        }

    }
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Address", "Basic");


        }
    }
}
