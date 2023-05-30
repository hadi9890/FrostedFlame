
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtonControl : MonoBehaviour
{
    [SerializeField] GameObject inGameSettingsPanel;
    [SerializeField] GameObject pauseMenu;
    public void executeButtonMethod()
    {
        if (gameObject.name == "QuitToMainMenu")
        {
            SceneManager.LoadScene("MainMenu");
            // Debug.Log("clicked death quit button");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (gameObject.name == "Back")
        {
            // Debug.Log("back settings");
            inGameSettingsPanel.SetActive(false);
            pauseMenu.SetActive(true);

        }
    }
}
