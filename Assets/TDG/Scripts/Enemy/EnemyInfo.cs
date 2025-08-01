using UnityEngine;

namespace GMTK_2025.Enemy
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObject/EnemyInfo")]
    public class EnemyInfo: ScriptableObject
    {
        public string Name;

        public int Price;

        public Vector2[] WayPoints;

        public int Hp;

        public float AtkRate;
        
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