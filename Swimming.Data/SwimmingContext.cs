using Microsoft.EntityFrameworkCore;
using Swimming.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Data
{
    public partial class SwimmingContext : DbContext
    {
        public SwimmingContext()
        {
        }

        public SwimmingContext(DbContextOptions<SwimmingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivateAttachments> ActivateAttachments { get; set; }
        public virtual DbSet<Activates> Activates { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<AuthUser> AuthUser { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Grand> Grand { get; set; }
        public virtual DbSet<Mizu> Mizu { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SwimCategories> SwimCategories { get; set; }
        public virtual DbSet<SwimSubCategories> SwimSubCategories { get; set; }
        public virtual DbSet<TeamLoads> TeamLoads { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<UserCategories> UserCategories { get; set; }
        public virtual DbSet<UserTeam> UserTeam { get; set; }
        public virtual DbSet<UserTeamRole> UserTeamRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=swim;User ID=sa; password=P@ssw0rd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ActivateAttachments>(entity =>
            {
                entity.HasKey(e => e.ActivateAttachmentId);

                entity.Property(e => e.ActivateAttachmentId).HasColumnName("ActivateAttachmentID");

                entity.Property(e => e.ActivateId).HasColumnName("ActivateID");

                entity.Property(e => e.ContentType).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.HasOne(d => d.Activate)
                    .WithMany(p => p.ActivateAttachments)
                    .HasForeignKey(d => d.ActivateId)
                    .HasConstraintName("FK_ActivateAttachments_Users");
            });

            modelBuilder.Entity<Activates>(entity =>
            {
                entity.HasKey(e => e.ActivateId)
                    .HasName("ActivateID");

                entity.Property(e => e.ActivateId).HasColumnName("ActivateID");

                entity.Property(e => e.ActivateDate).HasColumnType("date");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApproveCoachId).HasColumnName("ApproveCoachID");

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.ActivatesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activates_UsersADD");

                entity.HasOne(d => d.ApproveCoach)
                    .WithMany(p => p.ActivatesApproveCoach)
                    .HasForeignKey(d => d.ApproveCoachId)
                    .HasConstraintName("FK_Activates_AddedUsers");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.ActivatesCoach)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK_Activates_Users");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.ActivatesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Activates_UsersMod");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Activates)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Activates_Teams");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Activates)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Activates_Types");
            });

            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.ContentType).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Attachments_Users");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.Property(e => e.AuthUserId).HasColumnName("AuthUserID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastloginDate).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ccomment).HasColumnName("CComment");

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Scomments).HasColumnName("SComments");

                entity.Property(e => e.SwimId).HasColumnName("SwimID");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.FormsAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_Forms_AddedUsers");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.FormsCoach)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK_Forms_Coach");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.FormsLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Forms_ModUsers");

                entity.HasOne(d => d.Swim)
                    .WithMany(p => p.FormsSwim)
                    .HasForeignKey(d => d.SwimId)
                    .HasConstraintName("FK_Forms_Swimmer");
            });

            modelBuilder.Entity<Grand>(entity =>
            {
                entity.Property(e => e.GrandId).HasColumnName("GrandID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromD).HasColumnType("date");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.ToD).HasColumnType("date");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.GrandAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_Grand_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.GrandLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Grand_ModUsers");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Grand)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Grand_Teams");
            });

            modelBuilder.Entity<Mizu>(entity =>
            {
                entity.Property(e => e.MizuId).HasColumnName("MizuID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromD).HasColumnType("date");

                entity.Property(e => e.GrandId).HasColumnName("GrandID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToD).HasColumnType("date");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.MizuAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_Mizu_AddedUsers");

                entity.HasOne(d => d.Grand)
                    .WithMany(p => p.Mizu)
                    .HasForeignKey(d => d.GrandId)
                    .HasConstraintName("FK_Mizu_Grand");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.MizuLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Mizu_ModUsers");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("RoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LastModDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.RolesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Roles_AddUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.RolesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Roles_ModUsers");
            });

            modelBuilder.Entity<SwimCategories>(entity =>
            {
                entity.HasKey(e => e.SwimCategoryId);

                entity.Property(e => e.SwimCategoryId).HasColumnName("SwimCategoryID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SwimCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.SwimCategoriesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_SwimCategory_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.SwimCategoriesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_SwimCategory_ModUsers");
            });

            modelBuilder.Entity<SwimSubCategories>(entity =>
            {
                entity.HasKey(e => e.SwimSubCategoryId);

                entity.Property(e => e.SwimSubCategoryId).HasColumnName("SwimSubCategoryID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SwimCategoryId).HasColumnName("SwimCategoryID");

                entity.Property(e => e.SwimSubCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.SwimSubCategoriesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_SwimSubCategory_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.SwimSubCategoriesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_SwimSubCategory_ModUsers");

                entity.HasOne(d => d.SwimCategory)
                    .WithMany(p => p.SwimSubCategories)
                    .HasForeignKey(d => d.SwimCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SwimSubCategories_SwimSubCategories");
            });

            modelBuilder.Entity<TeamLoads>(entity =>
            {
                entity.HasKey(e => e.TeamLoadId);

                entity.Property(e => e.TeamLoadId).HasColumnName("TeamLoadID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.TeamLoadsAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_TeamLoads_AddUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.TeamLoadsLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_TeamLoads_ModUsers");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamLoads)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_TeamLoads_Teams");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("TeamID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LastModDate).HasColumnType("datetime");

                entity.Property(e => e.TeamCoachId).HasColumnName("TeamCoachID");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.TeamsAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teams_AddUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.TeamsLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Teams_ModUsers");

                entity.HasOne(d => d.TeamCoach)
                    .WithMany(p => p.TeamsTeamCoach)
                    .HasForeignKey(d => d.TeamCoachId)
                    .HasConstraintName("FK_Teams_Users");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PageID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.TypesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Types_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.TypesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_Types_ModUsers");
            });

            modelBuilder.Entity<UserCategories>(entity =>
            {
                entity.HasKey(e => e.UserCategoryId);

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.UserCategoriesAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_UserCategory_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.UserCategoriesLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_UserCategory_ModUsers");
            });

            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.Property(e => e.UserTeamId).HasColumnName("UserTeamID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserTeamRoleId).HasColumnName("UserTeamRoleID");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.UserTeamAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_UserTeam_AddUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.UserTeamLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_UserTeam_ModUsers");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.UserTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTeam_UserTeam");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTeamUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTeam_Users");

                entity.HasOne(d => d.UserTeamRole)
                    .WithMany(p => p.UserTeam)
                    .HasForeignKey(d => d.UserTeamRoleId)
                    .HasConstraintName("FK_UserTeam_UserCategories");
            });

            modelBuilder.Entity<UserTeamRole>(entity =>
            {
                entity.Property(e => e.UserTeamRoleId).HasColumnName("UserTeamRoleID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserTeamRoleName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.UserTeamRoleAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTeamRole_AddedUsers");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.UserTeamRoleLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_UserTeamRole_ModUsers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AuthUserId).HasColumnName("AuthUserID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Identification).HasMaxLength(50);

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UserCategoryId).HasColumnName("UserCategoryID");

                entity.Property(e => e.UserFullName).HasMaxLength(500);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.InverseAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .HasConstraintName("FK_AddedUsers_Users");

                entity.HasOne(d => d.LastModByNavigation)
                    .WithMany(p => p.InverseLastModByNavigation)
                    .HasForeignKey(d => d.LastModBy)
                    .HasConstraintName("FK_ModUsers_Users");

                entity.HasOne(d => d.UserCategory)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserCategoryId)
                    .HasConstraintName("FK_Users_UserCategories");
            });
        }
    }
}
