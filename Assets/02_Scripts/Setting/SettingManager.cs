using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{

    Button settingButton;
    public GameObject settingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        settingButton = GetComponent<Button>();
    }

    public void OpenSetting()
    {
        settingCanvas.SetActive(true);
    }
    public void CloseSetting()
    {
        settingCanvas.SetActive(false);
    }
}
