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

namespace MNS.Iot.Backend.Passerelles {
    public class PasserelleAppService : BackendAppService, IPasserelleAppService {
        private readonly IPasserelleRepository _passerelleRepository;
        private readonly IMagasinRepository _magasinRepository;
        private readonly ISondeRepository _sondeRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IGuidGenerator _guidGenerator;

        private readonly MagasinPasserelleManager _magasinPasserelleManager;

        public PasserelleAppService(IPasserelleRepository passerelleRepository, 
            IMagasinRepository magasinRepository, IGuidGenerator guidGenerator, 
            MagasinPasserelleManager magasinPasserelleManager, ISondeRepository sondeRepository,
            IMachineRepository machineRepository) {
            _passerelleRepository = passerelleRepository;
            _magasinRepository = magasinRepository;
            _guidGenerator = guidGenerator;
            _magasinPasserelleManager = magasinPasserelleManager;
            _sondeRepository = sondeRepository;
            _machineRepository = machineRepository;
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

        public Task InsertBatchMesures(SondeBatchDto sondeBatchDto) {
            sondeBatchDto.SondeTemperatureDtoList.ForEach(sonde => InsertMesures(sondeBatchDto.PasserellePhysicalId, sonde));
        
        }

        private async Sonde InsertMesures(string passerellePhysicalId, SondeTemperatureDto sondeTemperature) {  
            var query = await _sondeRepository.GetQueryableAsync();
            var sondeExiste = query.Any(s => s.IdPhysique == sondeTemperature.Sonde_id);

            Sonde sonde;
            if (sondeExiste) {
                sonde = query.First(s => s.IdPhysique == sondeTemperature.Sonde_id);
            } else {
                var unknownMachine = FindUnknownMachine(passerellePhysicalId);
                sonde = new Sonde()
            }
        }

        private async Task<Machine> FindUnknownMachine(string passerellePhysicalId) {
            var query = await _machineRepository.GetQueryableAsync();
            if (query.Any(m => m.Name == "UNKNOWN_MACHINE" && m.PasserelleId.IdPhysique)) {
                return query.First(m => m.Name == "UNKNOWN_MACHINE");
            }
            return new Machine()
        }
    }
}
