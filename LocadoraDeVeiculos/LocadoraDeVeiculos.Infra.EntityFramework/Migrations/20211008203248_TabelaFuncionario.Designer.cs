﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.EntityFramework.Migrations
{
    [DbContext(typeof(LocadoraDeVeiculosDBContext))]
    [Migration("20211008203248_TabelaFuncionario")]
    partial class TabelaFuncionario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("EhDescontoFixo")
                        .HasColumnType("BIT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("ParceiroId")
                        .HasColumnType("INT");

                    b.Property<int>("QtdUtilizada")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATE");

                    b.Property<double>("Valor")
                        .HasColumnType("FLOAT");

                    b.Property<double>("ValorMinimo")
                        .HasColumnType("FLOAT");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCUPOM_DESCONTO");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.FuncionarioModule.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("DATE");

                    b.Property<bool>("EhPessoaFisica")
                        .HasColumnType("BIT");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Endereco")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("MatriculaInterna")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("RegistroUnico")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<double>("Salario")
                        .HasColumnType("FLOAT");

                    b.Property<string>("Senha")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("UsuarioAcesso")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBFUNCIONARIO");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBPARCEIRO");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.CupomModule.Cupom", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", "Parceiro")
                        .WithMany("Cupons")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ParceiroModule.Parceiro", b =>
                {
                    b.Navigation("Cupons");
                });
#pragma warning restore 612, 618
        }
    }
}
