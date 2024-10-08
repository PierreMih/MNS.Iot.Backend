﻿using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Passerelles.DTOs.Inputs;
using MNS.Iot.Backend.Sondes.DTOs.Inputs;
using MNS.Iot.Backend.Sondes.DTOs.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend.Passerelles
{
    public interface IPasserelleAppService : IApplicationService {

        public Task<DtoGenerique<PasserelleDto>> GetListPasserelle(Guid magasinId);
        public Task<PasserelleDto> GetPasserelle(Guid id);
        public Task<PasserelleDto> CreatePasserelle(CreatePasserelleDto createPasserelleDto);
        public Task DeletePasserelle(Guid id);
        public Task InsertBatchMesures(SondeBatchDto sondeBatchDto);
    }
}
