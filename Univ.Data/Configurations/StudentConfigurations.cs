using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univ.Core.Entities;

namespace Univ.Data.Configurations
{
    public class StudentConfigurations:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Fullname).IsRequired(true).HasMaxLength(35);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
            builder.HasOne(x => x.Group).WithMany(g => g.Students).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
