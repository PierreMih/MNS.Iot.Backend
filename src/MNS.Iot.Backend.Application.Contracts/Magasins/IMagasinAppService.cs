using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Magasins {
    public interface IMagasinAppService : IApplicationService{

        public Task<IEnumerable<MagasinDto>> GetListMagasin();
        public Task<MagasinDto> GetMagasin(Guid id);

        // public Task<MagasinDto> PostMagasin(MagasinDto magasinDto);
    }
}
