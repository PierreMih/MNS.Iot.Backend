using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNS.Iot.Backend.Machines.DTOs.Inputs;
using MNS.Iot.Backend.Machines.DTOs.Outputs;
using MNS.Iot.Backend.Magasins.Machines;
using MNS.Iot.Backend.Magasins.Passerelles;
using Volo.Abp.Guids;

namespace MNS.Iot.Backend.Machines;

public class MachineAppService : BackendAppService, IMachineAppService
{
    private readonly IMachineRepository _machineRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IPasserelleRepository _passerelleRepository;

    public MachineAppService(IMachineRepository machineRepository, IGuidGenerator guidGenerator, IPasserelleRepository passerelleRepository)
    {
        _machineRepository = machineRepository;
        _guidGenerator = guidGenerator;
        _passerelleRepository = passerelleRepository;
    }

    public async Task<IEnumerable<MachineDto>> GetMachinesByPasserelleIdAsync(Guid passerelleId)
    {
        var passerelle = await _passerelleRepository.GetAsync(passerelleId, true); 
        return passerelle.Machines.Select(m => ObjectMapper.Map<Machine, MachineDto>(m));
    }

    public async Task<MachineDto> GetMachineAsync(Guid id)
    {
        var machine = await _machineRepository.GetAsync(id);
        return ObjectMapper.Map<Machine, MachineDto>(machine);
    }

    public async Task<MachineDto> CreateMachineAsync(CreateMachineDto createMachineDto)
    {
        var passerelleId = createMachineDto.PasserelleId;
        var passerelle = await _passerelleRepository.GetAsync(passerelleId);
        var machine = new Machine(_guidGenerator.Create(), passerelleId, createMachineDto.Name, createMachineDto.IdPhysique);
        passerelle.Machines.Add(machine);
        machine = await _machineRepository.InsertAsync(machine);
        return ObjectMapper.Map<Machine, MachineDto>(machine);
    }

    public async Task DeleteMachineAsync(Guid id)
    {
        var machine = await _machineRepository.GetAsync(id);
        await _machineRepository.DeleteAsync(machine);
    }
}