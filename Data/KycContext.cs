using System;
using KYC.Models;
using Microsoft.EntityFrameworkCore;
namespace KYC.Data;

public class KycContext(DbContextOptions<KycContext> options) : DbContext(options)
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Nominee> Nominee { get; set; }
    public DbSet<OtherDetails> OtherDetails { get; set; }
    public DbSet<BankDetail> BankDetails { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }

}
