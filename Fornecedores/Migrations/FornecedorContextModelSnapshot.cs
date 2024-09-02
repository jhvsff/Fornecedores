﻿// <auto-generated />
using Fornecedores.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fornecedores.Migrations;

[DbContext(typeof(FornecedorContext))]
partial class FornecedorContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("Fornecedores.Models.Fornecedor", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Fornecedores");
            });
#pragma warning restore 612, 618
    }
}