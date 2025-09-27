﻿using Domain.Entities;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Administrador> Administadores => Set<Administrador>();
        public DbSet<ExAlumno> ExAlumnos => Set<ExAlumno>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Emprendimiento> Emprendimientos => Set<Emprendimiento>();
        public DbSet<Estudio> Estudios => Set<Estudio>();
        public DbSet<Evento> Eventos => Set<Evento>();
        public DbSet<OfertaLaboral> OfertasLaborales => Set<OfertaLaboral>();
        public DbSet<Publicacion> Publicaciones => Set<Publicacion>();
        public DbSet<Respuesta> Respuestas => Set<Respuesta>();
        public DbSet<Servicio> Servicios => Set<Servicio>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(b =>
            {
                b.ToTable("Usuarios");
                b.HasKey(u => u.Id);

                b.Property(u => u.Nombre).IsRequired().HasMaxLength(50);
                b.Property(u => u.Email).IsRequired().HasMaxLength(255);
                b.Property(u => u.Contrasena).IsRequired().HasMaxLength(255);

                b.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<ExAlumno>().ToTable("ExAlumnos");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            modelBuilder.Entity<Empresa>().ToTable("Empresas");

            modelBuilder.Entity<Administrador>(builder =>
            {

                builder.Property(a => a.Apellido)
                       .IsRequired()
                       .HasMaxLength(50);

            });


            modelBuilder.Entity<ExAlumno>(builder =>
            {


                builder.Property(a => a.Apellido)
                       .IsRequired()
                       .HasMaxLength(50);


                builder.HasMany(a => a.Estudios)
                    .WithMany(e => e.ExAlumnos)
                    .UsingEntity(j => j.ToTable("ExAlumnoEstudio"));

                builder.HasOne(a => a.Categoria)
                       .WithMany()
                       .HasForeignKey(a => a.CategoriaId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.SetNull);

            });

            modelBuilder.Entity<Empresa>(builder =>
            {

                builder.Property(a => a.Telefono)
                       .IsRequired()
                       .HasMaxLength(15);

                builder.Property(a => a.Direccion)
                     .IsRequired()
                     .HasMaxLength(100);

            });

            modelBuilder.Entity<Evento>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Titulo)
                           .IsRequired()
                           .HasMaxLength(50);

                builder.Property(a => a.Descripcion)
                           .IsRequired()
                           .HasMaxLength(1000);

                builder.Property(a => a.Ubicacion)
                         .IsRequired()
                         .HasMaxLength(100);

                builder.HasOne(a => a.Administrador)
                        .WithMany()
                        .HasForeignKey(a => a.AdministradorId)
                        .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<Publicacion>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Titulo)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(a => a.Texto)
                       .IsRequired()
                       .HasMaxLength(1000);

            });


            modelBuilder.Entity<Respuesta>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Texto)
                       .IsRequired()
                       .HasMaxLength(1000);

                builder.HasOne(a => a.Publicacion)
                     .WithMany()
                     .HasForeignKey(a => a.PublicacionId)
                     .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Servicio>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Nombre)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(a => a.Descripcion)
                       .IsRequired()
                       .HasMaxLength(1000);

                builder.HasOne(a => a.Emprendimiento)
                        .WithMany()
                        .HasForeignKey(a => a.EmprendimientoId)
                        .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<Emprendimiento>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Nombre)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(a => a.Descripcion)
                       .IsRequired()
                       .HasMaxLength(1000);

                builder.HasOne(a => a.ExAlumno)
                        .WithMany()
                        .HasForeignKey(a => a.ExAlumnoId)
                        .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<OfertaLaboral>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Titulo)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(a => a.Descripcion)
                       .IsRequired()
                       .HasMaxLength(1000);

                builder.Property(a => a.Modalidad)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(a => a.Direccion)
                      .HasMaxLength(50);

                builder.Property(a => a.Salario)
                       .HasPrecision(10, 2);                        

                builder.HasOne(a => a.Empresa)
                        .WithMany()
                        .HasForeignKey(a => a.EmpresaId)
                        .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(a => a.Categoria)
                        .WithMany()
                        .HasForeignKey(a => a.CategoriaId)
                        .OnDelete(DeleteBehavior.Cascade);

            });


            modelBuilder.Entity<Estudio>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Titulo)
                       .IsRequired()
                       .HasMaxLength(100);

            });


            modelBuilder.Entity<Curso>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Titulo)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(a => a.Descripcion)
                       .IsRequired()
                       .HasMaxLength(1000);

                builder.Property(a => a.Modalidad)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(a => a.Ubicacion)
                       .HasMaxLength(100);

                builder.Property(a => a.Instituto)
                       .HasMaxLength(100);

            });

            modelBuilder.Entity<Categoria>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Nombre)
                       .IsRequired()
                       .HasMaxLength(100);

            });


        }

    }
}
