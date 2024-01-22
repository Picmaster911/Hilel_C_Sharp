﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using plc_wpf.Model;

#nullable disable

namespace plc_wpf.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240119111034_AddCascade")]
    partial class AddCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("plc_wpf.Model.PLC_Conection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlcName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlcType")
                        .HasColumnType("int");

                    b.Property<int>("Rack")
                        .HasColumnType("int");

                    b.Property<int>("Slot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plc_Conections");
                });

            modelBuilder.Entity("plc_wpf.Model.TagsForPlc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("BitAdr")
                        .HasColumnType("tinyint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DB")
                        .HasColumnType("int");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<int>("PLC_ConectionId")
                        .HasColumnType("int");

                    b.Property<int>("StartByteAdr")
                        .HasColumnType("int");

                    b.Property<int>("VarType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PLC_ConectionId");

                    b.ToTable("Pls_Tags");
                });

            modelBuilder.Entity("plc_wpf.Model.TagsForPlc", b =>
                {
                    b.HasOne("plc_wpf.Model.PLC_Conection", null)
                        .WithMany("PlcTags")
                        .HasForeignKey("PLC_ConectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("plc_wpf.Model.PLC_Conection", b =>
                {
                    b.Navigation("PlcTags");
                });
#pragma warning restore 612, 618
        }
    }
}