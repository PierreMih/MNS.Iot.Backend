using System;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Mesures.DTOs.Outputs
{
    public class MesureDto : EntityDto<Guid>
    {
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
    }
}
