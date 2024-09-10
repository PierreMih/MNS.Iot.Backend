using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MNS.Iot.Backend.Magasins.DTOs.Inputs;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Magasins
{
    public interface IMagasinAppService : IApplicationService{

        public Task<IEnumerable<MagasinDto>> GetListMagasin();
        public Task<MagasinDto> GetMagasin(Guid id);

        public Task<MagasinDto> CreateMagasin(CreateMagasinDto createMagasinDto);
        public Task DeleteMagasin(Guid id);
    }
}
