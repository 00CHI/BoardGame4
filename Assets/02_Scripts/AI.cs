using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI: MonoBehaviour
{




    eCHARACTER eCHARACTER;
    eAIMEMBER eAIMEMBER;

    AIStatInt aiStatInt;


    // Start is called before the first frame update
    void Awake()
    {
        Singleton.AI = this;

        eCHARACTER = eCHARACTER.eCHARACTER_AI;
    }

    // Update is called once per frame
    void Update()
    {
        
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
