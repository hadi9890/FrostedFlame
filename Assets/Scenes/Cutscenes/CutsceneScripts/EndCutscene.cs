
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    // private PlayableDirector director;
    private void Start()
    {
        // director = gameObject.GetComponent<PlayableDirector>();
        StartCoroutine(waitCutscene());
    }

    private void Update()
    {

    }

    IEnumerator waitCutscene()
    {
        yield return new WaitForSeconds(33.0f);
        SceneManager.LoadScene("IcePlanet");
    }


}
