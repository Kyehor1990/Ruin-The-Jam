using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mehmet
{
    public class WorkTable : MonoBehaviour
    {
        [Header("Progress Bar")]
        public Slider progressBar;
        public float maxProgress = 100f;
        public float baseSpeed = 5f;

        private float currentProgress = 0f;
        private List<EnemyWorker> activeEnemies = new List<EnemyWorker>();

        [SerializeField] CompletedTable completedTable;

        private bool isCompleted = false;

        void Update()
        {
            float speedMultiplier = 0f;

            foreach (var enemy in activeEnemies)
            {
                if (!enemy.IsStunned)
                    speedMultiplier += 1f;
            }

            currentProgress += baseSpeed * speedMultiplier * Time.deltaTime;
            currentProgress = Mathf.Min(currentProgress, maxProgress);

            if (progressBar != null)
                progressBar.value = currentProgress / maxProgress;

            if (currentProgress >= maxProgress && !isCompleted){
                completedTable.CompletedWorkTable();
                isCompleted = true;
            }
        }

        public void RegisterEnemy(EnemyWorker enemy)
        {
            if (!activeEnemies.Contains(enemy))
                activeEnemies.Add(enemy);
        }

        public void UnregisterEnemy(EnemyWorker enemy)
        {
            if (activeEnemies.Contains(enemy))
                activeEnemies.Remove(enemy);
        }
    }
}
    