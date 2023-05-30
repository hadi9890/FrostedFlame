
using EnemyCharacters.ScriptableObjects.Scripts;
using UnityEngine;

public class AbilitiesUsage : MonoBehaviour
{
    static Camera cam;
    [SerializeField] float attackRange = 15;
    [SerializeField] LayerMask enemy;
    private static Animator anim;
    static LayerMask enemyLayer;
    static float range;
    static int selectedDamage;
    static GameObject currentEnemy;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        enemyLayer = enemy;
        range = attackRange;
    }

    public static void playerAttack(int abilityIndex, bool lightActive)
    {
        Ray r = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        //  *** LIGHT ABILITIES ***
        if (abilityIndex == 0 && lightActive && InGameUIControl.lightAvailable[0])
        {
            // Perform Frost Spear
            anim.SetTrigger("FrostSpear");
            selectedDamage = 13;
        }
        if (abilityIndex == 1 && lightActive && InGameUIControl.lightAvailable[1])
        {
            // Perform Dull Senses
            anim.SetTrigger("DullingSenses");
            selectedDamage = 0;
        }
        if (abilityIndex == 2 && lightActive && InGameUIControl.lightAvailable[2])
        {
            // Perform Freeze
            anim.SetTrigger("Freeze");
            selectedDamage = 7;
        }
        if (abilityIndex == 3 && lightActive && InGameUIControl.lightAvailable[3])
        {
            // Perform Softened Blow
            anim.SetTrigger("SoftenedBlow");
            selectedDamage = 0;
        }

        //  *** DARK ABILITIES ***
        if (abilityIndex == 0 && !lightActive && InGameUIControl.darkAvailable[0])
        {
            // Perform Abyssal Blade
            anim.SetTrigger("AbyssalBlade");
            Health.Health.takeDamage(20);  // Damage to self
            selectedDamage = 35;
        }
        if (abilityIndex == 1 && !lightActive && InGameUIControl.darkAvailable[1])
        {
            // Perform Pure Darkness
            anim.SetTrigger("Darkness");
            Health.Health.takeDamage(10);  // Damage to self
            selectedDamage = 21;
        }
        if (abilityIndex == 2 && !lightActive && InGameUIControl.darkAvailable[2])
        {
            // Perform Fire Orb
            anim.SetTrigger("Fireball");
            Health.Health.takeDamage(12);  // Damage to self
            selectedDamage = 25;
        }
        if (abilityIndex == 3 && !lightActive && InGameUIControl.darkAvailable[3])
        {
            // Perform Mind Attack
            anim.SetTrigger("Feeblemind");
            Health.Health.takeDamage(6);   // Damage to self
            selectedDamage = 14;
        }

        // If enemy is in range and player attacks, deal damage to enemy
        if (Physics.Raycast(r, out hit, range, enemyLayer))
        {
            Debug.Log("Enemy is hit");
            EnemyTarget.damage = selectedDamage;
            EnemyTarget.damageTaken = true;
            currentEnemy = hit.transform.gameObject;
        }
    }
    public static void destroyEnemy() {
        Destroy(currentEnemy);
    }

    // public static string getChosenAbility()
    // {
    //     return InGameUIControl.activeAbility;
    // }
}
