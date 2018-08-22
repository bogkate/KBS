using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSDb
{
    public class Storage: DbContext
    {
        public Storage(string connectionString)
            : base(connectionString)
        {
        }

        public Storage() : base("Storage")
        {

        }
        public DbSet<Index> Index { get; set; }
        public DbSet<Reestr> Reestr { get; set; }
        public DbSet<Crower> Crower { get; set; }
    }
}
