namespace Assets.Scripts.Data.Core.Entities
{
    [System.Serializable]
    public class Weapon : Item
    {
        public int Damage { get; private set; }

        public Weapon(string name, int damage)
        {
            ItemName = name;
            ItemAmount = 1;
            Damage = damage;
        }

        public override string GetBasicItemInfo() =>
            $"Weapon name: {ItemName}, Amount: {ItemAmount}, Damage: {Damage}";
    }
}