using UnityEngine;

namespace GMTK_2025.Tower
{
    public class TowerInfo
    {
        public TowerType Type { get; set; }
        
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public Vector2[] AtkRange { get; set; }
        
        public int Hp { get; set; }
        
        public float AtkRate { get; set; }
        
        public TowerInfo(TowerType type, string name, int price, Vector2[] atkRange, int hp, float atkRate)
        {
            Type = type;
            Name = name;
            Price = price;
            AtkRange = atkRange;
            Hp = hp;
            AtkRate = atkRate;
        }
    }

    public enum TowerType
    {
        CloseAtk,
        LongAtk
    }
}