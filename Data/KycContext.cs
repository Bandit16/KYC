using System;
using KYC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static KYC.Models.KycFormModel;

namespace KYC.Data;

public class KycContext : DbContext
{
    public KycContext(DbContextOptions<KycContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Nominee> Nominee { get; set; }
    public DbSet<OtherDetails> OtherDetails { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<BankDetail> BankDetails { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }

}
