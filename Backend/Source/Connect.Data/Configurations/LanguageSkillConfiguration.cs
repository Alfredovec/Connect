using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.Data.Entities;

namespace Connect.Data.Configurations
{
    class LanguageSkillConfiguration : EntityTypeConfiguration<LanguageSkillEntity>
    {
        public LanguageSkillConfiguration()
        {
            ToTable("LanguageSkill");

            Property(l => l.Level).IsRequired();

            HasRequired(l => l.Language)
                .WithMany()
                .HasForeignKey(l => l.LanguageId)
                .WillCascadeOnDelete(false);

            HasRequired(l => l.User)
                .WithMany(u => u.Languages)
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(false);

        }
    }
}
