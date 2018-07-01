using System.Data.Entity;
using AzadiSoft.OnlineStore.DomainClasses;

namespace AzadiSoft.OnlineStore.DataLayer
{
    public partial class MainContext : DbContext, IUnitOfWork
    {
        public MainContext()
            : base("name=MainContext")
        {
        }

        public virtual IDbSet<Photo> Photos { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Product_Spec_Mapping> Product_Spec_Mapping { get; set; }

        public virtual IDbSet<Spec> Specs { get; set; }

        public virtual IDbSet<SpecOption> SpecOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Photos)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Spec_Mapping)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spec>()
                .HasMany(e => e.Product_Spec_Mapping)
                .WithRequired(e => e.Spec)
                .HasForeignKey(e => e.Spec_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spec>()
                .HasMany(e => e.SpecOptions)
                .WithRequired(e => e.Spec)
                .HasForeignKey(e => e.Spec_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecOption>()
                .HasMany(e => e.Product_Spec_Mapping)
                .WithRequired(e => e.SpecOption)
                .HasForeignKey(e => e.SpecOption_ID)
                .WillCascadeOnDelete(false);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
