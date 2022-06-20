using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace kr.Models
{
    public partial class KrModel : DbContext
    {
        public KrModel()
            : base("name=KrConnection")
        {
        }

        public virtual DbSet<cActualAdress> cActualAdress { get; set; }
        public virtual DbSet<cAdministrativeUnit> cAdministrativeUnit { get; set; }
        public virtual DbSet<cDistrict> cDistrict { get; set; }
        public virtual DbSet<cMobilePhone> cMobilePhone { get; set; }
        public virtual DbSet<cPostCode> cPostCode { get; set; }
        public virtual DbSet<cRegistrationAdress> cRegistrationAdress { get; set; }
        public virtual DbSet<cSettlement> cSettlement { get; set; }
        public virtual DbSet<vCitizen> vCitizen { get; set; }
        public virtual DbSet<vDocument> vDocument { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cActualAdress>()
                .HasMany(e => e.vCitizen)
                .WithRequired(e => e.cActualAdress)
                .HasForeignKey(e => e.ActualAdress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cAdministrativeUnit>()
                .HasMany(e => e.cDistrict)
                .WithRequired(e => e.cAdministrativeUnit)
                .HasForeignKey(e => e.AdministrativeUnitId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cAdministrativeUnit>()
                .HasMany(e => e.cSettlement)
                .WithOptional(e => e.cAdministrativeUnit)
                .HasForeignKey(e => e.AdministrativeUnitId);

            modelBuilder.Entity<cDistrict>()
                .HasMany(e => e.cSettlement)
                .WithOptional(e => e.cDistrict)
                .HasForeignKey(e => e.DistrictId);

            modelBuilder.Entity<cPostCode>()
                .HasMany(e => e.cActualAdress)
                .WithRequired(e => e.cPostCode)
                .HasForeignKey(e => e.PostCodeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cPostCode>()
                .HasMany(e => e.cRegistrationAdress)
                .WithRequired(e => e.cPostCode)
                .HasForeignKey(e => e.PostCodeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cRegistrationAdress>()
                .HasMany(e => e.vCitizen)
                .WithRequired(e => e.cRegistrationAdress)
                .HasForeignKey(e => e.RegistrationAdress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cSettlement>()
                .HasMany(e => e.cPostCode)
                .WithRequired(e => e.cSettlement)
                .HasForeignKey(e => e.SettlementId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vCitizen>()
                .Property(e => e.IPNCode)
                .IsUnicode(false);

            modelBuilder.Entity<vCitizen>()
                .HasMany(e => e.cMobilePhone)
                .WithOptional(e => e.vCitizen)
                .HasForeignKey(e => e.Citizen);

            modelBuilder.Entity<vCitizen>()
                .HasMany(e => e.vDocument)
                .WithRequired(e => e.vCitizen)
                .HasForeignKey(e => e.CitizenId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vDocument>()
                .Property(e => e.DocumentId)
                .IsUnicode(false);

            modelBuilder.Entity<vDocument>()
                .Property(e => e.DepartmentNumber)
                .IsUnicode(false);
        }
    }
}
