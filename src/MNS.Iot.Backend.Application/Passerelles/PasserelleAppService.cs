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
            Passerelle passerelle = new Passerelle(_guidGenerator.Create(), magasin, createPasserelleDto.Name, createPasserelleDto.IdPhysique);
            magasin.Passerelles.Add(passerelle);
            // var je = new MagasinPasserelleJoinEntity(magasin.Id, passerelle.Id);
            // magasin.MagasinPasserelleJoinEntities.Add(je);
            
            // await _magasinPasserelleManager.AddPasserelleToMagasin(magasin, passerelle);
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
            var query = await _passerelleRepository.GetQueryableAsync();
            query = query.Where( p => p.MagasinId == magasinId);
            return query.AsEnumerable().Select(p=> ObjectMapper.Map<Passerelle, PasserelleDto>(p));
            
            // Magasin magasin = await _magasinRepository.GetAsync(magasinId);
            // IEnumerable<Guid> passerelleIdList = magasin.MagasinPasserelleJoinEntities.Select(je => je.PasserelleId);
            // List<Passerelle> passerelleList = new();
            // foreach(var passerelleId in passerelleIdList) {
            //     passerelleList.Add(await _passerelleRepository.GetAsync(passerelleId));
            // }
            // return passerelleList.Select(p => ObjectMapper.Map<Passerelle, PasserelleDto>(p));
        }

        public async Task<PasserelleDto> GetPasserelle(Guid id) {
            Passerelle passerelle =  await _passerelleRepository.GetAsync(id);
            return ObjectMapper.Map<Passerelle, PasserelleDto>(passerelle);
        }
    }
}
