
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIControl : MonoBehaviour
{
    [Tooltip("The UI component that contains the abilities' icons")][SerializeField] GameObject abilityContainer;
    string[] lightAbilities; // stores the names of the light abilities
    string[] darkAbilities; // stores the names of the dark abilities

    float softened_blow_limit = 6f; // Active Time
    float dull_senses_limit = 5f; // Active Time
    float pure_darkness_limit = 10f; // Active Time

    public static bool[] lightAvailable; // stores the state of light abilities (recharging available or not)
    public static bool[] darkAvailable; // stores the state of dark abilities (recharging available or not)
    public static bool lightAbilityActivated = true; // Determine which ability set is active

    float[] rechargeTimeLight;
    float[] rechargeTimeDark;

    // Displaying the number of battery packs the player has collected so far
    public static int activeIndex = 0;
    public static string activeAbility = ""; // Used in RAYCASTING ABILITY SCRIPT
    [Tooltip("Softened Blow capsule shader")][SerializeField] GameObject softenedShade;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Determining available abilities based on levels
        if (SceneManager.GetActiveScene().buildIndex == 1)  // Level 1
        {
            lightAbilityActivated = true;
        }

        // Abilities ready to use from the start
        lightAvailable = new bool[4] { true, true, true, true };
        darkAvailable = new bool[4] { true, true, true, true };

        // Ability names
        lightAbilities = new string[4] { "Frost Spear", "Dull Senses", "Freeze", "Softened Blow" };
        darkAbilities = new string[4] { "Abyssal Blade", "Pure Darkness", "Fire Orb", "Mind Attack" };

        // Ability recharge times
        rechargeTimeLight = new float[4] { 6f, 8f, 7f, 16f };
        rechargeTimeDark = new float[4] { 7f, 12f, 9f, 15f };
    }

    void Update()
    {
        // Determining if we can switch abilities every time we try to switch
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            lightAbilityActivated = true;
        }

        // If softened blow is enabled
        if (lightAbilityActivated && activeIndex == 3 && lightAvailable[3])
        {
            Health.Health.soft_enabled = true;
        }

        // GET INPUT FOR ACTIVATING AND USING ABILITIES

        if (Input.GetKeyDown(KeyCode.X))    // Switch between light and dark abilities
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)  // Switch between ability sets only in second level
            {
                if (lightAbilityActivated)  // if dark
                {
                    // Deactivate light abilities UI display
                    for (int i = 0; i <= 3; i++)
                    {
                        abilityContainer.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                    }

                    // Activate dark abilities UI display
                    for (int j = 0; j <= 3; j++)
                    {
                        abilityContainer.transform.GetChild(j).GetChild(0).gameObject.SetActive(true);
                    }
                }
                else
                {
                    // Activate light abilities UI display
                    for (int i = 0; i <= 3; i++)
                    {
                        abilityContainer.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                    }

                    // Deactivate dark abilities UI display
                    for (int i = 0; i <= 3; i++)
                    {
                        abilityContainer.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                    }
                }
                lightAbilityActivated = !lightAbilityActivated;
            }
        }
        int oldIndex = activeIndex; // Used to deactivate the border of the ability that was last active

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeIndex = 0;
            if (lightAbilityActivated)
            {
                activeAbility = lightAbilities[0];
            }
            else
            {
                activeAbility = darkAbilities[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeIndex = 1;
            if (lightAbilityActivated)
            {
                activeAbility = lightAbilities[1];
            }
            else
            {
                activeAbility = darkAbilities[1];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeIndex = 2;
            if (lightAbilityActivated)
            {
                activeAbility = lightAbilities[2];
            }
            else
            {
                activeAbility = darkAbilities[2];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeIndex = 3;
            if (lightAbilityActivated)
            {
                activeAbility = lightAbilities[3];
            }
            else
            {
                activeAbility = darkAbilities[3];
            }
        }

        //  *** BORDER OF SELECTED ABILITY ***

        //deactivate border of last active ability if different than the current ability
        abilityContainer.transform.GetChild(oldIndex).GetChild(3).gameObject.SetActive(false);
        //activate new border
        abilityContainer.transform.GetChild(activeIndex).GetChild(3).gameObject.SetActive(true);

        // Using the ability
        if (Input.GetKeyDown(KeyCode.Mouse0) && !PauseMenu.GameIsPaused)
        {//if left mouse button is clicked

            if (lightAbilityActivated && lightAvailable[activeIndex] || !lightAbilityActivated && darkAvailable[activeIndex])
            {//if the ability is available for use
                AbilitiesUsage.playerAttack(activeIndex, lightAbilityActivated);
                StartCoroutine(rechargeCoroutine(activeIndex, lightAbilityActivated));  // Activate recharge ability coroutine
            }
        }

    }

    public IEnumerator rechargeCoroutine(int abilityToPause, bool isLightMode)
    {
        // Some abilities have an active time before they are drained and need to recharge
        if (lightAbilityActivated && activeIndex == 3 && lightAvailable[3])
        {//if "Softened Blow" is used
            softenedShade.SetActive(true);
            yield return new WaitForSeconds(softened_blow_limit);
            Health.Health.soft_enabled = false;
            softenedShade.SetActive(false);
            //Debug.Log("waited until ability is used up");
        }

        if (lightAbilityActivated && activeIndex == 1 && lightAvailable[1])
        {//if "Dull Senses" is used
            yield return new WaitForSeconds(dull_senses_limit);
        }

        if (!lightAbilityActivated && activeIndex == 1 && darkAvailable[1])
        {//if "Pure Darkness" is used
            yield return new WaitForSeconds(pure_darkness_limit);
        }

        // Set the ability that was just used as not available until fully recharged
        int timeToRecharge;
        if (isLightMode)
        {
            lightAvailable[abilityToPause] = false;
            timeToRecharge = (int)rechargeTimeLight[abilityToPause];
        }
        else
        {
            darkAvailable[abilityToPause] = false;
            timeToRecharge = (int)rechargeTimeDark[abilityToPause];
        }
        GameObject rechargeFilter;  // Get "filter" object over icon and activate it
        rechargeFilter = abilityContainer.transform.GetChild(abilityToPause).GetChild(2).gameObject;

        rechargeFilter.SetActive(true); // Activate the filter
        //  Recharging of abilities is indicated with a fading dark filter over the ability used
        float fillPortion = (float)1 / timeToRecharge;  // A fraction of the recharge filter
        while (timeToRecharge > 0)
        {
            // Debug.Log(timeToRecharge);
            rechargeFilter.GetComponent<Image>().fillAmount -= fillPortion;
            yield return new WaitForSeconds(1f);
            timeToRecharge--;
        }

        rechargeFilter.GetComponent<Image>().fillAmount = 1;    // Refill the filter for next time
        rechargeFilter.SetActive(false);    // Deactivate the recharging filter
        // Ability is available again
        if (isLightMode)
        {
            lightAvailable[abilityToPause] = true;
        }
        else
        {
            darkAvailable[abilityToPause] = true;
        }
    }
}
