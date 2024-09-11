using System;

namespace MNS.Iot.Backend.Machines.DTOs.Inputs;

public class CreateMachineDto
{
    public Guid PasserelleId { get; set; }
    public string Name { get; set; }
    public string IdPhysique { get; set; }
}