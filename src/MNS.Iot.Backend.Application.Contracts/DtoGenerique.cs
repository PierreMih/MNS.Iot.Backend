using System.Collections.Generic;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;

namespace MNS.Iot.Backend;

public class DtoGenerique<T>
{
    public IEnumerable<T> Data { get; set; }

    public DtoGenerique(IEnumerable<T> data)
    {
        Data = data;
    }
}