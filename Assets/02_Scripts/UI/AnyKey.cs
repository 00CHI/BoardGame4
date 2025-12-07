using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !IsMouseInput())
        {
            Singleton.SceneManager.LoadSceneLobby();


        }
    }

    bool IsMouseInput()
    {
        return Input.GetMouseButtonDown(0)  // 좌클릭
            || Input.GetMouseButtonDown(1)  // 우클릭
            || Input.GetMouseButtonDown(2)  // 휠클릭
            || Input.GetAxis("Mouse ScrollWheel") != 0f; // 스크롤
    }

}
