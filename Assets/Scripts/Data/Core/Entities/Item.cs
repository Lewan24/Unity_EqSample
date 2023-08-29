using Assets.Scripts.Data.Core.Interfaces;

namespace Assets.Scripts.Data.Core.Entities
{
    [System.Serializable]
    public class Item : IItem
    {
        public string? ItemName { get; set; }
        public int ItemAmount { get; set; }

        public virtual string GetBasicItemInfo() =>
            $"Item name: {ItemName}, Amount: {ItemAmount}";
    }
}