using MNS.Iot.Backend.Magasins.Passerelles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MNS.Iot.Backend.Magasins {
    public class MagasinPasserelleManager : DomainService{

        private readonly IMagasinRepository _magasinRepository;

        public MagasinPasserelleManager(IMagasinRepository magasinRepository) {
            _magasinRepository = magasinRepository;
        }

        public async Task<Magasin> AddPasserelleToMagasin(Magasin magasin, Passerelle passerelle)
        {
            var je = new MagasinPasserelleJoinEntity(magasin.Id, passerelle.Id);
            magasin.MagasinPasserelleJoinEntities.Add(je);
            // magasin = await _magasinRepository.UpdateAsync(magasin);
            return magasin;
        }

        public async Task DeletePasserelle(Magasin magasin, Passerelle passerelle) {
            MagasinPasserelleJoinEntity joinEntity = magasin.MagasinPasserelleJoinEntities
                .First(je => je.MagasinId == magasin.Id && je.PasserelleId == passerelle.Id);
            magasin.MagasinPasserelleJoinEntities.Remove(joinEntity);
            // magasin = await _magasinRepository.UpdateAsync(magasin);
        }
    }
}
