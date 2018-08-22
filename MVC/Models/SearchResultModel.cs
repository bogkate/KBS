using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC.Models
{
    [DataContract]
    public class SearchResultModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        [Display(Name = "Url")]
        public string Url { get; set; }

    }
}