using MNS.Iot.Backend.Magasins;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Magasins.Passerelles;
using MNS.Iot.Backend.Passerelles;
using MNS.Iot.Backend.Passerelles.DTOs.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using MNS.Iot.Backend.Sondes.DTOs.Inputs;
using MNS.Iot.Backend.Magasins.Sondes;
using MNS.Iot.Backend.Sondes.DTOs.Outputs;
using System.Xml.Linq;
using Volo.Abp.Reflection;
using MNS.Iot.Backend.Magasins.Machines;
using MNS.Iot.Backend.Magasins.Mesures;
using MNS.Iot.Backend.Mesures;

namespace MNS.Iot.Backend.Passerelles {
    public class PasserelleAppService : BackendAppService, IPasserelleAppService {
        private readonly IPasserelleRepository _passerelleRepository;
        private readonly IMagasinRepository _magasinRepository;
        private readonly ISondeRepository _sondeRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IMesureRepository _mesureRepository;
        private readonly IGuidGenerator _guidGenerator;

        private readonly MagasinPasserelleManager _magasinPasserelleManager;

        public PasserelleAppService(IPasserelleRepository passerelleRepository, 
            IMagasinRepository magasinRepository, IGuidGenerator guidGenerator, 
            MagasinPasserelleManager magasinPasserelleManager, ISondeRepository sondeRepository,
            IMachineRepository machineRepository, IMesureRepository mesureRepository) {
            _passerelleRepository = passerelleRepository;
            _magasinRepository = magasinRepository;
            _guidGenerator = guidGenerator;
            _magasinPasserelleManager = magasinPasserelleManager;
            _sondeRepository = sondeRepository;
            _machineRepository = machineRepository;
            _mesureRepository = mesureRepository;
        }
        public async Task<PasserelleDto> CreatePasserelle(CreatePasserelleDto createPasserelleDto) {
            Magasin magasin = await _magasinRepository.GetAsync(createPasserelleDto.MagasinId);
            Passerelle passerelle = new Passerelle(_guidGenerator.Create(), magasin, createPasserelleDto.Name, createPasserelleDto.IdPhysique);
            magasin.Passerelles.Add(passerelle);
            passerelle = await _passerelleRepository.InsertAsync(passerelle);

            return ObjectMapper.Map<Passerelle, PasserelleDto>(passerelle);
        }

        public async Task DeletePasserelle(Guid id) {
            var passerelle = await _passerelleRepository.GetAsync(id);

            var magasin = passerelle.Magasin;

            magasin.Passerelles.Remove(passerelle);
            await _passerelleRepository.DeleteAsync(passerelle);
        }

        public async Task<IEnumerable<PasserelleDto>> GetListPasserelle(Guid magasinId)
        {
            var query = await _passerelleRepository.WithDetailsAsync();
            query = query.Where(p => p.MagasinId == magasinId);
            
            return query.AsEnumerable().Select(p => ObjectMapper.Map<Passerelle, PasserelleDto>(p));
        }

        public async Task<PasserelleDto> GetPasserelle(Guid id) {
            Passerelle passerelle =  await _passerelleRepository.GetAsync(id);
            return ObjectMapper.Map<Passerelle, PasserelleDto>(passerelle);
        }

        public async Task InsertBatchMesures(SondeBatchDto sondeBatchDto)
        {
            var passerelle = (await _passerelleRepository.GetQueryableAsync())
                .First(p => p.IdPhysique == sondeBatchDto.PasserellePhysicalId);
            foreach (var dto in sondeBatchDto.SondeTemperatureDtoList)
            {
                var machines = passerelle.Machines;
                var sondeExiste = machines.SelectMany(m => m.Sondes)
                    .Any(s => s.IdPhysique == dto.Sonde_id);
                Sonde sonde;
                if (sondeExiste)
                {
                    sonde = machines.SelectMany(m => m.Sondes).First(s => s.IdPhysique == dto.Sonde_id);
                }
                else
                {
                    Machine unknownMachine;
                    if (machines.Any(m => m.IdPhysique == "UNKNOWN_MACHINE"))
                    {
                        unknownMachine = machines.First(m => m.IdPhysique == "UNKNOWN_MACHINE");
                    }
                    else
                    {
                        unknownMachine = new Machine(_guidGenerator.Create(), passerelle.Id, "UNKNOWN_MACHINE",
                            "UNKNOWN_MACHINE");
                        unknownMachine = await _machineRepository.InsertAsync(unknownMachine);
                        passerelle.Machines.Add(unknownMachine);
                    }
                    sonde = new Sonde(_guidGenerator.Create(), unknownMachine, dto.Sonde_id, dto.Sonde_id);
                    sonde = await _sondeRepository.InsertAsync(sonde);
                }

                var mesure = new Mesure(_guidGenerator.Create(), sonde, dto.Temperature,
                    DateTimeOffset.FromUnixTimeSeconds(long.Parse(dto.Timestamp)).DateTime);
                mesure = await _mesureRepository.InsertAsync(mesure);
                sonde.Mesures.Add(mesure);
            }
        }
    }
}
