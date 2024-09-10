using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Magasins {
    public class MagasinAppService : BackendAppService, IMagasinAppService{
        private readonly IMagasinRepository _magasinRepository;

        public MagasinAppService(IMagasinRepository magasinRepository) {
            _magasinRepository = magasinRepository;
        }

        public async Task<IEnumerable<MagasinDto>> GetListMagasin() {
            var listMagasin = await _magasinRepository.GetListAsync();
            return listMagasin.Select(m => ObjectMapper.Map<Magasin, MagasinDto>(m));
        }

        public async Task<MagasinDto> GetMagasin(Guid id) {
            var magasin = await _magasinRepository.GetAsync(id);
            return ObjectMapper.Map<Magasin, MagasinDto>(magasin);
        }
    }
}
