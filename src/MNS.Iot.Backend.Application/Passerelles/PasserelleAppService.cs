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
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;

namespace MNS.Iot.Backend.Passerelles {
    public class PasserelleAppService : BackendAppService, IPasserelleAppService {
        private readonly IPasserelleRepository _passerelleRepository;
        private readonly IMagasinRepository _magasinRepository;
        private readonly IGuidGenerator _guidGenerator;

        private readonly MagasinPasserelleManager _magasinPasserelleManager;

        public PasserelleAppService(IPasserelleRepository passerelleRepository, 
            IMagasinRepository magasinRepository, IGuidGenerator guidGenerator, 
            MagasinPasserelleManager magasinPasserelleManager) {
            _passerelleRepository = passerelleRepository;
            _magasinRepository = magasinRepository;
            _guidGenerator = guidGenerator;
            _magasinPasserelleManager = magasinPasserelleManager;
        }
        public async Task<PasserelleDto> CreatePasserelle(CreatePasserelleDto createPasserelleDto) {
            Magasin magasin = await _magasinRepository.GetAsync(createPasserelleDto.MagasinId);
            Passerelle passerelle = new Passerelle(_guidGenerator.Create(), createPasserelleDto.Name, createPasserelleDto.IdPhysique);
            passerelle = await _passerelleRepository.InsertAsync(passerelle);

            await _magasinPasserelleManager.AddPasserelleToMagasin(magasin, passerelle);

            return ObjectMapper.Map<Passerelle, PasserelleDto>(passerelle);
        }

        public async Task DeletePasserelle(Guid id) {
            var passerelle = await _passerelleRepository.GetAsync(id);
            var magasinList = await _magasinRepository.GetListAsync(true);
            Magasin magasin = magasinList.First(m => m.MagasinPasserelleJoinEntities.Any(je => je.PasserelleId == id));
            await _magasinPasserelleManager.DeletePasserelle(magasin, passerelle);
        }

        public async Task<IEnumerable<PasserelleDto>> GetListPasserelle(Guid magasinId) {
            List<Passerelle> passerelleList = await _passerelleRepository.GetListByMagasinAsync(magasinId);
            return passerelleList.Select(p => ObjectMapper.Map<Passerelle, PasserelleDto>(p));
        }

        public Task<PasserelleDto> GetPasserelle(Guid id) {
            throw new NotImplementedException();
        }
    }
}
