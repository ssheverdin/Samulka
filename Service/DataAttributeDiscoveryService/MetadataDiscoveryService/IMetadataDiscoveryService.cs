using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAttributeScannerContracts.Contract;
using MetadataDiscoveryService.Connectors;
using MetadataDiscoveryService.Models;

namespace MetadataDiscoveryService
{
    public interface IMetadataDiscoveryService
    {
        List<SourceSystemContract> GetSourceSystems();
        IMetadataConnector GetMetadataConnector(string key);
        void AddMetadataConnector(SourceSystemConnection connection);
        Task<List<DomainEntity>> GetDomainEntities(string sourceSystem);

        Task<List<DomainEntityAttribute>> GetEntityAttributes(string sourceSystem);
        Task<List<DomainEntityAttribute>> GetEntityAttributes(string sourceSystem,string entityName);
        Task<Dictionary<string, List<DomainEntityAttribute>>> GetEntityAttributes(string sourceSystem, List<string> entityNames);
        Task<List<DomainEntityRelation>> GetEntityRelations(string sourceSystem);
        Task<List<DomainEntityRelation>> GetEntityRelations(string sourceSystem,string entityName);
    }
}
