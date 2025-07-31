using System;
using GMTK_2025.Map;
using UnityEngine;

namespace GMTK_2025.Tower
{
    public class TowerFollowMouse : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject atkRangeIndicator;
        [SerializeField] private GameObject Correct;
        [SerializeField] private GameObject Error;
        
        private Ray ray;
        private RaycastHit2D hit;
        
        private TowerController towerController;
        private GridController gridController;
        
        public bool CanPlace { get; set; }

        public void Initialize(TowerController towerController)
        {
            this.towerController = towerController;
            
            camera = Camera.main;
        }
        
        private void Update()
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // 没有打中物体
            if (hit.collider == null)
            {
                CanPlace = false;
                gridController= null;
                FollowMouse();
                Correct.SetActive(false);
                Error.SetActive(false);
                return;
            }

            // 打中物体的 Tag 不是 Grid
            if (!hit.collider.CompareTag("Grid"))
            {
                CanPlace = false;
                gridController = null;
                FollowMouse();
                Correct.SetActive(false);
                Error.SetActive(false);
                return;
            }
            
            gridController = hit.collider.gameObject.GetComponent<GridController>();
            
            // 如果 Grid 已经有塔了
            if(gridController.HaveTower)
            {
                CanPlace = false;
                gridController = null;
                FollowMouse();
                Correct.SetActive(false);
                Error.SetActive(false);
                return;
            }
            
            // 吸附在 Grid 上
            Adsorb(hit.collider.transform.position);

            // 是否可以放置
            towerController.Grid = gridController;
            CanPlace = gridController.TryPlace(towerController.Info.Type);
            Correct.SetActive(CanPlace);
            Error.SetActive(!CanPlace);
        }
        
        /// <summary>
        /// 跟随鼠标
        /// </summary>
        private void FollowMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
        
        /// <summary>
        /// 吸附
        /// </summary>
        /// <param name="gridPosition"></param>
        private void Adsorb(Vector3 gridPosition)
        {
            transform.position = gridPosition;
        }

        private void OnDisable()
        {
            Correct.SetActive(false);
            Error.SetActive(false);
        }
    }
}