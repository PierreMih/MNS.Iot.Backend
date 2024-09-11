using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MNS.Iot.Backend.Machines.DTOs.Inputs;
using MNS.Iot.Backend.Machines.DTOs.Outputs;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Machines;

public interface IMachineAppService : IApplicationService
{
    public Task<IEnumerable<MachineDto>> GetMachinesByPasserelleIdAsync(Guid passerelleId);
    public Task<MachineDto> GetMachineAsync(Guid id);
    public Task<MachineDto> CreateMachineAsync(CreateMachineDto createMachineDto);
    public Task DeleteMachineAsync(Guid id);
}