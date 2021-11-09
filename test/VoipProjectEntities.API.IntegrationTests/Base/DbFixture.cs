using Microsoft.EntityFrameworkCore;
using System;
using VoipProjectEntities.Identity;
using VoipProjectEntities.Persistence;
using Xunit;

namespace VoipProjectEntities.API.IntegrationTests.Base
{
    public class DbFixture : IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IdentityDbContext _identityDbContext;
        public readonly string ApplicationDbName = $"Application-{Guid.NewGuid()}";
        public readonly string IdentityDbName = $"Identity-{Guid.NewGuid()}";
        public readonly string HealthCheckDbName = $"HealthCheck";
        public readonly string HealthCheckConnString;
        public readonly string ApplicationConnString;
        public readonly string IdentityConnString;

        private bool _disposed;

        public DbFixture()
        {
            ApplicationConnString = $"Server=localhost,1433;Database={ApplicationDbName};User=sa;Password=2@LaiNw)PDvs^t>L!Ybt]6H^%h3U>M";
            IdentityConnString = $"Server=localhost,1433;Database={IdentityDbName};User=sa;Password=2@LaiNw)PDvs^t>L!Ybt]6H^%h3U>M";
            HealthCheckConnString = $"Server=localhost,1433;Database={HealthCheckDbName};User=sa;Password=2@LaiNw)PDvs^t>L!Ybt]6H^%h3U>M";

            var applicationBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var identityBuilder = new DbContextOptionsBuilder<IdentityDbContext>();

            applicationBuilder.UseSqlServer(ApplicationConnString);
            _applicationDbContext = new ApplicationDbContext(applicationBuilder.Options);

            _applicationDbContext.Database.Migrate();

            identityBuilder.UseSqlServer(IdentityConnString);
            _identityDbContext = new IdentityDbContext(identityBuilder.Options);

            _identityDbContext.Database.Migrate();

            SeedIdentity seed = new SeedIdentity(_identityDbContext);
            seed.SeedUsers();
            seed.SeedUserRoles();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // remove the temp db from the server once all tests are done
                    _applicationDbContext.Database.EnsureDeleted();
                    _identityDbContext.Database.EnsureDeleted();
                }
                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
