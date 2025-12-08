using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyButtonMgr : MonoBehaviour
{
    public GameObject exitCanvas;
    public GameObject roomCanvas;
    public GameObject settingCanvas;
    public GameObject profileCanvas;

    public void OnClick_ExitButton()
    {
        Singleton.AudioManager.PlayButtonSFX();
        exitCanvas.SetActive(true);
    }
    public void OnClick_ExitClose()
    {
        Singleton.AudioManager.PlayButtonSFX();
        exitCanvas.SetActive(false);
    }
    public void OnClick_Exit()
    {
        Singleton.AudioManager.PlayButtonSFX();
        exitCanvas.SetActive(false);
        Application.Quit();
    }
    public void OnClick_RoomOpen()
    {
        Singleton.AudioManager.PlayButtonSFX();
        roomCanvas.SetActive(true);
    }
    public void OnClick_RoomClose()
    {
        Singleton.AudioManager.PlayButtonSFX();
        roomCanvas.SetActive(false);
    }

    public void OnClick_PVPButton()
    {
        Singleton.AudioManager.PlayButtonSFX();
    }
    public void OnClick_VideoLink()
    {
        Singleton.AudioManager.PlayButtonSFX();
        Application.OpenURL("https://youtu.be/z2nJkrxZqVo?si=4cvBQza_3PoLSMyW");
    }

    public void OnClick_ProfileOpen()
    {
        Singleton.AudioManager.PlayButtonSFX();
        profileCanvas.SetActive(true);
    }
    public void OnClick_ProfileClose()
    {
        Singleton.AudioManager.PlayButtonSFX();
        profileCanvas.SetActive(false);
    }
}
