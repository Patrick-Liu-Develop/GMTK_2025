using System;
using UnityEngine;

namespace GMTK_2025.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [Tooltip("移动速度")]
        [SerializeField] private float speed = 5f;
        private Transform[] waypoints;
        
        private bool isMoving = true;
        private int currentWaypointIndex = 0;

        public void Initialize(Transform[] waypoints)
        {
            this.waypoints = waypoints;
        }
        
        private void Update()
        {
            Move();
        }
        
        public void PauseMovement()
        {
            isMoving = false;
        }
        
        public void ResumeMovement()
        {
            isMoving = true;
        }

        private void Move()
        {
            if (!isMoving || waypoints == null || waypoints.Length == 0) return;

            Transform targetWaypoint = waypoints[currentWaypointIndex];
            
            Vector3 targetPosition = new Vector3(
                targetWaypoint.position.x,
                targetWaypoint.position.y,
                transform.position.z
            );
        
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("EnemyEndPoint"))
            {
                Destroy(this.gameObject);
            }
            
            if (other.CompareTag("Tower"))
            {
                PauseMovement();
            }
        }
    }
}