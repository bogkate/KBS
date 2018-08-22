using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC.Models
{
    [DataContract]
    public class ReestrModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        [Display(Name = "ID")]
        public long ReestrId { get; set; }

        [DataMember(IsRequired = true)]
        [Required]
        [Display(Name = "Url")]
        public string Url { get; set; }

        [DataMember(IsRequired = true)]
        [Required]
        [Display(Name = "Depth")]
        public int Depth { get; set; }
    }
}