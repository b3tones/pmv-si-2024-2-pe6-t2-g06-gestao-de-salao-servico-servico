﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mf_apis_web_services_gestao_de_salao_servicos.Models;

#nullable disable

namespace mf_apis_web_services_gestao_de_salao_servicos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240918012004_M00")]
    partial class M00
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ServicoCategorias");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoSubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ServicoCategoriaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ServicoCategoriaId");

                    b.ToTable("ServicoSubCategorias");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoSubCategoria", b =>
                {
                    b.HasOne("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", "ServicoCategoria")
                        .WithMany("ServicoSubCategorias")
                        .HasForeignKey("ServicoCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicoCategoria");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", b =>
                {
                    b.Navigation("ServicoSubCategorias");
                });
#pragma warning restore 612, 618
        }
    }
}
