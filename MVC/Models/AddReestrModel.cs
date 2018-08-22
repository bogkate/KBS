using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC.Models
{
    [DataContract]
    public class AddReestrModel
    {
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