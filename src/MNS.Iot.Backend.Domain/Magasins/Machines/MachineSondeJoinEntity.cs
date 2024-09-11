// using System;
// using Volo.Abp.Domain.Entities;
//
// namespace MNS.Iot.Backend.Magasins.Machines;
//
// public class MachineSondeJoinEntity : Entity
// {
//     public Guid MachineId { get; set; }
//     public Guid SondeId { get; set; }
//     
//     public override object?[] GetKeys()
//     {
//         return new object?[] { MachineId, SondeId };
//     }
// }