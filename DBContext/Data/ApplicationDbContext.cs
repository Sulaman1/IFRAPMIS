using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IFRAPMIS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> AppUsers { get; set; }
        public virtual DbSet<BeneficiaryIP> BeneficiaryIPs { get; set; }
        public virtual DbSet<BeneficiaryPDMA> BeneficiaryPDMAs { get; set; }
        public virtual DbSet<BeneficiaryVerified> BeneficiaryVerifieds { get; set; }
        public virtual DbSet<CICIG> CICIGs { get; set; }
        public virtual DbSet<CICIGTrainings> CICIGTrainings { get; set; }
        public virtual DbSet<CIMember> CIMembers { get; set; }
        public virtual DbSet<CITrainingMember> CITrainingMembers { get; set; }
        public virtual DbSet<CITrainingParticipation> CITrainingParticipations { get; set; }
        public virtual DbSet<DamageAssessmentHTS> DamageAssessmentHTSs { get; set; }
        public virtual DbSet<DamageAssessmentLivestock> DamageAssessmentLivestocks { get; set; }
        public virtual DbSet<DamageIP> DamageIPs { get; set; }
        public virtual DbSet<DamagePDMA> DamagePDMAs { get; set; }
        public virtual DbSet<DamageVerified> DamageVerifieds { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Tehsil> Teshsils { get; set; }
        public virtual DbSet<UnionCouncil> UnionCouncils { get; set; }
        public virtual DbSet<Village> Villages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the foreign key for Village in CICIGTrainings
            modelBuilder.Entity<CICIGTrainings>()
                .HasOne(ct => ct.Village)
                .WithMany(v => v.CICIGTrainings)
                .HasForeignKey(ct => ct.VillageId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure the foreign key for CICIG in CICIGTrainings
            //modelBuilder.Entity<CICIGTrainings>()
            //    .HasOne(ct => ct.CICIG)
            //    .WithMany()
            //    .HasForeignKey(ct => ct.CICIGId)
            //    .OnDelete(DeleteBehavior.NoAction);




            //// Configure the foreign key for CIMember in BeneficiaryVerified
            //modelBuilder.Entity<BeneficiaryVerified>()
            //    .HasOne(bv => bv.CIMember)
            //    .WithOne(cm => cm.BeneficiaryVerified)
            //    .HasForeignKey<BeneficiaryVerified>(bv => bv.CIMemberId)
            //    .OnDelete(DeleteBehavior.NoAction);




            // Configure the foreign key for CICIG in BeneficiaryVerified
            //modelBuilder.Entity<BeneficiaryVerified>()
            //    .HasOne(bv => bv.CICIG)
            //    .WithMany()
            //    .HasForeignKey(bv => bv.CICIGId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // Configure the foreign key for CICIG in CIMember
            //modelBuilder.Entity<CIMember>()
            //    .HasOne(cm => cm.CICIG)
            //    .WithMany()
            //    .HasForeignKey(cm => cm.CICIGId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<CITrainingParticipation>()
            //   .HasOne(bv => bv.CICIGTrainings)
            //   .WithOne(cm => cm.CITrainingParticipation)
            //   .HasForeignKey<CITrainingParticipation>(bv => bv.CICIGTrainings)
            //   .OnDelete(DeleteBehavior.NoAction);
            // Configure the foreign key for CICIGTrainings in CITrainingParticipation


            //modelBuilder.Entity<CITrainingParticipation>()
            //    .HasOne(tp => tp.CICIGTrainings)
            //    .WithOne(ct => ct.CITrainingParticipation)
            //    .HasForeignKey<CITrainingParticipation>(tp => tp.CICIGTrainingsId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
