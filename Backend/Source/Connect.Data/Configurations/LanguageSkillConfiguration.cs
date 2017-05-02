﻿using System;
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

            HasOptional(l => l.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(false);

            HasOptional(l => l.UserWished)
                .WithMany(u => u.SkillsWished)
                .HasForeignKey(l => l.UserWishedId)
                .WillCascadeOnDelete(false);
        }
    }
}
