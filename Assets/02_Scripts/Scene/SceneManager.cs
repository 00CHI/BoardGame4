using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class  SceneManager : MonoBehaviour
{
    //[SerializeField]
    //Button StartButton;

    public GameObject audioManager;
    public GameObject settingCanvas;

    public AudioSource bgmAudio;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.SceneManager = this;

        //StartButton.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnCancleButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");

        DontDestroyOnLoad(gameObject);

    }

    public void LoadSceneLobby()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");

        //bgmAudio.clip = Resources.Load<AudioClip>("03_Source/08_Sound/BGM/Lobby_BGM");
        //bgmAudio.Play();
        DontDestroyOnLoad(gameObject);

    }
    public void OnButtonClick()
    {
        Singleton.AudioManager.PlayButtonSFX();

        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");

        //bgmAudio.clip = Resources.Load<AudioClip>("03_Source/08_Sound/BGM/InGame_BGM");
        //bgmAudio.Play();
        DontDestroyOnLoad(gameObject);

    }


}