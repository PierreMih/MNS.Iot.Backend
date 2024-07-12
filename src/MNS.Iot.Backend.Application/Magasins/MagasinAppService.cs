using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Magasins {
    public class MagasinAppService {
        private readonly IMagasinRepository _magasinRepository;

        public MagasinAppService(IMagasinRepository magasinRepository) {
            _magasinRepository = magasinRepository;
        }
    }
}
