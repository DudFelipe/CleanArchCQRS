﻿using CleanArchCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchCQRS.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();

            builder.HasData(
                new Member(1, "Janis", "Joplin", "feminino", "janis@email.com", true),
                new Member(2, "Elvis", "Presley", "masculino", "elvis@email.com", true)
            );
        }
    }
}
