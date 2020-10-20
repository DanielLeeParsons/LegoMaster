using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LegoMaster.Models
{
    public partial class pc305Context : DbContext
    {
        public pc305Context()
        {
        }

        public pc305Context(DbContextOptions<pc305Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Sickleave> Sickleave { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:legobrickssqldb.database.windows.net,1433;Initial Catalog=pc305;Persist Security Info=False;User ID=kingpin;Password='=5x?eFYFY!gS9qx@';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sickleave>(entity =>
            {
                entity.HasKey(e => e.Sickid)
                    .HasName("PK__Sickleav__1F43F250FC0D91BA");

                entity.ToTable("Sickleave", "pc305");

                entity.Property(e => e.ApplicationSickleavePayRecieved)
                    .HasColumnName("application_sickleave_pay_recieved")
                    .HasMaxLength(7);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(1000);

                entity.Property(e => e.CompleteSettlement).HasColumnName("complete_settlement");

                entity.Property(e => e.DateReceivedAltin)
                    .HasColumnName("date_received_altin")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employee_name")
                    .HasMaxLength(200);

                entity.Property(e => e.EmployeeNumber).HasColumnName("employee_number");

                entity.Property(e => e.ExceptionPregRequested).HasColumnName("exception_preg_requested");

                entity.Property(e => e.IncomeReportSent).HasColumnName("income_report_sent");

                entity.Property(e => e.LandSickleave).HasColumnName("land_sickleave");

                entity.Property(e => e.OffshoreSickleave).HasColumnName("offshore_sickleave");

                entity.Property(e => e.OrgNumber).HasColumnName("Org_number");

                entity.Property(e => e.PercentSickleave).HasColumnName("percent_sickleave");

                entity.Property(e => e.Period)
                    .HasColumnName("period")
                    .HasMaxLength(100);

                entity.Property(e => e.ReasonManualHandling)
                    .HasColumnName("reason_manual_handling")
                    .HasMaxLength(1000);

                entity.Property(e => e.RefundDemand).HasColumnName("refund_demand");

                entity.Property(e => e.SapCadeIt00281)
                    .HasColumnName("sap_cade_it0028_1")
                    .HasMaxLength(30);

                entity.Property(e => e.SapCodeIt00282)
                    .HasColumnName("sap_code_it0028_2")
                    .HasMaxLength(30);

                entity.Property(e => e.SapCodeIt2001)
                    .HasColumnName("sap_code_it2001")
                    .HasMaxLength(30);

                entity.Property(e => e.SapUpdated)
                    .HasColumnName("sap_updated")
                    .HasColumnType("date");

                entity.Property(e => e.SysUpdated)
                    .HasColumnName("sys_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToManualHandlling).HasColumnName("to_manual_handlling");

                entity.Property(e => e.TotalDays).HasColumnName("total_days");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
