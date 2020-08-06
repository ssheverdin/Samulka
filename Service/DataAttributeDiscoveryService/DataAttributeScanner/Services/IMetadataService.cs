using DataAttributeScannerContracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAttributeScannerLogic.Services
{
    public interface IMetadataService
    {
        Task<List<SourceSystemContract>> GetSourceSystems();
        Task<SourceSystemDetailsContract> GetSourceSystem(string sourceSystemName);
    }
}
