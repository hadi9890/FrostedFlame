
//this class will be 'serialized' into a file
[System.Serializable]
public class GameData
{
    public int currentSceneIndex;
    public int health;
    public int currentTime;//how long the player has been playing 
    public int itemsCollected; //number of items

    public int collectibles;
    public string[] collectedBatteryNames;

    public float[] playerPos = new float[3];//player x,y,z positions
    public float[] playerRotat = new float[3];//player x,y,z rotations

    public bool saved = false;

    public bool[] tentStates;
}