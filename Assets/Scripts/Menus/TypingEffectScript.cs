using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TypingEffectScript : MonoBehaviour
{
    [Tooltip("saves the text that will be displayed on screen")]
    [TextArea][SerializeField] string textToType;
    TextMeshProUGUI displayedText;
    bool switching = false;
    // Start is called before the first frame update
    void Start()
    {
        //get the text component of the game object
        displayedText = GetComponent<TMPro.TextMeshProUGUI>();
        //add to text that appears letter by letter
        StartCoroutine(typeAndWait());
    }


    void Update()
    {
        if (switching)
        {
            playGame();
        }
    }

    public void playGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene("IntroCutscene");
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene("LavaPlanet");
        }
    }

    IEnumerator typeAndWait()
    {
        foreach (char c in textToType)
        {
            displayedText.text += c;
            if (displayedText.text.Length == 550)
            {
                displayedText.text = "";
            }
            yield return new WaitForSeconds(0.08f);
        }
        switching = true;
    }
}
