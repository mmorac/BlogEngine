using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Models;

public partial class BlogEngineContext : DbContext
{
    public BlogEngineContext()
    {
    }

    public BlogEngineContext(DbContextOptions<BlogEngineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Poststatus> Poststatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-U6DO4TO; Database=BlogEngine; Trusted_Connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F6E594965");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(280)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Postid).HasColumnName("postid");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Postid)
                .HasConstraintName("FK__comments__postid__4BAC3F29");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83FABB4CDB7");

            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Lastmodifiedby).HasColumnName("lastmodifiedby");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.PostCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK__posts__createdby__47DBAE45");

            entity.HasOne(d => d.LastmodifiedbyNavigation).WithMany(p => p.PostLastmodifiedbyNavigations)
                .HasForeignKey(d => d.Lastmodifiedby)
                .HasConstraintName("FK__posts__lastmodif__48CFD27E");

            entity.HasOne(d => d.Status).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Statusid)
                .HasConstraintName("FK__posts__statusid__46E78A0C");
        });

        modelBuilder.Entity<Poststatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__poststat__3213E83FAE74C7AA");

            entity.ToTable("poststatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Statusname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FF6A1AA22");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Displayname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("displayname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userrole).HasColumnName("userrole");

            entity.HasOne(d => d.UserroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userrole)
                .HasConstraintName("FK__users__userrole__440B1D61");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userrole__3213E83FE1D47A36");

            entity.ToTable("userroles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rolename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("rolename");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
