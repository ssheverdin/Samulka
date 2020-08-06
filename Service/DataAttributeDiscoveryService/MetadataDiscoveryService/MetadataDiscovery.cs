using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAttributeScannerContracts.Contract;
using MetadataDiscoveryService.Connectors;
using MetadataDiscoveryService.Connectors.SqlServerConnector;
using MetadataDiscoveryService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MetadataDiscoveryService
{
    public class MetadataDiscovery : IMetadataDiscoveryService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MetadataDiscovery> _logger;
        private readonly List<SourceSystemConnection> _sourceSystemConnections = new List<SourceSystemConnection>();
        private readonly Dictionary<string, IMetadataConnector> _metadataConnectors = new Dictionary<string, IMetadataConnector>();

        public MetadataDiscovery(IConfiguration configuration, ILogger<MetadataDiscovery> logger)
        {
            _configuration = configuration;
            _logger = logger;
            Configure();
        }

        private void Configure()
        {
            var sourceSystemConnectionsSettings = _configuration.GetSection("SourceSystemConnections").GetChildren().ToList();

            foreach (var sourceSystemConnectionsSetting in sourceSystemConnectionsSettings)
            {

                var connection = new SourceSystemConnection
                {
                    SourceSystem = sourceSystemConnectionsSetting.Key
                };
                sourceSystemConnectionsSetting.Bind(connection);
                _sourceSystemConnections.Add(connection);
                AddMetadataConnector(connection);
            }
        }

        public void AddMetadataConnector(SourceSystemConnection connection)
        {
            if (!string.IsNullOrEmpty(connection.Connection))
            {
                switch (connection.Type)
                {
                    case "SqlServer":
                        _metadataConnectors.Add(connection.SourceSystem, new SqlServerMetadataConnector(connection));
                        break;
                    default:
                        break;
                }
            }
        }

        public List<SourceSystemContract> GetSourceSystems()
        {
            return _sourceSystemConnections.Select(i => new SourceSystemContract()
            {
                Name = i.SourceSystem, 
                Type = i.Type,
                HasMetadataConnector = HasMetadataConnector(i.SourceSystem),
                HasConnection = HasConnection(i.SourceSystem)

            }).ToList();
        }

        public async Task<List<DomainEntity>> GetDomainEntities(string sourceSystem)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntities();
            }

            return null;
        }

        public async Task<List<DomainEntityAttribute>> GetEntityAttributes(string sourceSystem)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntityAttributes();
            }

            return null;
        }

        public async Task<List<DomainEntityAttribute>> GetEntityAttributes(string sourceSystem, string entityName)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntityAttributes(entityName);
            }

            return null;
        }

        public async Task<Dictionary<string, List<DomainEntityAttribute>>> GetEntityAttributes(string sourceSystem, List<string> entityNames)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntityAttributes(entityNames);
            }

            return null;
        }

        public async Task<List<DomainEntityRelation>> GetEntityRelations(string sourceSystem)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntityRelations();
            }

            return null;
        }

        public async Task<List<DomainEntityRelation>> GetEntityRelations(string sourceSystem, string entityName)
        {
            if (HasMetadataConnector(sourceSystem))
            {
                return await _metadataConnectors[sourceSystem].GetEntityRelations(entityName);
            }

            return null;
        }

        public IMetadataConnector GetMetadataConnector(string key)
        {
            if (HasMetadataConnector(key))
            {
                return _metadataConnectors[key];
            }

            return null;
        }

        private bool HasMetadataConnector(string key)
        {
            return _metadataConnectors.ContainsKey(key);
        }

        private bool HasConnection(string key)
        {
            if (HasMetadataConnector(key))
            {
                return _metadataConnectors[key].HasConnection();
            }

            return false;
        }
    }
}
