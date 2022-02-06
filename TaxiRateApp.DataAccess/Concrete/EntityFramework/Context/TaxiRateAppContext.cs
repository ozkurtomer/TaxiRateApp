using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework.Context
{
    public class TaxiRateAppContext : DbContext
    {
        public TaxiRateAppContext()
        {
        }

        public TaxiRateAppContext(DbContextOptions<TaxiRateAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;port=3306;database=TaxiRate;uid=root;password=1234", ServerVersion.Parse("5.7.32-mysql"));
                optionsBuilder.UseMySql("server=91.151.89.14;port=3306;database=TaxiRate;uid=allhost;password=omer45871", ServerVersion.Parse("5.7.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.City_Id)
                    .HasName("PRIMARY");

                entity.Property(e => e.City_Id)
                    .HasColumnName("City_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City_Name)
                    .IsRequired()
                    .HasColumnName("City_Name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.Comment_Id)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Post_Id)
                    .HasName("fk_Comment_Post_Id");

                entity.HasIndex(e => e.User_Id)
                    .HasName("fk_Comment_User_Id");

                entity.Property(e => e.Comment_Id)
                    .HasColumnName("Comment_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment_CreatedDate)
                    .HasColumnName("Comment_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Comment_Description)
                    .IsRequired()
                    .HasColumnName("Comment_Description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment_IsActive).HasColumnName("Comment_IsActive");

                entity.Property(e => e.Post_Id)
                    .HasColumnName("Post_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Post_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comment_Post_Id");

                entity.HasOne(d => d.User) 
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comment_User_Id");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.Post_Id)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.City_Id)
                    .HasName("fk_Posts_Cities_Id");

                entity.Property(e => e.Post_Id)
                    .HasColumnName("Post_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City_Id)
                    .HasColumnName("City_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Post_CreatedDate)
                    .HasColumnName("Post_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Post_Title)
                    .IsRequired()
                    .HasColumnName("Post_Title")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Post_Description)
                    .IsRequired()
                    .HasColumnName("Post_Description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci"); 
                
                entity.Property(e => e.Post_LikeCount)
                     .HasColumnName("Post_LikeCount")
                     .HasColumnType("int(11)");

                entity.Property(e => e.Post_IsActive)
                      .HasColumnName("Post_IsActive");

                entity.Property(e => e.Post_Plate)
                    .IsRequired()
                    .HasColumnName("Post_Plate")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Post_Stars)
                    .HasColumnName("Post_Stars")
                    .HasColumnType("int(11)");

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.HasIndex(e => e.User_Id)
                    .HasName("fk_Offer_User_Id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.City_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Posts_Cities_Id");
                
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Posts_Users_Id");

                
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.User_Id)
                    .HasName("PRIMARY");

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.User_Anonymous).HasColumnName("User_Anonymous");

                entity.Property(e => e.User_CreatedDate)
                    .HasColumnName("User_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.User_Ip)
                    .HasColumnName("User_Ip")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.User_IsActive).HasColumnName("User_IsActive");

                entity.Property(e => e.User_Name)
                    .HasColumnName("User_Name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.User_Email)
                    .HasColumnName("User_Email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.User_PasswordHash)
                    .HasColumnName("User_PasswordHash")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.User_PasswordSalt)
                    .HasColumnName("User_PasswordSalt")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.User_UserName)
                    .IsRequired()
                    .HasColumnName("User_UserName")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });
        }
    }
}
