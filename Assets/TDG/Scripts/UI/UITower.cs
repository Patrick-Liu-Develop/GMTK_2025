using System.Collections.Generic;
using GMTK_2025.Tower;
using UnityEngine;

namespace GMTK_2025.UI
{
    public class UITower : MonoBehaviour
    {
        [SerializeField] private UITowerCard[] towerCards;

        public void Initialize(List<TowerInfo> towerInfos)
        {
            for (int i = 0; i < towerInfos.Count; i++)
            {
                towerCards[i].Info = towerInfos[i];
            }
        }
    }
}