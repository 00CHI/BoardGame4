using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class AI: MonoBehaviour
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

    


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.AI = this;


        if(Singleton.RoomManager.isStart == true)
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

        if(isAIReasonComplete)
        {
            isWin = aiObjects.All(obj => obj.GetComponent<AIMembers>().isReason);

            if (isWin)
            {
                endImage.sprite = Resources.Load<Sprite>("03_Source/07_UI/GameEnd/WIN");
            }
            else if(!isWin)
            {
                endImage.sprite = Resources.Load<Sprite>("03_Source/07_UI/GameEnd/DEFEAT");
            }

            DOVirtual.DelayedCall(0.5f, () => EndCanvas.SetActive(true));

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

}


