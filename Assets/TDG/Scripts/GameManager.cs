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

        [SerializeField] private UITower uiTower;
    }
}