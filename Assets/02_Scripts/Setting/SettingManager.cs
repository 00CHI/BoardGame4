using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{

    public GameObject settingCanvas;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.SettingManager = this;

        if(settingCanvas == null)
        {
            settingCanvas = GameObject.Find("SETTING_Canvas");

        }
    }

    public void OpenSetting()
    {
        settingCanvas.SetActive(true);
        Singleton.AudioManager.PlayButtonSFX();
    }
    public void CloseSetting()
    {
        settingCanvas.SetActive(false);
        Singleton.AudioManager.PlayButtonSFX();

    }
}
