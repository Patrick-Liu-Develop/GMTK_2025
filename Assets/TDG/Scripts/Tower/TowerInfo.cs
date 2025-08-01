using UnityEngine;

namespace GMTK_2025.Tower
{
    [CreateAssetMenu(fileName = "TowerInfo", menuName = "ScriptableObject/TowerInfo")]
    public class TowerInfo : ScriptableObject
    {
        public TowerType Type;
        public string Name;
        public int Price;
        public Vector2[] AtkRange;
        public int Hp;
        public float AtkRate;
        
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