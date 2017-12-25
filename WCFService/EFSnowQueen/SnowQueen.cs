namespace WCFService.EFSnowQueen
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SnowQueen : DbContext
	{
		public SnowQueen()
			: base("name=EFSnowQueen")
		{
		}

		public virtual DbSet<Orders> Orders { get; set; }
		public virtual DbSet<Products> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Orders>()
				.Property(e => e.priceOfProduct)
				.HasPrecision(19, 4);

			modelBuilder.Entity<Products>()
				.HasMany(e => e.Orders)
				.WithRequired(e => e.Products)
				.HasForeignKey(e => e.id_product)
				.WillCascadeOnDelete(false);
		}
	}
}
