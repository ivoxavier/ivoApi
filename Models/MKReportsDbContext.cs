using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ivoApi.Models;

public partial class MKReportsDbContext : DbContext
{
    public MKReportsDbContext(DbContextOptions<MKReportsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConsultorasParada> ConsultorasParadas { get; set; }

    public virtual DbSet<TbConfigApp> TbConfigApps { get; set; }

    public virtual DbSet<TbConfigUtilizador> TbConfigUtilizadors { get; set; }

    public virtual DbSet<TbConsultora> TbConsultoras { get; set; }

    public virtual DbSet<TbEscadaSucesso> TbEscadaSucessos { get; set; }

    public virtual DbSet<TbMonthSalesConsultant> TbMonthSalesConsultants { get; set; }

    public virtual DbSet<TbMonthSalesSale> TbMonthSalesSales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ConsultorasParada>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ConsultorasParadas");
        });

        modelBuilder.Entity<TbConfigApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_Config_App");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PathIn).HasMaxLength(80);
            entity.Property(e => e.PathOut).HasMaxLength(80);
            entity.Property(e => e.ReportName).HasMaxLength(45);
        });

        modelBuilder.Entity<TbConfigUtilizador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_Config_Utilizador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CConsultora).HasColumnName("C_Consultora");
            entity.Property(e => e.CDiretoraIndependente).HasColumnName("C_DiretoraIndependente");
            entity.Property(e => e.CDiretoraNacional).HasColumnName("C_DiretoraNacional");
            entity.Property(e => e.CLiderEquipa).HasColumnName("C_LiderEquipa");
            entity.Property(e => e.CNome)
                .HasMaxLength(45)
                .HasColumnName("C_Nome");
            entity.Property(e => e.CNumero).HasColumnName("C_Numero");
            entity.Property(e => e.CUnidade).HasColumnName("C_Unidade");
        });

        modelBuilder.Entity<TbConsultora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_Consultoras");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConsultoraEmail).HasMaxLength(50);
            entity.Property(e => e.ConsultoraNome).HasMaxLength(50);
            entity.Property(e => e.ConsultoraRecrutadoraNome).HasMaxLength(50);
            entity.Property(e => e.ConsultoraTelefone).HasMaxLength(50);
            entity.Property(e => e.RecrutadoraNum).HasMaxLength(45);
        });

        modelBuilder.Entity<TbEscadaSucesso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_EscadaSucesso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataInsertDb)
                .HasMaxLength(45)
                .HasColumnName("DataInsertDB");
            entity.Property(e => e.EscadaSucessoDataExtracao).HasColumnName("EscadaSucesso_DataExtracao");
            entity.Property(e => e.EscadaSucessoNivelCarreira)
                .HasMaxLength(50)
                .HasColumnName("EscadaSucesso_NivelCarreira");
            entity.Property(e => e.EscadaSucessoNivelConseguido).HasColumnName("EscadaSucesso_NivelConseguido");
            entity.Property(e => e.EscadaSucessoNomeConsultora)
                .HasMaxLength(50)
                .HasColumnName("EscadaSucesso_NomeConsultora");
            entity.Property(e => e.EscadaSucessoNumConsultora).HasColumnName("EscadaSucesso_NumConsultora");
            entity.Property(e => e.EscadaSucessoPrecisaParaNivelSeguinte).HasColumnName("EscadaSucesso_PrecisaParaNivelSeguinte");
            entity.Property(e => e.EscadaSucessoTotalNovasConsultoras).HasColumnName("EscadaSucesso_TotalNovasConsultoras");
            entity.Property(e => e.EscadaSucessoTotalNovasConsultorasQualificadas).HasColumnName("EscadaSucesso_TotalNovasConsultorasQualificadas");
            entity.Property(e => e.EscadaSucessoTotalPrograma).HasColumnName("EscadaSucesso_TotalPrograma");
            entity.Property(e => e.EscadaSucessoTrimestre)
                .HasMaxLength(45)
                .HasColumnName("EscadaSucesso_Trimestre");
        });

        modelBuilder.Entity<TbMonthSalesConsultant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_Month_Sales_Consultant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Filial).HasMaxLength(10);
            entity.Property(e => e.Nivel).HasMaxLength(45);
            entity.Property(e => e.Nome).HasMaxLength(45);
            entity.Property(e => e.RecrutadoraNum).HasMaxLength(45);
            entity.Property(e => e.Status).HasMaxLength(45);
        });

        modelBuilder.Entity<TbMonthSalesSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TB_Month_Sales_Sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MesVenda).HasMaxLength(45);
            entity.Property(e => e.ValorVenda).HasPrecision(10, 2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
