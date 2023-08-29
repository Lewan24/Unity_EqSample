using System;

namespace Assets.Scripts.Data.Core.Entities
{
    [Serializable]
    public class Armor : Item
    {
        public int Defense { get; private set; }

        public Armor(string name, int defense)
        {
            ItemName = name;
            ItemAmount = 1;
            Defense = defense;
        }

        public override string GetBasicItemInfo() =>
            $"Armor name: {ItemName}, Amount: {ItemAmount}, Defense: {Defense}";
    }
}