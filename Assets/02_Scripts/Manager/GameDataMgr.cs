using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataMgr : MonoBehaviour
{
    public int coin = 100000;
    public string profileName;
    public Sprite profileImage;
    public Text inputText;


    // Start is called before the first frame update
    void Awake()
    {
        if (Singleton.GameDataMgr == null)
        {
            Singleton.GameDataMgr = this;
            profileImage = Resources.Load<Sprite>("03_Source/07_UI/profile/profile_3");
            DontDestroyOnLoad(gameObject);  // 씬 이동해도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        profileName = inputText.text;
    }
}
