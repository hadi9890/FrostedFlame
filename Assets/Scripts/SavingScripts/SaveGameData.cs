
using UnityEngine;
using System.IO;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using Batteries;
using Pickup;
using Timer;
using UnityEngine.SceneManagement;
//this script uses serialization to save the game data
public class SaveGameData : MonoBehaviour
{
   // public static string fileName;
    [Tooltip("UI component displaying the time the player has spent playing the game")][SerializeField] TextMeshProUGUI timeLabel;

    [Tooltip("player's position and rotation")][SerializeField] Transform player;
    //[Tooltip("save menu")][SerializeField] GameObject saveMenu;

    static Vector3 pos;
    static Vector3 temp;
    public static int currScene = 2;//to load the right scene, default level 1
    static bool updateWhenLoad = false;
    public static string[] batteries;//to save names of collected batteries

    void Update()
    {
        if (updateWhenLoad)
        {
            player.position = temp;
            updateWhenLoad = false;
        }
        pos = player.position;
    }

    public static void saveGame()
    {
        BinaryFormatter bformatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "gameData.dat");
        GameData data = new GameData();
        
        data.health = Health.Health.health;
        // Debug.Log(data.health);

        data.currentTime = (int)Time.time;
        // Debug.Log(data.currentTime);

        data.itemsCollected = BatteryUIControl.numberOfBatteries;
        // Debug.Log(data.itemsCollected);

        data.collectedBatteryNames = new string[6];
        BatteryUIControl.batteriesCollected.CopyTo(data.collectedBatteryNames, 0);//copy to data starting from index 0
        //Debug.Log(data.collectedBatteryNames[0]);
        //Debug.Log(data.collectedBatteryNames.ToString());
        if(SceneManager.GetActiveScene().buildIndex == 1){
            data.tentStates = new bool[6];
            RaycastingPickup.tentsAccessed.CopyTo(data.tentStates, 0);
        }
        data.playerPos[0] = pos.x;
        data.playerPos[1] = pos.y;
        data.playerPos[2] = pos.z;
        //Debug.Log(data.playerPos);

        data.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        data.saved = true;//to check if saved game exists in main menu

        bformatter.Serialize(file, data);//save data to the file
        file.Close();
        Debug.Log("saved data");
    }
    public static void loadGame()
    {
        if (File.Exists(Application.persistentDataPath + "gameData.dat"))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "gameData.dat", FileMode.Open);
            GameData data = (GameData)bformatter.Deserialize(file);

            if (data.saved)
            {
                currScene = data.currentSceneIndex;
                Health.Health.health = data.health;
                TimerScript.loadedTime = data.currentTime;

                BatteryUIControl.numberOfBatteries = data.itemsCollected;
                BatteryUIControl.batteriesCollected = new string[6];
                data.collectedBatteryNames.CopyTo(BatteryUIControl.batteriesCollected, 0);
                if(SceneManager.GetActiveScene().buildIndex==1){
                    RaycastingPickup.tentsAccessed = new bool[6];
                    data.tentStates.CopyTo(RaycastingPickup.tentsAccessed, 0);
                }
                BatteryUIControl.loaded = true;
                RaycastingPickup.loaded = true;
                TimerScript.loaded = true;
                pos = new Vector3(data.playerPos[0], data.playerPos[1], data.playerPos[2]);
                temp = pos;
                updateWhenLoad = true;//upload dislay on load
                                      //to check if there is a game to load for the continue button in main menu
                ButtonControlScript.savedGameExists = true;
            }
            else
            {
                ButtonControlScript.savedGameExists = false;
                BatteryUIControl.loaded = false;
                RaycastingPickup.loaded = false;
                TimerScript.loaded = false;
            }
            file.Close();
            Debug.Log("loaded game data");
        }
        else
        {
            Debug.LogError("No game data exists");
        }

    }
    public static void deleteData()
    {
        if (File.Exists(Application.persistentDataPath + "/GameSavedData.dat"))
        {
            //delete the file
            resetData();
            File.Delete(Application.persistentDataPath + "/GameSavedData.dat");
            Debug.Log("deleted data");
        }
        else
        {
            Debug.LogError("No game data exists");
        }
    }
    public static void resetData()
    {
        currScene = 1;//level 1
        // numberCollected = 0;
        pos = Vector3.zero;
        Debug.Log("Data Reset");
    }
}