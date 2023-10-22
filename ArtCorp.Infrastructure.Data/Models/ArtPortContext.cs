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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5JBOS0E;Database=ArtPort;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Deal__3214EC07B743F75D");

            entity.ToTable("Deal");

            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.DealArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ArtistId__72C60C4A");

            entity.HasOne(d => d.Client).WithMany(p => p.DealClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ClientId__71D1E811");

            entity.HasOne(d => d.Proposal).WithMany(p => p.Deals)
                .HasForeignKey(d => d.ProposalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deal__ProposalId__70DDC3D8");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC07E7FC8B93");

            entity.ToTable("Post");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.InitialPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ClientId__6A30C649");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proposal__3214EC078E728ED5");

            entity.ToTable("Proposal");

            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__Client__6D0D32F4");

            entity.HasOne(d => d.Post).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proposal__PostId__6E01572D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07F066B358");

            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalePost__3214EC077DFDF40E");

            entity.ToTable("SalePost");

            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Img).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Artist).WithMany(p => p.SalePostArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePost__Artist__76969D2E");

            entity.HasOne(d => d.Client).WithMany(p => p.SalePostClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePost__Client__75A278F5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07CB733937");

            entity.ToTable("User");

            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
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
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__Password__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
