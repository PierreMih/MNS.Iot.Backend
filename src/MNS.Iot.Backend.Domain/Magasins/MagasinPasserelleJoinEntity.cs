using System;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins;

public class MagasinPasserelleJoinEntity : Entity
{
    public Guid MagasinId { get; set; }
    public Guid PasserelleId { get; set; }

    public MagasinPasserelleJoinEntity(Guid magasinId, Guid passerelleId)
    {
        MagasinId = magasinId;
        PasserelleId = passerelleId;
    }

    public override object?[] GetKeys()
    {
        return new object?[] { MagasinId, PasserelleId };
    }
}