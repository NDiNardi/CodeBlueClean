using CodeBlue.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace CodeBlue.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions<AppDbContext> options )
		: base(options)
	{
	}

	public DbSet<User> Users => Set<User>();
	public DbSet<Customer> Customers => Set<Customer>();
	public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
	public DbSet<WarrantyClaim> WarrantyClaims => Set<WarrantyClaim>();

	protected override void OnModelCreating( ModelBuilder modelBuilder )
	{
		base.OnModelCreating(modelBuilder);

		// Customer -> WorkOrders (1-many)
		modelBuilder.Entity<WorkOrder>()
			.HasOne(w => w.Customer)
			.WithMany(c => c.WorkOrders)
			.HasForeignKey(w => w.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		// Customer -> Claims (1-many)
		modelBuilder.Entity<WarrantyClaim>()
			.HasOne(c => c.Customer)
			.WithMany(cu => cu.WarrantyClaims)
			.HasForeignKey(c => c.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		// WorkOrder -> Claims (1-many)
		modelBuilder.Entity<WarrantyClaim>()
			.HasOne(c => c.WorkOrder)
			.WithMany(w => w.WarrantyClaims)
			.HasForeignKey(c => c.WorkOrderId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<WarrantyClaim>()
			.HasIndex(c => c.ClaimNumber)
			.IsUnique(false);

		modelBuilder.Entity<Customer>(entity =>
		{
			entity.Property(x => x.Latitude).HasPrecision(9, 6);
			entity.Property(x => x.Longitude).HasPrecision(9, 6);

			// Optional but recommended if you want AddressKey required
			entity.Property(x => x.AddressKey).HasMaxLength(120).IsRequired();

			// Optional: keep Address searchable
			entity.Property(x => x.Address).HasMaxLength(300);
		});

		modelBuilder.Entity<WorkOrder>(entity =>
		{
			entity.Property(x => x.ServiceLatitude).HasPrecision(9, 6);
			entity.Property(x => x.ServiceLongitude).HasPrecision(9, 6);

			entity.Property(x => x.AddressKey).HasMaxLength(200).IsRequired();

			entity.HasOne(x => x.Customer)
				.WithMany(c => c.WorkOrders)
				.HasForeignKey(x => x.CustomerId)
				.OnDelete(DeleteBehavior.SetNull);
		});

		modelBuilder.Entity<WarrantyClaim>(entity =>
		{
			entity.Property(x => x.Latitude).HasPrecision(9, 6);
			entity.Property(x => x.Longitude).HasPrecision(9, 6);

			entity.Property(x => x.ClaimNumber).HasMaxLength(32).IsRequired();
			entity.Property(x => x.AddressKey).HasMaxLength(200).IsRequired();

			entity.HasOne(x => x.Customer)
				.WithMany(c => c.WarrantyClaims)
				.HasForeignKey(x => x.CustomerId)
				.OnDelete(DeleteBehavior.SetNull);

			entity.HasOne(x => x.WorkOrder)
				.WithMany(w => w.WarrantyClaims)
				.HasForeignKey(x => x.WorkOrderId)
				.OnDelete(DeleteBehavior.SetNull);
		});

	}
}
