using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK_2025.Enemy
{
    public class EnemyGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private float generationRate = 3f;
        
        private int curReleaseEnemyIndex = 0;
        private List<GameObject> enemies = new();
        private Coroutine releaseRoutine;
        
        public void StartRelease()
        {
            if (releaseRoutine != null)
            {
                StopCoroutine(releaseRoutine);
                releaseRoutine = null;
            }
            
            releaseRoutine = StartCoroutine(Releasing());
        }
        
        public void StopRelease()
        {
            if (releaseRoutine == null) return;
            
            StopCoroutine(releaseRoutine);
            releaseRoutine = null;
        }
        
        private IEnumerator Releasing()
        {
            while (curReleaseEnemyIndex < enemies.Count)
            {
                GameObject obj = enemies[curReleaseEnemyIndex];
                //controller.gameObject.SetActive(true);
                //controller.CanMove = true;
                curReleaseEnemyIndex++;
                
                yield return new WaitForSeconds(generationRate);
            }
        }

        private void GenerateEnemies()
        {
            if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
            
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                var enemy = GenerateEnemy(enemyPrefabs[i]);
                enemies.Add(enemy);
            }
        }

        private GameObject GenerateEnemy(GameObject enemyPrefab)
        {
            GameObject newObj = Instantiate(enemyPrefab);
            newObj.transform.position = new Vector3(
                transform.position.x, 
                newObj.transform.position.y, 
                transform.position.z);
            newObj.SetActive(false);
            return newObj;
        }
    }
}