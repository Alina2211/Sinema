using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Sinema.Models;

#nullable disable

namespace Sinema
{
    public partial class sinemaContext : IdentityDbContext<User>
    {
        public sinemaContext()
        {
        }

        public sinemaContext(DbContextOptions<sinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorFilm> ActorFilms { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<PlaceHall> PlaceHalls { get; set; }
        public virtual DbSet<PlaceSession> PlaceSessions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("lastName");
            });

            modelBuilder.Entity<ActorFilm>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("ActorFilm_pkey");

                entity.ToTable("ActorFilm");

                entity.Property(e => e.RowId).HasColumnName("rowId");

                entity.Property(e => e.ActorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("actorId");

                entity.Property(e => e.FilmId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("filmId");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorFilms)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Actor_fk");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.ActorFilms)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Film_fk");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration).HasColumnName("duration").HasColumnType("character varying");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("director");

                entity.Property(e => e.FilmName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("filmName");

                entity.Property(e => e.Genre)
                    .HasColumnType("character varying")
                    .HasColumnName("genre");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Poster)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("poster");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RowNumber).HasColumnName("rowNumber");

                entity.Property(e => e.PlaceNumber).HasColumnName("placeNumber");

                entity.HasOne(d => d.PlaceHall)
                    .WithOne(p => p.Place)
                    .HasForeignKey<PlaceHall>(p => p.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PlaceHallPlace_fk");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("Hall");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HallName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("hallName");

            });

            modelBuilder.Entity<PlaceHall>(entity =>
            {
                
                entity.ToTable("PlaceHall");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlaceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("placeId");

                entity.Property(e => e.HallId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hallId");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PlaceHallHall_fk");

            });

            modelBuilder.Entity<PlaceSession>(entity =>
            {
                entity.ToTable("PlaceSession");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PlaceId).ValueGeneratedOnAdd().HasColumnName("placeId");
                entity.Property(e => e.ScheduleId).ValueGeneratedOnAdd().HasColumnName("scheduleId");
                entity.Property(e => e.Cost).HasColumnName("cost");
                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.HasOne(d=>d.Place)
                .WithMany(p=>p.PlaceSessions)
                .HasForeignKey(d=>d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaceAvailability_fk");

                entity.HasOne(d=>d.Schedule)
                .WithMany(p=>p.PlaceSessions)
                .HasForeignKey(d=>d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SessionAvailability_fk");

            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FilmId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("filmId");

                entity.Property(e => e.FilmSession).HasColumnName("filmSession");

                entity.Property(e => e.HallId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hallId");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ScheduleHall_fk");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Schedule_fk");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketNumber)
                    .HasName("Ticket_pkey");

                entity.ToTable("Ticket");

                entity.Property(e => e.TicketNumber).HasColumnName("ticketNumber");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("orderId");

                entity.Property(e => e.PlaceId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("placeId");

                entity.Property(e => e.ScheduleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("scheduleId");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TicketPlace_fk");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TicketOrder_fk");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TicketSession_fk");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.HasNoKey());
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.HasNoKey());
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.HasNoKey());
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("lastName");

                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
