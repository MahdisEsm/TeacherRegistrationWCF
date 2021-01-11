using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common.Models
{
    public abstract class ObjectModel<TKey> where TKey:struct
    {
        public TKey ID { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Description",ResourceType =typeof(Common.SrtingResources.TextResources))]
        [System.ComponentModel.DataAnnotations.MaxLength(250, ErrorMessageResourceName = "MaxErrorMessage",ErrorMessageResourceType =typeof(Common.SrtingResources.TextResources))]

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public ObjectModel()
        {
            CreationDate = DateTime.Now;
            IsActive = true;
        }


    }
}
