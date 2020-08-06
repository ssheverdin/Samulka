using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MetadataDiscoveryService.Connectors.SqlServerConnector;
using MetadataDiscoveryService.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadataDiscoveryService.Connectors
{
    public abstract class MetadataConnector : IMetadataConnector
    {
        protected readonly SourceSystemConnection _connection;

        protected MetadataConnector(SourceSystemConnection connection)
        {
            _connection = connection;
        }

        protected void SqlCommand(string sql, IEnumerable<object> parameters)
        {
            using (var sqlServerDatabase = (new SqlServerContext(_connection.Connection)))
            {
                sqlServerDatabase.Database.ExecuteSqlRaw(sql, parameters);
            }
        }

        public abstract bool HasConnection();
        public abstract Task<List<DomainEntity>> GetEntities();
        public abstract Task<List<DomainEntityAttribute>> GetEntityAttributes();
        public abstract Task<List<DomainEntityAttribute>> GetEntityAttributes(string entityName);
        public abstract Task<Dictionary<string, List<DomainEntityAttribute>>> GetEntityAttributes(List<string> entityNames);
        public abstract Task<List<DomainEntityRelation>> GetEntityRelations();
        public abstract Task<List<DomainEntityRelation>> GetEntityRelations(string entityName);
    }
}
