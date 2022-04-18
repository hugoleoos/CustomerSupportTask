using Arvato.DBAdapter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arvato.DBAdapter.Mappings
{
    public class CustumerSupportsMapp : IEntityTypeConfiguration<CustomerSupport>
    {
        public void Configure(EntityTypeBuilder<CustomerSupport> builder)
        {
            //Table
            builder.ToTable("CustomerSupport");

            //Primary Key
            builder.HasKey(x => x.Id);

            //Identity  
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //email Property
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);


            //First Name Property
            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            //First Name Property
            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            //Phone Property
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            //Number Property
            builder.Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            //Inquiry Property
            builder.Property(x => x.Inquiry)
                .IsRequired()
                .HasColumnName("Inquiry")
                .HasColumnType("INT");

            //Description Property
            builder.Property(x => x.DescriptionSupport)
                .IsRequired()
                .HasColumnName("DescriptionSupport")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(4000);

            //Description Property
            builder.Property(x => x.Aggreement)
                .IsRequired()
                .HasColumnName("Aggreement")
                .HasColumnType("BIT");
        }
    }
}
