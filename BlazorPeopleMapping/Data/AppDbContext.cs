using BlazorPeopleMapping.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static BlazorPeopleMapping.Models.PeopleName;

namespace BlazorPeopleMapping.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
		/// Magic string.
		/// </summary>
		public static readonly string RowVersion = nameof(RowVersion);

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string BlazorPeopleMapping = nameof(BlazorPeopleMapping).ToLower();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }
        public AppDbContext() { }

        private string myConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BlazorPeopleMapping";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured)
            {
                builder.UseSqlServer(myConnectionString).UseLazyLoadingProxies();
                builder.EnableSensitiveDataLogging();
            }
        }

        public DbSet<PeopleName> PeopleNames { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Define the model.
        /// </summary>
        /// <param name="builder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PeopleName>()
                .HasKey(pn => new { pn.NameId, pn.PersonId });

            //builder.Entity<PeopleName>()
            //    .HasOne(pn => pn.Name)
            //    .WithMany(n => n.PeopleNames)
            //    .HasForeignKey(pn => pn.NameId);

            //builder.Entity<PeopleName>()
            //    .HasOne(pn => pn.Person)
            //    .WithMany(p => p.PersonNames)
            //    .HasForeignKey(pn => pn.PersonId);
        }
    }
}
