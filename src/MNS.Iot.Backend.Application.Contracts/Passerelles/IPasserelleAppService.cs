using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Passerelles.DTOs.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Passerelles
{
    public interface IPasserelleAppService : IApplicationService {

        public Task<IEnumerable<PasserelleDto>> GetListPasserelle(Guid magasinId);
        public Task<PasserelleDto> GetPasserelle(Guid id);

        public Task<PasserelleDto> CreatePasserelle(CreatePasserelleDto createPasserelleDto);
        public Task DeletePasserelle(Guid id);
    }
}
