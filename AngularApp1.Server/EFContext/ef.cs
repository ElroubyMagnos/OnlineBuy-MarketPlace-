using System.Reflection.Metadata;
using System.Security;
using Microsoft.EntityFrameworkCore;
using Online_Buy_Plus.Models;
using OnlineBuyDB.Models;

namespace Online_Buy_Plus;

public class ef : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder op)
    {
        op.UseSqlServer($@"{File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\connection.txt")}");
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Category>().HasOne(x => x.Product).WithOne(x => x.Category).HasForeignKey<Product>(x => x.CategoryString);
        mb.Entity<Product>().HasOne(x => x.Category).WithOne(x => x.Product);
        mb.Entity<Product>().HasIndex(x => x.CategoryString).IsUnique(false);

        //mb.Entity<Employee>()
        //    .HasOne(x => x.Permissions)
        //    .WithOne(x => x.User)
        //    .HasForeignKey<Permissions>(x => x.UserID);
        mb.Entity<Permissions>().HasIndex(x => x.UserID).IsUnique(true);
    }

    public DbSet<ReserveChat> RChat { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<BillChat> BillChat { get; set; }
    public DbSet<MainChat> MainChat { get; set; }
    public DbSet<Chat> PrivateChats { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Fatora> Fwater { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Permissions> Permissions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MoneyStorage> Earnings { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Site> Site { get; set; }
}