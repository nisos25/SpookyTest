using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccesibilyMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown filterMode;

    private Camera cameraMain;
    private void Start()
    {
        cameraMain = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        if(filterMode != null) {
            cameraMain.GetComponent<ColorBlindFilter>().mode = (ColorBlindMode)filterMode.value;
            AccesibilityModel.filter = filterMode.value;
        }
        else
        {
            cameraMain.GetComponent<ColorBlindFilter>().mode = (ColorBlindMode)AccesibilityModel.filter;
        }
    }


}
