// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlOwnedIdentityColumn;

#nullable disable

namespace NpgsqlOwnedIdentityColumn.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20221101210501_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NpgsqlOwnedIdentityColumn.OwningEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("OwningEntities");
                });

            modelBuilder.Entity("NpgsqlOwnedIdentityColumn.OwningEntity", b =>
                {
                    b.OwnsOne("NpgsqlOwnedIdentityColumn.OwnedEntity", "Owned", b1 =>
                        {
                            b1.Property<int>("OwningEntityId")
                                .HasColumnType("integer");

                            b1.Property<int>("ThisShouldBeIdentity")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b1.Property<int>("ThisShouldBeIdentity"));

                            b1.HasKey("OwningEntityId");

                            b1.ToTable("OwningEntities");

                            b1.WithOwner()
                                .HasForeignKey("OwningEntityId");
                        });

                    b.Navigation("Owned")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
