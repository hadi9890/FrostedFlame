using UnityEngine;

public class WinLogic : MonoBehaviour
{
    [SerializeField] GameObject winMenu;
    GameObject[] allEnemies;
    public static int enemyCount;
    
    void Start()
    {
        winMenu.SetActive(false);
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = allEnemies.Length;
    }
    
    void Update()
    {
        if (enemyCount > 0) return;
        Time.timeScale = 0;
        winMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
