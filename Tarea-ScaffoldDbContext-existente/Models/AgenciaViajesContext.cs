using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class AgenciaViajesContext : DbContext
{
    public AgenciaViajesContext()
    {
    }

    public AgenciaViajesContext(DbContextOptions<AgenciaViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<Avione> Aviones { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Paquetesturistico> Paquetesturisticos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=agencia_viajes;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.HasKey(e => e.AerolineaId).HasName("PRIMARY");

            entity.ToTable("aerolineas");

            entity.Property(e => e.AerolineaId).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Avione>(entity =>
        {
            entity.HasKey(e => e.AvionId).HasName("PRIMARY");

            entity.ToTable("aviones");

            entity.Property(e => e.AvionId).HasColumnType("int(11)");
            entity.Property(e => e.Capacidad).HasColumnType("int(11)");
            entity.Property(e => e.Modelo).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.ClienteId).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.DestinoId).HasName("PRIMARY");

            entity.ToTable("destinos");

            entity.Property(e => e.DestinoId).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Pais).HasMaxLength(50);
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.EscalaId).HasName("PRIMARY");

            entity.ToTable("escalas");

            entity.HasIndex(e => e.DestinoId, "DestinoId");

            entity.HasIndex(e => e.VueloId, "VueloId");

            entity.Property(e => e.EscalaId).HasColumnType("int(11)");
            entity.Property(e => e.DestinoId).HasColumnType("int(11)");
            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.VueloId).HasColumnType("int(11)");

            entity.HasOne(d => d.Destino).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.DestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("escalas_ibfk_2");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.VueloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("escalas_ibfk_1");
        });

        modelBuilder.Entity<Paquetesturistico>(entity =>
        {
            entity.HasKey(e => e.PaqueteTuristicoId).HasName("PRIMARY");

            entity.ToTable("paquetesturisticos");

            entity.Property(e => e.PaqueteTuristicoId).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.PermisoId).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.HasIndex(e => e.RolId, "RolId");

            entity.Property(e => e.PermisoId).HasColumnType("int(11)");
            entity.Property(e => e.Modulo).HasMaxLength(50);
            entity.Property(e => e.RolId).HasColumnType("int(11)");

            entity.HasOne(d => d.Rol).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permisos_ibfk_1");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.PilotoId).HasName("PRIMARY");

            entity.ToTable("pilotos");

            entity.Property(e => e.PilotoId).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Licencia).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.ClienteId, "ClienteId");

            entity.Property(e => e.ReservaId).HasColumnType("int(11)");
            entity.Property(e => e.ClienteId).HasColumnType("int(11)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservas_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RolId).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.RolId, "RolId");

            entity.Property(e => e.UsuarioId).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(128);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.NumeroCedula).HasMaxLength(20);
            entity.Property(e => e.NumeroCelular).HasMaxLength(20);
            entity.Property(e => e.RolId).HasColumnType("int(11)");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.VueloId).HasName("PRIMARY");

            entity.ToTable("vuelos");

            entity.HasIndex(e => e.AerolineaId, "AerolineaId");

            entity.HasIndex(e => e.AvionId, "AvionId");

            entity.HasIndex(e => e.PilotoId, "PilotoId");

            entity.Property(e => e.VueloId).HasColumnType("int(11)");
            entity.Property(e => e.AerolineaId).HasColumnType("int(11)");
            entity.Property(e => e.AvionId).HasColumnType("int(11)");
            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.PilotoId).HasColumnType("int(11)");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.AerolineaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_ibfk_1");

            entity.HasOne(d => d.Avion).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.AvionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_ibfk_2");

            entity.HasOne(d => d.Piloto).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.PilotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vuelos_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
