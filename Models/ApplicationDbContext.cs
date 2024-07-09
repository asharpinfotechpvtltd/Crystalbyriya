using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astaberry.Models;
using CrystalByRiya.Models;

namespace Astaberry.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpProfessionals>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpCategoryList>().HasNoKey().ToView(null);
            modelBuilder.Entity<ProductBySkuCode>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpFilterProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpBestSeller>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpProductByConcern>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpProductSize>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpSubcategoryProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpRangeProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpConcernProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpSearch>().HasNoKey().ToView(null);
            modelBuilder.Entity<SPRegisters>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpOrderProductDetail>().HasNoKey().ToView(null);
            modelBuilder.Entity<ProductBySkuCode>().HasNoKey().ToView(null);
            modelBuilder.Entity<UserNumber>().HasNoKey().ToView(null);
            modelBuilder.Entity<USERBYMENU>().HasNoKey().ToView(null);
            modelBuilder.Entity<SpTotalOrder>().HasNoKey().ToView(null);
            modelBuilder.Entity<BlogCount>().HasNoKey().ToView(null);
            modelBuilder.Entity<TotalSales>().HasNoKey().ToView(null);
            

        }
        public virtual DbSet<MenuCollection> TblMenuLists { get; set; }
        public virtual DbSet<TblProductDesc> TblProductsDesc { get; set; }
        public virtual DbSet<TblBanner> TblBanners { get; set; }
        public virtual DbSet<TblBillingDetail> TblBillingDetails { get; set; }
        public virtual DbSet<TblBlog> TblBlogs { get; set; }
        public virtual DbSet<TblBrand> TblBrands { get; set; }
        public virtual DbSet<TblCart> TblCarts { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContactUs> TblContactUs { get; set; }
        public virtual DbSet<TblCouponCode> TblCouponCodes { get; set; }
        public virtual DbSet<TblCouponEmailUsed> TblCouponEmailUseds { get; set; }
        public virtual DbSet<TblCustomerOrderDetail> TblCustomerOrderDetails { get; set; }
     
        public virtual DbSet<TblImageGallery> TblImageGalleries { get; set; }
        public virtual DbSet<TblIngredient> TblIngredients { get; set; }
        public virtual DbSet<TblNewsLetter> TblNewsLetters { get; set; }
        public virtual DbSet<TblOffersImage> TblOffersImages { get; set; }
        public virtual DbSet<TblOrderId> TblOrderIds { get; set; }
        public virtual DbSet<TblPaymentHistory> TblPaymentHistories { get; set; }
        public virtual DbSet<TblRegister> TblRegisters { get; set; }
        public virtual DbSet<TblReview> TblReviews { get; set; }
        public virtual DbSet<TblShippingDetail> TblShippingDetails { get; set; }
        public virtual DbSet<TblSize> TblSizes { get; set; }
        public virtual DbSet<TblSkinType> TblSkinTypes { get; set; }
        public virtual DbSet<TblState> TblStates { get; set; }
        public virtual DbSet<TblStoreFinder> TblStoreFinders { get; set; }
        public virtual DbSet<TblWishlist> TblWishlists { get; set; }
        public virtual DbSet<TblSubCategory> TblSubCategories { get; set; }
        public virtual DbSet<TblConcern> TblConcerns { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblProductByConcern> TblProductByConcerns { get; set; }
        public virtual DbSet<TblOtp> TblOtps { get; set; }
        public virtual DbSet<TblRange> TblRange { get; set; }
        public virtual DbSet<TblCities> TblCities { get; set; }
        public virtual DbSet<Profile> TblProfile { get; set; }
        
        public virtual DbSet<Country> TblCountries { get; set; }
        public virtual DbSet<JobOpening> TblJobOpenings { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<TblJobApply> TblJobReply { get; set; }
        public virtual DbSet<UserNumber> UserNumbers { get; set; }
        
        public virtual DbSet<AssignUserAccess> AssignUserAccess { get; set; }
        

        public virtual DbSet<ProductBySkuCode> ProductBySkuCodes { get; set; }
        public virtual DbSet<SpCategoryList> SpCategoryLists { get; set; }
        public virtual DbSet<SpProfessionals> SpProfessionals { get; set; }
        public virtual DbSet<SpFilterProduct> SpSubcategoryProducts { get; set; }
        public virtual DbSet<SpBestSeller> SpBestSellers { get; set; }
        public virtual DbSet<SpProductByConcern> SpProductByConcerns { get; set; }        
        public virtual DbSet<SpProductSize> ProductSizes { get; set; }
        public virtual DbSet<SpSubcategoryProduct> RelatedProduct { get; set; }
        public virtual DbSet<SpRangeProduct> RangeProducts { get; set; }
        //public virtual DbSet<SpConcernProduct> ConcernProducts { get; set; }
        public virtual DbSet<SpSearch> SpSearches { get; set; }
        public virtual DbSet<SpOrderProductDetail> SpOrderProductDetail { get; set; }
        public virtual DbSet<SpTotalOrder> SpTotalOrder { get; set; }
        public virtual DbSet<BlogCount> SpBlogCount { get; set; }
        public virtual DbSet<USERBYMENU> USERBYMENU { get; set; }
        public virtual DbSet<Roles> TblRoles { get; set; }
        public virtual DbSet<OtherBanner> OtherBanners { get; set; }
        public virtual DbSet<TotalSales> SPTOTALSALES { get; set; }
        


    }

}
