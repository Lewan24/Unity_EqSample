namespace Assets.Scripts.Data.Core.Entities
{
    [System.Serializable]

    public class Pistol : Weapon
    {
        public int Range { get; private set; }

        public Pistol(string name, int damage, int range) : base(name, damage)
        {
            Range = range;
        }

        public override string GetBasicItemInfo() =>
            $"{base.GetBasicItemInfo()}, Range: {Range}";
    }
}