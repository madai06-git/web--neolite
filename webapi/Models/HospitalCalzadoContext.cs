using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class HospitalCalzadoContext : DbContext
{
    public HospitalCalzadoContext()
    {
    }

    public HospitalCalzadoContext(DbContextOptions<HospitalCalzadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<CategoriasServicio> CategoriasServicios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleReparacion> DetalleReparacions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FacturasPago> FacturasPagos { get; set; }

    public virtual DbSet<HistorialReparacione> HistorialReparaciones { get; set; }

    public virtual DbSet<HorariosTrabajo> HorariosTrabajos { get; set; }

    public virtual DbSet<InventarioMateriale> InventarioMateriales { get; set; }

    public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\MSSQL;Database=Hospital_Calzado;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.ArticuloId).HasName("PK__Articulo__C0D7258DB66C8A8E");

            entity.Property(e => e.ArticuloId)
                .ValueGeneratedNever()
                .HasColumnName("ArticuloID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.OtrosDetalles).HasMaxLength(255);
            entity.Property(e => e.TipoArticulo).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoriasServicio>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5714990E3");

            entity.Property(e => e.CategoriaId)
                .ValueGeneratedNever()
                .HasColumnName("CategoriaID");
            entity.Property(e => e.Fecha).HasMaxLength(50);
            entity.Property(e => e.NombreCategoria).HasMaxLength(50);
            entity.Property(e => e.NumeroNota)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7128231C5");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<DetalleReparacion>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleR__6E19D6FA852C0E66");

            entity.ToTable("DetalleReparacion");

            entity.Property(e => e.DetalleId)
                .ValueGeneratedNever()
                .HasColumnName("DetalleID");
            entity.Property(e => e.CostoEstimado).HasColumnType("money");
            entity.Property(e => e.DescripcionProblema).HasMaxLength(255);
            entity.Property(e => e.MaterialesNecesarios).HasMaxLength(255);
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

            entity.HasOne(d => d.Orden).WithMany(p => p.DetalleReparacions)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__DetalleRe__Orden__4D94879B");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F07A93B0EA");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Comision).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Contacto).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        modelBuilder.Entity<FacturasPago>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805E123BD1F");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("FacturaID");
            entity.Property(e => e.FechaFacturacion).HasColumnType("date");
            entity.Property(e => e.MontoTotal).HasColumnType("money");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

            entity.HasOne(d => d.Orden).WithMany(p => p.FacturasPagos)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__FacturasP__Orden__52593CB8");
        });

        modelBuilder.Entity<HistorialReparacione>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EFD32FDC2F");

            entity.Property(e => e.HistorialId)
                .ValueGeneratedNever()
                .HasColumnName("HistorialID");
            entity.Property(e => e.DetalleId).HasColumnName("DetalleID");
            entity.Property(e => e.FechaReparacion).HasColumnType("date");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

            entity.HasOne(d => d.Detalle).WithMany(p => p.HistorialReparaciones)
                .HasForeignKey(d => d.DetalleId)
                .HasConstraintName("FK__Historial__Detal__4F7CD00D");

            entity.HasOne(d => d.Orden).WithMany(p => p.HistorialReparaciones)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__Historial__Orden__4E88ABD4");
        });

        modelBuilder.Entity<HorariosTrabajo>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__Horarios__BB881A9E208D5ABE");

            entity.ToTable("HorariosTrabajo");

            entity.Property(e => e.HorarioId)
                .ValueGeneratedNever()
                .HasColumnName("HorarioID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.Empleado).WithMany(p => p.HorariosTrabajos)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__HorariosT__Emple__5165187F");
        });

        modelBuilder.Entity<InventarioMateriale>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Inventar__C50613173181FA43");

            entity.Property(e => e.MaterialId)
                .ValueGeneratedNever()
                .HasColumnName("MaterialID");
            entity.Property(e => e.NombreMaterial).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("money");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.InventarioMateriales)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__Inventari__Prove__5070F446");
        });

        modelBuilder.Entity<OrdenesTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenesT__C088A4E4DFC416B0");

            entity.ToTable("OrdenesTrabajo");

            entity.Property(e => e.OrdenId)
                .ValueGeneratedNever()
                .HasColumnName("OrdenID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaEntregaEstimada).HasColumnType("date");
            entity.Property(e => e.FechaSolicitud).HasColumnType("date");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__OrdenesTr__Clien__4CA06362");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB958F1B9CF");

            entity.Property(e => e.ProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("ProveedorID");
            entity.Property(e => e.Contacto).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PK__Puestos__F7F6C624B96698A3");

            entity.Property(e => e.PuestoId)
                .ValueGeneratedNever()
                .HasColumnName("PuestoID");
            entity.Property(e => e.Comision).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
