using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.Data.Application.Interfaces;
using Assets.Scripts.Data.Core.Entities;
using Assets.Scripts.Data.Core.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Data.Application.Services
{
    public class EquipmentService : MonoBehaviour, IEquipmentService
    {
        private readonly List<IItem> _equipment = new ();

        private static EquipmentService _instance;
        private static MethodInfo clearMethod;

        public static EquipmentService Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<EquipmentService>();
                
                if (_instance != null) return _instance;
                
                var singletonObject = new GameObject(nameof(EquipmentService));
                _instance = singletonObject.AddComponent<EquipmentService>();
                return _instance;
            }
        }

        public static void InitializeService()
        {
            if (clearMethod != null) return;

            var assembly = Assembly.GetAssembly(typeof(UnityEditor.SceneView));
            var logEntries = assembly.GetType("UnityEditor.LogEntries");

            clearMethod = logEntries.GetMethod("Clear");
        }

        public Task ShowEq()
        {
            clearMethod.Invoke(null, null);

            foreach (var item in _equipment)
                Debug.Log(item.GetBasicItemInfo());

            return Task.CompletedTask;
        }

        public Task AddItemToEq<T>(T item) where T : Item, IItem
        {
            clearMethod.Invoke(null, null);

            _equipment.Add(item);
            Debug.Log($"Item: {item.ItemName} has been added to eq");

            return Task.CompletedTask;
        }

        public Task RemoveItemFromEq(Guid itemId)
        {
            clearMethod.Invoke(null, null);

            try
            {
                var item = _equipment.Last();
                _equipment.Remove(item);

                Debug.Log($"Successfully deleted item: {(item as Item)?.ItemName}");
            }
            catch (Exception e)
            {
                Debug.Log($"Error while deleting. Cant delete item, probably eq is empty. Error: {e.Message}");
            }

            return Task.CompletedTask;
        }
    }
}