// using System;
// using Volo.Abp.Domain.Entities;
//
// namespace MNS.Iot.Backend.Magasins.Passerelles;
//
// public class PasserelleMachineJoinEntity : Entity
// {
//     public Guid PasserelleId { get; set; }
//     public Guid MachineId { get; set; }
//     
//     public override object?[] GetKeys()
//     {
//         return new object?[] { PasserelleId, MachineId };
//     }
// }