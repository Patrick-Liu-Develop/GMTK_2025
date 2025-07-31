using System;
using System.Collections.Generic;
using GMTK_2025.Map;
using GMTK_2025.UI;
using TDG;
using UnityEngine;

namespace GMTK_2025.Tower
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] private GameObject atkAreaPrefab;
        [SerializeField] private GameObject uiTowerDirection;
        
        public GridController Grid { get; set; }
        private TowerFollowMouse towerFollowMouse;
        
        public TowerInfo Info { get; set; }
        
        private List<GameObject> atkRangeList = new();

        private void Awake()
        {
            towerFollowMouse = GetComponent<TowerFollowMouse>();
            uiTowerDirection.SetActive(false);
            uiTowerDirection.GetComponent<UITowerDirection>().Tower = this;
        }

        public void Initialize(TowerInfo info)
        {
            Info = info;

            CreateAtkRange();
            towerFollowMouse.Initialize(this);
        }

        private void CreateAtkRange()
        {
            for (int i = 0; i < Info.AtkRange.Length; i++)
            {
                var newObj = Instantiate(atkAreaPrefab, transform);
                newObj.transform.localPosition = new Vector3(
                    Info.AtkRange[i].x,
                    Info.AtkRange[i].y,
                    newObj.transform.localPosition.z);
                atkRangeList.Add(newObj);
            }
        }

        public void TryPlaceTower()
        {
            if (Grid == null)
            {
                Debug.Log("Grid is empty.");
                Destroy(this.gameObject);
                return;
            }

            if (!towerFollowMouse.CanPlace)
            {
                Debug.Log("Can't place tower.");
                Destroy(this.gameObject);
                return;
            }
            
            towerFollowMouse.enabled = false;
            Grid.HaveTower = true;
            uiTowerDirection.SetActive(true);
        }
        
        public void SetAtkRange(TowerDirection direction)
        {
            switch (direction)
            {
                case TowerDirection.Back:
                    for (int i = 0; i < atkRangeList.Count; i++)
                    {
                        atkRangeList[i].transform.localPosition = new Vector3(
                            -Info.AtkRange[i].x,
                            -Info.AtkRange[i].y,
                            transform.position.z);
                    }
                    break;
                case TowerDirection.Left:
                    for (int i = 0; i < atkRangeList.Count; i++)
                    {
                        atkRangeList[i].transform.localPosition = new Vector3(
                            Info.AtkRange[i].y,
                            -Info.AtkRange[i].x,
                            transform.position.z);
                    }
                    break;
                case TowerDirection.Right:
                    for (int i = 0; i < atkRangeList.Count; i++)
                    {
                        atkRangeList[i].transform.localPosition = new Vector3(
                            -Info.AtkRange[i].y,
                            Info.AtkRange[i].x,
                            transform.position.z);
                    }
                    break;
                default:
                    for (int i = 0; i < atkRangeList.Count; i++)
                    {
                        atkRangeList[i].transform.localPosition = new Vector3(
                            Info.AtkRange[i].x,
                            Info.AtkRange[i].y,
                            transform.position.z);
                    }
                    break;
            }
            
            uiTowerDirection.SetActive(false);
        }
    }
    
    public enum TowerDirection
    {
        Front,
        Back,
        Right,
        Left
    }
}