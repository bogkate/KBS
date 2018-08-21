using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSDb
{
    public class Index
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IndexId { get; set; }

        public string Text { get; set; }

        public virtual Reestr Reestr { get; set; }

        public long Count { get; set; }
    }
}
