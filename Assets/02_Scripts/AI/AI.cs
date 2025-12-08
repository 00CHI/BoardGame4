using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class AI : MonoBehaviour
{
    public List<GameObject> aiObjects = new List<GameObject>();
    public List<GameObject> aiProfiles = new List<GameObject>();

    public List<GameObject> aiMembersList = new List<GameObject>();
    //public List<AIMembers> aiMemberses = new List<AIMembers>();
    public List<eSTUDENT> aiStudents = new List<eSTUDENT>();
    public List<eTIME> aiTimes = new List<eTIME>();
    public List<eCRIME> aiCrimes = new List<eCRIME>();



    public eCHARACTER eCHARACTER;

    public GameObject EndCanvas;

    public bool isAISelectComplete = false;
    public bool isAIReasonComplete = false;
    public bool isWin = false;

    public Image endImage;
    public Text goToLobbyText;




    // Start is called before the first frame update
    void Awake()
    {
        Singleton.AI = this;

        endImage.rectTransform.localScale = new Vector3(2f, 2f, 2f);
        goToLobbyText.DOFade(0f, 0f);


        if (Singleton.RoomManager.isStart == true)
        {
            GetChildren(Singleton.RoomManager.roomMemberCount);

            //Singleton.AIMembers.AICardSetting();
        }
    }

    // Update is called once per frame
    void Update()
    {
        AIMembers _aimem = aiObjects[0].GetComponent<AIMembers>();
        isAIReasonComplete = aiObjects.All(obj => obj.GetComponent<AIMembers>().isReasonComplete);

        if (isAIReasonComplete)
        {
            isWin = aiObjects.All(obj => obj.GetComponent<AIMembers>().isReason);

            if (isWin)
            {
                endImage.sprite = Resources.Load<Sprite>("03_Source/07_UI/GameEnd/WIN");
                //DOVirtual.DelayedCall(0.2f, () => );
                Singleton.AudioManager.winSFX();

                endImage.rectTransform.DOScale(Vector3.one, 2f)
                .SetEase(Ease.OutBack);

                //DOVirtual.DelayedCall(2f, () => OnAnyKeyToLobby());



            }
            else if (!isWin)
            {
                endImage.sprite = Resources.Load<Sprite>("03_Source/07_UI/GameEnd/DEFEAT");
                //DOVirtual.DelayedCall(0.2f, () => );
                Singleton.AudioManager.loseSFX();
            }

            DOVirtual.DelayedCall(0.5f, () =>
            {
                EndCanvas.SetActive(true);
                endImage.rectTransform.DOScale(Vector3.one, 1f)
                .SetEase(Ease.OutBack);

                DOVirtual.DelayedCall(2f, () => OnAnyKeyToLobby());

            });


        }
    }


    public void GetChildren(int _ROOMMEMBER)
    {
        for (int i = 0; i < _ROOMMEMBER - 1; i++)
        {
            aiObjects.Add(transform.GetChild(i).gameObject);
        }

        int j = 8;

        for (j = 8; j >= _ROOMMEMBER; j--)
        {
            aiProfiles[j - 1].SetActive(false);
        }

        //Singleton.AIMembers.AIMemberSelect();
    }

    public void OnAnyKeyToLobby()
    {

        goToLobbyText.text = "아무 버튼이나 눌러 로비로 이동";

        goToLobbyText.DOFade(1f, 3f);

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


