using System;
using System.Collections.Generic;
using GMTK_2025.Enemy;
using GMTK_2025.Tower;
using GMTK_2025.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDG
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get => instance;
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            uiTower.Initialize(towerInfos);
        }

        private List<TowerInfo> towerInfos = new()
        {
            new TowerInfo(
                TowerType.CloseAtk,
                "Tower_CloseAtk",
                0,
                new []
                {
                    new Vector2(0,-1)
                },
                10,
                0.5f),
            new TowerInfo(
                TowerType.CloseAtk,
                "Tower_Shooter",
                0,
                new []
                {
                    new Vector2(-1,-1),
                    new Vector2(0,-1),
                    new Vector2(1,-1),
                    new Vector2(-1,-2),
                    new Vector2(0,-2),
                    new Vector2(1,-2),
                    new Vector2(-1,-3),
                    new Vector2(0,-3),
                    new Vector2(1,-3)
                },
                10,
                0.5f),
            new TowerInfo(
                TowerType.CloseAtk,
                "Tower_Magician",
                0,
                new []
                {
                    new Vector2(-1,1),
                    new Vector2(0,1),
                    new Vector2(1,1),
                    new Vector2(-1,0),
                    new Vector2(1,0),
                    new Vector2(-1,-1),
                    new Vector2(0,-1),
                    new Vector2(1,-1),
                    new Vector2(-1,-2),
                    new Vector2(0,-2),
                    new Vector2(1,-2)
                },
                10,
                0.5f)
        };

        private List<EnemyInfo> enemyInfos = new()
        {
            new EnemyInfo("Enemy_Lv1_A", 0, new[]
            {
                new Vector2(-4.5f, 1.5f),
                new Vector2(-3.5f, 1.5f),
                new Vector2(-2.5f, 1.5f),
                new Vector2(-1.5f, 1.5f),
                new Vector2(-0.5f, 1.5f),
                new Vector2(-0.5f, 2.5f),
                new Vector2(0.5f, 2.5f),
                new Vector2(1.5f, 2.5f),
                new Vector2(2.5f, 2.5f),
                new Vector2(3.5f, 2.5f),
                new Vector2(3.5f, 1.5f),
                new Vector2(3.5f, 0.5f),
                new Vector2(4.5f, -0.5f)
            }, 
                0, 0.5f),
            new EnemyInfo("Enemy_Lv1_B", 0, new[]
                {
                    new Vector2(-4.5f, 1.5f),
                    new Vector2(-3.5f, 1.5f),
                    new Vector2(-2.5f, 1.5f),
                    new Vector2(-1.5f, 1.5f),
                    new Vector2(-0.5f, 1.5f),
                    new Vector2(-0.5f, 0.5f),
                    new Vector2(0.5f, 0.5f),
                    new Vector2(1.5f, 0.5f),
                    new Vector2(1.5f, -0.5f),
                    new Vector2(1.5f, -1.5f),
                    new Vector2(2.5f, -1.5f),
                    new Vector2(3.5f, -1.5f),
                    new Vector2(3.5f, -0.5f),
                    new Vector2(3.5f, 0.5f),
                    new Vector2(4.5f, -0.5f)
                }, 
                0, 0.5f),
            new EnemyInfo("Enemy_Lv1_C", 0, new[]
                {
                    new Vector2(-1, -1)
                }, 
                0, 0.5f),
        };

        [SerializeField] private UITower uiTower;
    }
}