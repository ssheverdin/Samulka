using DataAttributeScannerContracts.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataUnitOfWork;
using MetadataDiscoveryService;
using MetadataStoreDataAccess.Dtos;

namespace DataAttributeScannerLogic.Services.Implementations
{
    public class MetadataService : IMetadataService
    {
        private readonly IMetadataDiscoveryService _metadataDiscoveryService;
        private readonly IUnitOfWork _unitOfWork;


        public MetadataService(IMetadataDiscoveryService metadataConnectorService, IUnitOfWork unitOfWork)
        {
            _metadataDiscoveryService = metadataConnectorService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SourceSystemContract>> GetSourceSystems()
        {
            var connectedSourceSystems = _metadataDiscoveryService.GetSourceSystems();
            var savedSourceSystems = await _unitOfWork.GetRepository<SourceSystemDto>().GetAllAsync();
            foreach (var sourceSystem in savedSourceSystems)
            {
                if (connectedSourceSystems.Any(i => i.Name == sourceSystem.Name))
                {
                    var currentSource = connectedSourceSystems.FirstOrDefault(i => i.Name == sourceSystem.Name);
                    if (currentSource != null)
                    {
                        currentSource.Description = sourceSystem.Description;
                        currentSource.HasSync = sourceSystem.InitialSyncDate.HasValue;
                        currentSource.HasMetadata = sourceSystem.LastSyncDate.HasValue;
                    }
                    
                }
                else
                {
                    connectedSourceSystems.Add(new SourceSystemContract()
                    {
                        Name = sourceSystem.Name,
                        HasSync = sourceSystem.InitialSyncDate.HasValue,
                        HasMetadata = sourceSystem.LastSyncDate.HasValue
                    });
                }
            }
            return connectedSourceSystems;
        }

        public async Task<SourceSystemDetailsContract> GetSourceSystem(string sourceSystemName)
        {
            var result = new SourceSystemDetailsContract();
            var sourceSystem = (await GetSourceSystems()).FirstOrDefault(i => i.Name == sourceSystemName);
            
            result.SourceSystem = sourceSystem;
            if (sourceSystem?.HasConnection == true)
            {
                var entities = await _metadataDiscoveryService.GetDomainEntities(sourceSystemName);
                var attributes = await _metadataDiscoveryService.GetEntityAttributes(sourceSystemName);
                var relations = await _metadataDiscoveryService.GetEntityRelations(sourceSystemName);

                result.Entities = entities.Select(i => new SourceSystemEntityContract()
                {
                    Schema = i.Schema,
                    Name = i.Name,
                    Type = i.Type,
                    CreatedDate = i.CreatedDate,
                    LastUpdatedDate = i.LastUpdatedDate,
                    HasMetadata = false,
                    NeedsToSync = false,
                    SourceColumnCount = attributes.Count(c => c.EntityName == i.Name),
                    Attributes = attributes.Where(c => c.EntityName == i.Name).Select(c => new SourceSystemEntityAttributeContract()
                    {
                        Name = c.Name,
                        IsIdentity = c.IsIdentity,
                        IsNullable = c.IsNullable,
                        MaxLength = c.MaxLength,
                        Position = c.Position,
                        Precision = c.Precision,
                        Type = c.Type
                    }).ToList(),
                    Referencing = relations.Where(c => c.EntityName == i.Name).Select(c => new SourceSystemEntityRelationContract()
                    {
                        Name = c.Name,
                        EntityAttributeName = c.EntityAttributeName,
                        EntityName = c.EntityName,
                        RelationEntityAttributeName = c.RelationEntityAttributeName,
                        RelationEntityName = c.RelationEntityName
                    }).ToList(),
                    Referenced = relations.Where(c => c.RelationEntityName == i.Name).Select(c => new SourceSystemEntityRelationContract()
                    {
                        Name = c.Name,
                        EntityAttributeName = c.EntityAttributeName,
                        EntityName = c.EntityName,
                        RelationEntityAttributeName = c.RelationEntityAttributeName,
                        RelationEntityName = c.RelationEntityName
                    }).ToList(),
                }).ToList();
            }
            
            return result;
        }
    }
}
