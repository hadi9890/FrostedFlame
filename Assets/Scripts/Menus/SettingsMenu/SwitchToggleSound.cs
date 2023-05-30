using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggleSound : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    Toggle toggle;
    Vector2 handlePosition;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    Image backgroundImage;
    Image handleImage;
    Color backgroundDefaultColor;
    Color handleDefaultColor;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;
        toggle.onValueChanged.AddListener(OnSwitch);
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();
        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        if (toggle.isOn)
        {
            OnSwitch(true);
        }

    }

    void OnSwitch(bool ON)
    {

        if (ON)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
        }

        if (ON)
        {
            backgroundImage.color = backgroundActiveColor;
        }
        else
        {
            backgroundImage.color = backgroundDefaultColor;
        }

        if (ON)
        {
            handleImage.color = handleActiveColor;
        }
        else
        {
            handleImage.color = handleDefaultColor;
        }
    }

    private void OnDestroy()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
