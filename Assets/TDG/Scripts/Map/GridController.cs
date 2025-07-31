using System;
using GMTK_2025.Tower;
using UnityEngine;

namespace GMTK_2025.Map
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private TowerType towerType;
        
        public bool HaveTower { get; set; }

        private void Awake()
        {
            HaveTower = false;
        }

        public bool TryPlace(TowerType towerType)
        {
            if (this.towerType == towerType)
            {
                return true;
            }
            
            return false;
        }
    }
}