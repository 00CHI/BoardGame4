using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    public Image profileImage;

    public Text coinText;
    public Text nicknameText;
    public Text InputText;


    // Start is called before the first frame update
    void Awake()
    {
        profileImage.sprite = Singleton.GameDataMgr.profileImage;
        coinText.text = $"{Singleton.GameDataMgr.coin}";
        nicknameText.text = Singleton.GameDataMgr.profileName;
    }

    // Update is called once per frame
    void Update()
    {
        profileImage.sprite = Singleton.GameDataMgr.profileImage;
        coinText.text = $"{Singleton.GameDataMgr.coin}";
        nicknameText.text = Singleton.GameDataMgr.profileName;
        InputText.text = Singleton.GameDataMgr.profileName;
    }

    public void OnClick_ProfileImageButton(Image _image)
    {
        Singleton.AudioManager.PlayButtonSFX();
        Singleton.GameDataMgr.profileImage = _image.sprite;

        Singleton.GameDataMgr.coin -= 1000;
    }
}
