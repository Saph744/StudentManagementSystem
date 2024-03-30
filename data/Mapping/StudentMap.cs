using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using schoolmanagement.Domain.Models;

namespace schoolmanagement.data.Mapping
{
    public class StudentMap:IEntityTypeConfiguration<student>
    {
        void IEntityTypeConfiguration<student>.Configure(EntityTypeBuilder<student> builder)
        {
            builder.HasKey(pr => pr.StudentID);
            object value = builder.Property(m => m.StudentID).ValueGeneratedOnAdd();
        }
    }
}
