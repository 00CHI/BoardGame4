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

    public void OnButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");

    }

    public void OnCancleButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

}