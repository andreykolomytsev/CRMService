using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Threading;
using CRMService.Interfaces;
using CRMService.Entities;
using CRMService.DTOModels;

namespace CRMService.Helpers
{
    public class DataContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Account _currentAccount;

        public DbSet<ContractorModel> Contractors { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }

        public DataContext(DbContextOptions options, IDateTimeService dateTime, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _httpContextAccessor = httpContextAccessor;
            _dateTime = dateTime;
            _currentAccount = (Account)_httpContextAccessor.HttpContext.Items["Account"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupModel>().HasQueryFilter(b => EF.Property<int>(b, "TenantId") == _currentAccount.TenantId);
            modelBuilder.Entity<ContractorModel>().HasQueryFilter(b => EF.Property<int>(b, "TenantId") == _currentAccount.TenantId);
        }

        #region DefensiveOps
        public override int SaveChanges()
        {
            SetTenantsIds();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetTenantsIds();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetTenantsIds();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetTenantsIds();

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion


        #region Helpers
        /// <summary>
        /// Добавляем Id организации при добавлвении ко всем записям
        /// </summary>
        private void SetTenantsIds()
        {
            foreach (var entry in ChangeTracker.Entries<CoreEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.TenantId = _currentAccount.TenantId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateUpdate = _dateTime.NowUtc;
                        break;
                }
            }
        }
        #endregion
    }
}
