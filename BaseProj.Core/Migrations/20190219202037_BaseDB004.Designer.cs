﻿// <auto-generated />
using System;
using BaseProj.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseProj.Core.Migrations
{
    [DbContext(typeof(BaseProjContext))]
    [Migration("20190219202037_BaseDB004")]
    partial class BaseDB004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseProj.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account");

                    b.Property<string>("Agency");

                    b.Property<string>("Bank");

                    b.Property<string>("BenefitNumber");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CPF");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Observation");

                    b.Property<string>("Op");

                    b.Property<string>("Phone");

                    b.Property<string>("PortalPassword");

                    b.Property<string>("RG");

                    b.Property<string>("Registration");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BaseProj.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
