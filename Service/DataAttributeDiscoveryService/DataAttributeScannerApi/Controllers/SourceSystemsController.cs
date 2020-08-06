using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAttributeScannerContracts.Contract;
using DataAttributeScannerLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataAttributeScannerApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class SourceSystemsController : ControllerBase
    {
        private readonly ILogger<SourceSystemsController> _logger;
        private readonly IMetadataService _metadataService;

        public SourceSystemsController(ILogger<SourceSystemsController> logger, IMetadataService metadataService)
        {
            _logger = logger;
            _metadataService = metadataService;
        }

        /// <summary>
        /// Returns Active Source Systems 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<SourceSystemContract>> GetSourceSystems()
        {
            return await _metadataService.GetSourceSystems();
        }

        [HttpGet("{sourceSystem}")]
        public async Task<SourceSystemDetailsContract> GetSourceSystem(string sourceSystem)
        {
            return await _metadataService.GetSourceSystem(sourceSystem);
        }

    }
}
