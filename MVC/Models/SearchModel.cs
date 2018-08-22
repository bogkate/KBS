using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC.Models
{
    [DataContract]
    public class SearchModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

    }
}