using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI: MonoBehaviour
{
    public List<GameObject> aiObjects = new List<GameObject>();
    public List<GameObject> aiProfiles = new List<GameObject>();

    List<eAIMEMBER> aiMembers = new List<eAIMEMBER>()
    {
        eAIMEMBER.eAIMEMBER_ONE,
        eAIMEMBER.eAIMEMBER_TWO,
        eAIMEMBER.eAIMEMBER_THREE,
        eAIMEMBER.eAIMEMBER_FOUR,
        eAIMEMBER.eAIMEMBER_FIVE,
        eAIMEMBER.eAIMEMBER_SIX,
        eAIMEMBER.eAIMEMBER_SEVEN,
        eAIMEMBER.eAIMEMBER_EIGHT,
        eAIMEMBER.eAIMEMBER_NINE
    };

    public List<GameObject> aiMembersList = new List<GameObject>();
    public List<eSTUDENT> aiStudents = new List<eSTUDENT>();
    public List<eTIME> aiTimes = new List<eTIME>();
    public List<eCRIME> aiCrimes = new List<eCRIME>();


    eCHARACTER eCHARACTER;

    AIStatInt aiStatInt;


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


