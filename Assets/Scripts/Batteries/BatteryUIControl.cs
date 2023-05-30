
using UnityEngine;
using UnityEngine.UI;

namespace Batteries
{
    public class BatteryUIControl : MonoBehaviour
    {
        [Tooltip("The UI component containing the collected batteries ")][SerializeField] GameObject BatteriesUI;
        [Tooltip("array of battery sprites ")][SerializeField] Sprite[] batterySprites;
        public static string[] batteriesCollected;//to be used when saving and loading

        //for tracking the number of battery packs the player has collected so far
        public static int numberOfBatteries;
        public static bool pickedUpBattery = false;
        static Sprite batteryPicked;
        public static bool loaded = false;
        
        void Start()
        {
            if (!loaded)
            {
                batteriesCollected = new string[6];
                numberOfBatteries = 0;
            }
            else if (loaded)
            {
                for (int i = 0; i < numberOfBatteries; i++)
                {
                    string bname = batteriesCollected[i];
                    switch (bname)
                    {
                        case "RedBattery":
                            updateBatteryDisplay(batterySprites[0], i);
                            break;
                        case "BlueBattery":
                            updateBatteryDisplay(batterySprites[1], i);
                            break;
                        case "DarkBattery":
                            updateBatteryDisplay(batterySprites[2], i);
                            break;
                        case "GreenBattery":
                            updateBatteryDisplay(batterySprites[3], i);
                            break;
                        case "PinkBattery":
                            updateBatteryDisplay(batterySprites[4], i);
                            break;
                        case "PurpleBattery":
                            updateBatteryDisplay(batterySprites[5], i);
                            break;
                    }
                }
            }
        }
        
        void Update()
        {
            if (pickedUpBattery)
            {
                updateBatteryDisplay(batteryPicked, numberOfBatteries);
                pickedUpBattery = false;
                numberOfBatteries++;
                // Debug.Log(numberOfBatteries + "battery");
            }
        }
        
        public static void activatePickedUpBattery(Battery bat)
        {   // Use pick up and scriptable objects to activate the right UI icon
            batteryPicked = bat.icon;
            batteriesCollected[numberOfBatteries] = bat.batteryName;    // Add to the list of thusfar collected batteries
            pickedUpBattery = true;
            // Debug.Log(batteriesCollected[numberOfBatteries]);
        }
        
        void updateBatteryDisplay(Sprite icon, int i)
        {//add picked up battery to display
            BatteriesUI.transform.GetChild(i).GetComponent<Image>().sprite = icon;
        }

    }
}