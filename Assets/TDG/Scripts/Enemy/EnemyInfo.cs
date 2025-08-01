using UnityEngine;

namespace GMTK_2025.Enemy
{
    public class EnemyInfo
    {
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public Vector2[] WayPoints { get; set; }
        
        public int Hp { get; set; }
        
        public float AtkRate { get; set; }
        
        public EnemyInfo(string name, int price, Vector2[] wayPoints, int hp, float atkRate)
        {
            Name = name;
            Price = price;
            WayPoints = wayPoints;
            Hp = hp;
            AtkRate = atkRate;
        }
    }
}