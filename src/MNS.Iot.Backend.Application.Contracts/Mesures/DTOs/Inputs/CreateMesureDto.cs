using System;

namespace MNS.Iot.Backend.Mesures.DTOs.Inputs;

public class CreateMesureDto
{
    public Guid SondeId { get; set; }
    public double Temperature { get; set; }
    public DateTime Date { get; set; }
}