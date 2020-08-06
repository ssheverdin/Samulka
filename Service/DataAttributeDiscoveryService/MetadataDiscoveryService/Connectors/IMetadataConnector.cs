using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MetadataDiscoveryService.Models;

namespace MetadataDiscoveryService.Connectors
{
    public interface IMetadataConnector
    {
        bool HasConnection();
        Task<List<DomainEntity>> GetEntities();
        Task<List<DomainEntityAttribute>> GetEntityAttributes();
        Task<List<DomainEntityAttribute>> GetEntityAttributes(string entityName);
        Task<Dictionary<string,List<DomainEntityAttribute>>> GetEntityAttributes(List<string> entityNames);
        Task<List<DomainEntityRelation>> GetEntityRelations();
        Task<List<DomainEntityRelation>> GetEntityRelations(string entityName);
    }
}
