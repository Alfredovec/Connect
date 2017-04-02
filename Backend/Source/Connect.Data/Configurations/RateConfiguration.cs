using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class RateConfiguration : EntityTypeConfiguration<RateEntity>
    {
        public RateConfiguration()
        {
            ToTable("Rate");
            HasKey(r => r.Id);
        }
    }
}
