using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SaveMenuControl : MonoBehaviour
{
    [Tooltip("The UI save menu")][SerializeField] GameObject saveMenu;
    [Tooltip("The UI pause menu")][SerializeField] GameObject pauseMenu;
    //[Tooltip("Where to input the name of the file to save game data to")][SerializeField] TMP_InputField saveFileInputField;

    //static string inputName = "";

    // Start is called before the first frame update
    public void onClickExecute()//execute the right block based on the clicked button
    {
        if (gameObject.name == "SaveButton")//pause menu save button
        {
            pauseMenu.SetActive(false);
            saveMenu.SetActive(true);//open save menu
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("open save menu");
            //saveFileInputField.characterLimit = 30;
        }

        if (gameObject.name == "SaveBtn")
        {
            // if (validateFileName(inputName))
            // {
                //SaveGameData.fileName = saveFileInputField.text;//get file name from user
                SaveGameData.saveGame(); //save and deactivate save menu, remain in level
                saveMenu.SetActive(false);//close save menu
                pauseMenu.SetActive(true);
                
                
            // }
            //else{Debug.Log("invalid file name");}
        }

        if (gameObject.name == "SaveAndExitBtn")
        {
            // if (validateFileName(inputName))
            // {
                // SaveGameData.fileName = saveFileInputField.text;//get file name from user
                SaveGameData.saveGame(); //save
                saveMenu.SetActive(false);//close save menu
                SceneManager.LoadScene("MainMenu");//exit game level
            // }
        }

        if (gameObject.name == "BackBtn")
        {
            saveMenu.SetActive(false);//close save menu 
            Time.timeScale = 1;
        }
    }
    // private bool validateFileName(string name)
    // {
    //     if (name.Length < 1)
    //         return false;
    //     foreach (char c in name.ToCharArray())
    //     {
    //         if (!char.IsLetterOrDigit(c))
    //             return false;
    //     }
    //     return true;
    // }
}