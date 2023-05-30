
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class Health : MonoBehaviour
    {
        [Tooltip("The UI component representing the health bar")][SerializeField] Image HealthUI;
        [Tooltip("Player Death menu")][SerializeField] GameObject onDeathMenu;
        public static int health = 100;
        public static bool soft_enabled = false;
        private static bool healthless = false;
        static bool showDeathMenu = false;
        static float percent;
        private static float time_lastAttack;   // To check if the player can regenerate at a given time

        private void Start()
        {
            //Automatic health regeneration
            StartCoroutine(automaticHealthRegeneration());
        }

        // *** HEALTH REGENERATION ***
        static IEnumerator automaticHealthRegeneration()
        {
            while (true)
            {
                //if the last attack was more than 5 seconds ago add 2 % HP every second
                if (Time.time - time_lastAttack > 5)
                {
                    Health.health += 2;
                }
                yield return new WaitForSeconds(1f);
            }
        }
        private void Update()
        {
            if (healthless & health > 30)
            {
                postprocessing.ChangeBack();
            }
        
            if (health <= 0)
            {
                health = 0;
                OnDeathEvent.invokeDeathEvent();
            }
            else if (health >= 100)
            {
                health = 100;
            }
            else
            {
                if (health <= 30)
                {
                    postprocessing.Change();
                    healthless = true;
                }
            }
            if (OnDeathEvent.died)
            {
                health = 100;//reset health on death
            }
            setHealthFill((float)health / 100);
            onDeathMenu.SetActive(showDeathMenu);
        }

        public static void takeDamage(int damage)
        {
            time_lastAttack = Time.time;

            // If softened blow is active
            if (soft_enabled)
            {
                if (health > 0)
                {
                    // Take only 70% of the damage
                    health -= (int)(0.7f * damage);
                }
            }
            else
            {
                if (health > 0)
                {
                    health -= damage;
                }
            }
            time_lastAttack = Time.time;    // Update last attack time to current time
        }

        void setHealthFill(float percent)
        {
            HealthUI.fillAmount = percent;
        }

        public static void Die()
        {
            showDeathMenu = true;
            //Debug.Log("Death menu activated");
        }

    }
}
