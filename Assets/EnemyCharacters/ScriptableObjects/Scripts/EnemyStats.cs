
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.Scripts
{
    [CreateAssetMenu(menuName = "enemyStats")]
    
    public class EnemyStats : ScriptableObject
    {
        public float walkSpeed;
        public float runSpeed;
        public float attackRate;
        public int health;
        public int dmg;
        public int searchTime;
        public int searchTurnSpeed;
    }
}
