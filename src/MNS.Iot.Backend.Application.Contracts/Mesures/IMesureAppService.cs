using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Mesures.DTOs.Inputs;
using MNS.Iot.Backend.Mesures.DTOs.Outputs;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Mesures;

public interface IMesureAppService : IApplicationService
{
    public Task<IEnumerable<MesureDto>> GetMesuresBySondeIdAsync(Guid sondeId);
    public Task<MesureDto> GetMesureAsync(Guid id);
    public Task<MesureDto> CreateMesureAsync(CreateMesureDto createMesureDto);
    public Task DeleteMesureAsync(Guid id);
}