using System;
using GMTK_2025.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK_2025.UI
{
    public class UITowerDirection : MonoBehaviour
    {
        [SerializeField] private Button btn_Front;
        [SerializeField] private Button btn_Back;
        [SerializeField] private Button btn_Right;
        [SerializeField] private Button btn_Left;
        
        public TowerController Tower { get; set; }

        private void OnEnable()
        {
            btn_Front.onClick.AddListener(() =>
            {
                Tower.SetAtkRange(TowerDirection.Front);
            });
            btn_Back.onClick.AddListener(() =>
            {
                Tower.SetAtkRange(TowerDirection.Back);
            });
            btn_Right.onClick.AddListener(() =>
            {
                Tower.SetAtkRange(TowerDirection.Right);
            });
            btn_Left.onClick.AddListener(() =>
            {
                Tower.SetAtkRange(TowerDirection.Left);
            });
        }

        private void OnDisable()
        {
            btn_Front.onClick.RemoveAllListeners();
            btn_Back.onClick.RemoveAllListeners();
            btn_Right.onClick.RemoveAllListeners();
            btn_Left.onClick.RemoveAllListeners();
        }
    }
}