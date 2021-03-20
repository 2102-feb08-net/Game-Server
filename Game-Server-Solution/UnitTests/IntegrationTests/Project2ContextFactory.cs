using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests.IntegrationTests
{
    public class Project2ContextFactory : IDisposable
    {
        private DbConnection _connection;
        private bool _disposedValue;

        private DbContextOptions<Project2Context> CreateOptions()
        {
            return new DbContextOptionsBuilder<Project2Context>()
                .UseSqlite(_connection).Options;
        }

        public Project2Context CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                DbContextOptions<Project2Context> options = CreateOptions();
                using var context = new Project2Context(options);
                context.Database.EnsureCreated();
            }

            return new Project2Context(CreateOptions());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
