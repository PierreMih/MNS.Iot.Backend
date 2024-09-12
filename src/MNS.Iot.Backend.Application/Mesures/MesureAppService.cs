using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNS.Iot.Backend.Magasins.Mesures;
using MNS.Iot.Backend.Magasins.Sondes;
using MNS.Iot.Backend.Mesures.DTOs.Inputs;
using MNS.Iot.Backend.Mesures.DTOs.Outputs;
using Volo.Abp.Guids;

namespace MNS.Iot.Backend.Mesures;

public class MesureAppService : BackendAppService, IMesureAppService
{
    private readonly IMesureRepository _mesureRepository;
    private readonly ISondeRepository _sondeRepository;
    private readonly IGuidGenerator _guidGenerator;

    public MesureAppService(ISondeRepository sondeRepository, IMesureRepository mesureRepository, IGuidGenerator guidGenerator)
    {
        _sondeRepository = sondeRepository;
        _mesureRepository = mesureRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task<DtoGenerique<MesureDto>> GetMesuresBySondeIdAsync(Guid sondeId)
    {
        var sonde = await _sondeRepository.GetAsync(sondeId, true);
        return new DtoGenerique<MesureDto>(sonde.Mesures.Select(m => ObjectMapper.Map<Mesure, MesureDto>(m)));
    }

    public async Task<MesureDto> GetMesureAsync(Guid id)
    {
        var mesure = await _mesureRepository.GetAsync(id);
        return ObjectMapper.Map<Mesure, MesureDto>(mesure);
    }

    public async Task<MesureDto> CreateMesureAsync(CreateMesureDto createMesureDto)
    {
        var sonde = await _sondeRepository.GetAsync(createMesureDto.SondeId, true);
        var mesure = new Mesure(_guidGenerator.Create(), sonde, createMesureDto.Temperature, createMesureDto.Date);
        sonde.Mesures.Add(mesure);
        mesure = await _mesureRepository.InsertAsync(mesure);
        return ObjectMapper.Map<Mesure, MesureDto>(mesure);
    }

    public async Task DeleteMesureAsync(Guid id)
    {
        var mesure = await _mesureRepository.GetAsync(id);
        await _mesureRepository.DeleteAsync(mesure);
    }
}