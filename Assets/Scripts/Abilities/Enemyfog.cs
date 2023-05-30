
using System.Collections;
using UnityEngine;

public class Enemyfog : MonoBehaviour
{
    public ParticleSystem fog;
    public static bool fogplay = false;

    void Start()
    {
        fog=GetComponentInChildren<ParticleSystem>();
    }
    private void Update() {
        Playfog();
    }
    public void Playfog(){
        if(fogplay){
            // Debug.Log("Enter");
            fog.Play();
            StartCoroutine(Wait());
            // Debug.Log("Out");
            fog.Stop();
        }
    }
    public IEnumerator Wait()
    {
        // Debug.Log("WAIT");
        yield return new WaitForSeconds(6f);
    }
}
