using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSDb
{
    public class Reestr
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReeestrId {get;set;}

        public int Priority { get; set; }

        [Required]
        public string Url { get; set; }

        public int Depth { get; set; }
    }
}
