using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backgroundmusic : MonoBehaviour
{
    static backgroundmusic instance;
    private void Awake() {
        instance=this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (instance) return;
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}