using System;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDatabase.DAL
{
	public class AppDbContext:DbContext
	{
		public DbSet<Product> Products { get; set; }

		public AppDbContext()
		{
		}
	}
}

