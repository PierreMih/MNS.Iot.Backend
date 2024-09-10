using AutoMapper.Internal.Mappers;
using MNS.Iot.Backend.Magasins.DTOs.Inputs;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;

namespace MNS.Iot.Backend.Magasins
{
    public class MagasinAppService : BackendAppService, IMagasinAppService{
        private readonly IMagasinRepository _magasinRepository;
        private readonly IGuidGenerator _guidGenerator;

        public MagasinAppService(IMagasinRepository magasinRepository, IGuidGenerator guidGenerator) {
            _magasinRepository = magasinRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<MagasinDto> CreateMagasin(CreateMagasinDto createMagasinDto) {
            Magasin magasin = new Magasin(_guidGenerator.Create(), createMagasinDto.Name);
            magasin = await _magasinRepository.InsertAsync(magasin);
            return ObjectMapper.Map<Magasin, MagasinDto>(magasin);
        }

        public async Task DeleteMagasin(Guid id) {
            var magasin = await _magasinRepository.GetAsync(id);
            await _magasinRepository.DeleteAsync(magasin);
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
