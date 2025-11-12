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

    eCHARACTER eCHARACTER;

    AIStatInt aiStatInt;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.AI = this;


        if(Singleton.RoomManager.isStart == true)
        {
            GetChildren(Singleton.RoomManager.roomMemberCount);
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

    void AICardSetting()
    {

        for (int i = 0; i < System.Enum.GetValues(typeof(eAIMEMBER)).Length; i++)
        {
        }

        //switch (eAIMEMBER)
        //{
        //    case eAIMEMBER.eAIMEMBER_ONE:

        //        break;
        //    case eAIMEMBER.eAIMEMBER_TWO:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_THREE:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_FOUR:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_FIVE:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_SIX:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_SEVEN:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_EIGHT:
        //        break;
        //    case eAIMEMBER.eAIMEMBER_NINE:
        //        break;
        //}
    }
}


