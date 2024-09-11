using System;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs;

public class CreateSondeDto
{
    public Guid MachineId { get; set; }
    public string IdPhysique { get; set; }
    public string Name { get; set; }
}