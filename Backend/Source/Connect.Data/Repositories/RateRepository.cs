using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.Data.Entities;
using Connect.Data.Repositories.Interfaces;

namespace Connect.Data.Repositories
{
    public class RateRepository : Repository<RateEntity>, IRateRepository
    {
        /// <inheritdoc />
        public RateRepository(ConnectDbContext context) : base(context)
        {
        }
    }
}
