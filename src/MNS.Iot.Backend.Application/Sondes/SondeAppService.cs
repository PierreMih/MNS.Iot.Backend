using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using MNS.Iot.Backend.Magasins.Machines;
using MNS.Iot.Backend.Magasins.Sondes;
using MNS.Iot.Backend.Sondes.DTOs.Inputs;
using MNS.Iot.Backend.Sondes.DTOs.Outputs;
using Volo.Abp.Guids;

namespace MNS.Iot.Backend.Sondes;

public class SondeAppService : BackendAppService, ISondeAppService
{
    private readonly ISondeRepository _sondeRepository;
    private readonly IMachineRepository _machineRepository;
    private readonly IGuidGenerator _guidGenerator;

    public SondeAppService(ISondeRepository sondeRepository, IGuidGenerator guidGenerator, IMachineRepository machineRepository)
    {
        _sondeRepository = sondeRepository;
        _guidGenerator = guidGenerator;
        _machineRepository = machineRepository;
    }

    public async Task<IEnumerable<SondeDto>> GetSondesByMachineIdAsync(Guid machineId)
    {
        var query = await _sondeRepository.WithDetailsAsync();
        query = query.Where(s => s.MachineId == machineId);
        return query.AsEnumerable().Select(s => ObjectMapper.Map<Sonde, SondeDto>(s));
    }

    public async Task<SondeDto> GetSondeAsync(Guid id)
    {
        return ObjectMapper.Map<Sonde, SondeDto>(await _sondeRepository.GetAsync(id));
    }

    public async Task<SondeDto> CreateSondeAsync(CreateSondeDto createSondeDto)
    {
        Machine machine = await _machineRepository.GetAsync(createSondeDto.MachineId);
        Sonde sonde = new Sonde(_guidGenerator.Create(), machine, createSondeDto.IdPhysique, createSondeDto.Name);
        machine.Sondes.Add(sonde);
        sonde = await _sondeRepository.InsertAsync(sonde);

        return ObjectMapper.Map<Sonde, SondeDto>(sonde);
    }

    public async Task DeleteSondeAsync(Guid id)
    {
        var sonde = await _sondeRepository.GetAsync(id);

        var machine = sonde.Machine;

        machine.Sondes.Remove(sonde);
        await _sondeRepository.DeleteAsync(sonde);
    }

    public async Task<SondeDto> MoveSondeToAnotherMachine(MoveSondeToAnotherMachineDto moveSondeToAnotherMachineDto) {
        var sonde = await _sondeRepository.GetAsync(moveSondeToAnotherMachineDto.SondeId);

        sonde.MachineId = moveSondeToAnotherMachineDto.NewMachineId;

        return ObjectMapper.Map<Sonde, SondeDto>(sonde);
    }
}