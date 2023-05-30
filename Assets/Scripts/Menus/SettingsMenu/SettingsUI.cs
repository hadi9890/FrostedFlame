using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject UICanvas;
    [SerializeField]
    private Button UIClose;

    private void Awake() {
        UIClose.onClick.AddListener(Close); //when the close button is pressed, the close method which makes the Ui canvas invisble
        //close button will be invoked
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(){
        UICanvas.SetActive(true); //opens the pop-up UI canvas by making them visible 
    }

    public void Close(){
        UICanvas.SetActive(false); //closes the pop-up UI canvas by making them invisible
    }

    private void OnDestroy() {
        UIClose.onClick.RemoveListener(Close);
        //
    }




}
