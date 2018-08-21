using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSDb
{
    public class Crower
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CrowerId { get; set; }

        public virtual Reestr Reestr { get; set; }

        public bool Status { get; set; }

        public long CountIndex { get; set; }

        public virtual IEnumerable<Index> Indexes { get; } = new List<Index>();

    }
}
