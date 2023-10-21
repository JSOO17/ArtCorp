using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class ArtPortContext : DbContext
{
    public ArtPortContext()
    {
    }

    public ArtPortContext(DbContextOptions<ArtPortContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalePost> SalePosts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deal__3214EC071C1D5E06");

            entity.ToTable("Deal");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.DealArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ArtistId__440B1D61");

            entity.HasOne(d => d.Client).WithMany(p => p.DealClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ClientId__4316F928");

            entity.HasOne(d => d.Proposal).WithMany(p => p.Deals)
                .HasForeignKey(d => d.ProposalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ProposalId__4222D4EF");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC0700B60941");

            entity.ToTable("Post");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.InitialPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ClientId__3B75D760");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proposal__3214EC0714ECCC0E");

            entity.ToTable("Proposal");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__Client__3E52440B");

            entity.HasOne(d => d.Post).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__PostId__3F466844");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC074368D92F");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalePost__3214EC072407EEDB");

            entity.ToTable("SalePost");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Img).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.SalePostArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePost__Artist__47DBAE45");

            entity.HasOne(d => d.Client).WithMany(p => p.SalePostClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePost__Client__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0732DBB4DA");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Cellphone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Document)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lastnames)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Names)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
