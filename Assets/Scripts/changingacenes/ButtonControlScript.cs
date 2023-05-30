using UnityEngine;
using UnityEngine.SceneManagement;
//this script is attached to buttons in the main menu
public class ButtonControlScript : MonoBehaviour
{
    public static bool savedGameExists = false;
    [SerializeField] GameObject quitConfirmationMenu;
    [SerializeField] GameObject noSavedDataMenu;
    [SerializeField] GameObject instMenu;
    [SerializeField] GameObject settingMenu;
    void Start()
    {
        quitConfirmationMenu.SetActive(false);
        noSavedDataMenu.SetActive(false);
    }
    public void ExecuteClickedMethod()//to be executed when a button is clicked
    {
        if (gameObject.name == "InstructionsBtn")
        {
            instMenu.SetActive(true);
        }
        if (gameObject.name == "QuitBtn")
        {
            //Debug.Log("quit confirm opened");
            quitConfirmationMenu.SetActive(true);//activate the confirm quit menu
        }
        if (gameObject.name == "ContinueGameBtn")
        {
            SaveGameData.loadGame();//retrieve saved data
            if (savedGameExists)
            {
                SceneManager.LoadScene(SaveGameData.currScene);//move to the game scene
            }
            else
            {
                //activate no saved game pop-up menu
                noSavedDataMenu.SetActive(true);
            }
        }
        if (gameObject.name == "OkayBtn")
        {
            noSavedDataMenu.SetActive(false);
        }
        if (gameObject.name == "StartNewBtn")
        {
            SceneManager.LoadScene("intro");
        }
        if (gameObject.name == "SettingsBtn")
        {
            settingMenu.SetActive(true);
        }
        if (gameObject.name == "BackButton")
        {
            settingMenu.SetActive(false);//close settings menu
        }
        if (gameObject.name == "BackBtn")
        {
            instMenu.SetActive(false);//close instructions menu
        }
        if (gameObject.name == "YesQuitBtn")
        {
            quitConfirmationMenu.SetActive(false);
            Application.Quit();
        }
        if (gameObject.name == "CancelQuitBtn")
        {
            quitConfirmationMenu.SetActive(false);//close quit confirmation window
        }
    }
}