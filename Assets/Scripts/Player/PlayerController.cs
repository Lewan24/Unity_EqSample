using System;
using System.Threading.Tasks;
using Assets.Scripts.Data.Application.Services;
using Assets.Scripts.Data.Core.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    async Task Start()
    {
        EquipmentService.InitializeService();

        await EquipmentService.Instance.AddItemToEq(new Weapon("Sword", 5));
        await EquipmentService.Instance.AddItemToEq(new Pistol("Simple Glock", 12, 4));
    }

    async Task Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            await EquipmentService.Instance.ShowEq();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            await EquipmentService.Instance.AddItemToEq(new Weapon("Random sword", Random.Range(1, 6)));

        if (Input.GetKeyDown(KeyCode.Alpha2))
            await EquipmentService.Instance.AddItemToEq(new Pistol("Random pistol", Random.Range(4, 15), Random.Range(2, 4)));

        if (Input.GetKeyDown(KeyCode.Alpha3))
            await EquipmentService.Instance.AddItemToEq(new Armor("Random armor", Random.Range(2, 8)));

        if (Input.GetKeyDown(KeyCode.Backspace))
            await EquipmentService.Instance.RemoveItemFromEq(Guid.NewGuid());
    }
}
