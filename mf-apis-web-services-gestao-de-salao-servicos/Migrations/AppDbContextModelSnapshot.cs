﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mf_apis_web_services_gestao_de_salao_servicos.Models;

#nullable disable

namespace mf_apis_web_services_gestao_de_salao_servicos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.LinkDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metodo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicoCategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicoSubCategoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicoCategoriaId");

                    b.HasIndex("ServicoSubCategoriaId");

                    b.ToTable("LinkDto");
                });

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

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoUsuarios", b =>
                {
                    b.Property<int>("ServicoCategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ServicoCategoriaId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ServicoUsuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.LinkDto", b =>
                {
                    b.HasOne("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", null)
                        .WithMany("Links")
                        .HasForeignKey("ServicoCategoriaId");

                    b.HasOne("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoSubCategoria", null)
                        .WithMany("Links")
                        .HasForeignKey("ServicoSubCategoriaId");
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

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoUsuarios", b =>
                {
                    b.HasOne("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", "ServicoCategoria")
                        .WithMany("Usuarios")
                        .HasForeignKey("ServicoCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mf_apis_web_services_gestao_de_salao_servicos.Models.Usuario", "Usuario")
                        .WithMany("Servicos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicoCategoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoCategoria", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("ServicoSubCategorias");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.ServicoSubCategoria", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("mf_apis_web_services_gestao_de_salao_servicos.Models.Usuario", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
