
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.Scripts
{
    public class EnemyTarget : MonoBehaviour
    {
        //Target enemies for reducing health
        public EnemyStats target;
        public static bool damageTaken = false;
        public int enemyHealth;
        public static int damage;

        private void Start()
        {
            enemyHealth = 10;
        }
    
        private void Update()
        {
            if (damageTaken)
            {
                enemyHealth -= damage;
                Debug.Log(enemyHealth);
                if(enemyHealth <= 0)
                {   enemyHealth = 0;
                    WinLogic.enemyCount--;
                    AbilitiesUsage.destroyEnemy();
                    // this.gameObject.SetActive(false);
                }
                damageTaken = false;
            }
        }

    }
}
