using Assets.Scripts.Data.Core.Interfaces;
using System;
using System.Threading.Tasks;
using Assets.Scripts.Data.Core.Entities;

namespace Assets.Scripts.Data.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task ShowEq();
        Task AddItemToEq<T>(T item) where T : Item, IItem;
        Task RemoveItemFromEq(Guid itemId);
    }
}