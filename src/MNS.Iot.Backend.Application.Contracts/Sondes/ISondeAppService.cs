using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Sondes.DTOs.Inputs;
using MNS.Iot.Backend.Sondes.DTOs.Outputs;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Sondes;

public interface ISondeAppService : IApplicationService
{
    public Task<IEnumerable<SondeDto>> GetSondesByMachineIdAsync(Guid machineId);
    public Task<SondeDto> GetSondeAsync(Guid id);
    public Task<SondeDto> CreateSondeAsync(CreateSondeDto createSondeDto);
    public Task DeleteSondeAsync(Guid id);
}