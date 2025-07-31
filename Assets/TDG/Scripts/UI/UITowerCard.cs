using GMTK_2025.Tower;
using TDG;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GMTK_2025.UI
{
    public class UITowerCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float moveDistance = 50f;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private GameObject towerPrefab;
        
        private Vector3 originalPosition;
        private Vector3 targetPosition;
        private TowerController towerController;
        
        private TowerInfo Info{ get; set; }

        private void Start()
        {
            Vector2[] atkRange = {
                new( 0f, -1f ),
                new( 1f, -1f ),
                new( -1f, -1f )
            };
            Info = new TowerInfo(TowerType.CloseAtk, "Tower_Close", 0, atkRange, 100, 2f);
            originalPosition = transform.localPosition;
            targetPosition = originalPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            targetPosition = originalPosition + Vector3.up * moveDistance;

            CreateTower();
        }

        private void CreateTower()
        {
            var newObj = Instantiate(towerPrefab, targetPosition, Quaternion.identity);
            towerController = newObj.GetComponent<TowerController>();
            towerController.Initialize(Info);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            targetPosition = originalPosition;
            towerController.TryPlaceTower();
        }

        private void Update()
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                targetPosition,
                moveSpeed * Time.deltaTime);
        }
    }
}