using AutoMapper;
using MNS.Iot.Backend.Magasins;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;

namespace MNS.Iot.Backend;

public class BackendApplicationAutoMapperProfile : Profile
{
    public BackendApplicationAutoMapperProfile()
    {
        CreateMap<Magasin, MagasinDto>();
        CreateMap<Passerelle, PasserelleDto>();
        CreateMap<Machine, MachineDto>();
        CreateMap<Sonde, SondeDto>();
        CreateMap<Mesure, MesureDto>();
    }
}
