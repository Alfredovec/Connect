using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Data
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext(string connectionString) : base(connectionString) { }

        
    }
}
